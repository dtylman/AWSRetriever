using Amazon;
using Amazon.Runtime;
using AWSRetriver.Controls;
using CloudOps;
using Retriever.Model;
using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace Retriever
{
    public class ConsoleScanner 
    {
        private Profile profile;
        private StreamWriter swout;
        private Scanner scanner;
        private AWSCredentials creds;


        public void Scan(string outputFile)
        {
            Console.WriteLine(String.Format("Writing to '{0}'", outputFile));
            swout = new StreamWriter(outputFile);
            swout.WriteLine("[");
            try
            {
                this.scanner = new Scanner
                {
                    MaxTasks = Configuration.Instance.ConcurrentConnecitons,
                    TimeOut = Configuration.Instance.Timeout
                };
                this.scanner.Progress.ProgressChanged += Progress_ProgressChanged;

                this.creds = Configuration.Instance.GetCredentials();
                if (creds == null)
                {
                    throw new ApplicationException(String.Format("No credentials provided. Edit in configuration file: '{0}'",
                        Configuration.Instance.ConfigFileName));
                }                
                this.profile = Profile.Load(Configuration.Instance.Profile);
                QueueOperations();
                Console.WriteLine("Scanning...");
                this.scanner.Scan();               
            }
            finally
            {
                swout.WriteLine("]");
                swout.Close();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void Progress_ProgressChanged(object sender, OperationResult e)
        {
            Console.WriteLine(String.Format("{0} {1} {2}: {3}",
                e.Operation.ServiceName, e.Operation.Name, e.Operation.Region.SystemName, e.ResultText()));
            if (!e.IsError())
            {
                foreach (CloudObject cobo in e.Operation.CollectedObjects)
                {
                    swout.WriteLine("" +
                        "  {" +
                        "  \"Type\" : \"" + cobo.TypeName + "\",");
                    swout.WriteLine(
                            "  \"Source\" : " + cobo.Source + ",},");

                }
                swout.Flush();
            }
        }

        private void QueueOperations()
        {
            Console.Write(String.Format("Queueing from '{0}' profile...", this.profile.Name));
            foreach (ProfileRecord p in this.profile)
            {
                if (p.Enabled)
                {
                    Operation op = Profile.FindOpeartion(p);
                    if (op != null)
                    {
                        WebProxy proxy = Configuration.Instance.GetWebProxy();
                        foreach (RegionEndpoint region in RegionsString.ParseSystemNames(p.Regions).Items)
                        {
                            scanner.Invokations.Enqueue(op.Clone(proxy, region, this.creds, p.PageSize));
                        }
                    }
                }
            }
            Console.WriteLine(String.Format("{0} operations queued.", scanner.Invokations.Count));
        }
    }
}