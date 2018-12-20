using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Amazon;
using Amazon.Runtime;
using Newtonsoft.Json;

namespace heaven.APIs
{
    internal class AWSResources
    {        
        private readonly List<AWSObject> objects = new List<AWSObject>();

        private int maxItems = 100;

        public int MaxItems { get => maxItems; set => maxItems = value; }

        public IEnumerable<AWSObject> Objects
        {
            get
            {
                return this.objects;
            }
        }

        public AWSResources()
        {
            LoadFromFile();
        }

        /// <summary>
        /// Connects to AWS and reads all resources
        /// </summary>
        /// <param name="creds">Creds.</param>
        /// <param name="worker">Worker.</param>
        /// <param name="e">E.</param>
        public void Scan(AWSCredentials creds, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (creds == null)
            {
                throw new ApplicationException("No Credentials are provided");
            }
            

            this.objects.Clear();
            try
            {
                List<AWSAPI> apis = GetSupportedAPIs();
                List<RegionEndpoint> regions = new List<RegionEndpoint>(RegionEndpoint.EnumerableAllRegions);
                int totalItems = apis.Count * regions.Count;
                int currentItem = 0;
                foreach (AWSAPI api in apis)
                {
                    foreach (RegionEndpoint region in regions)
                    {
                        int progress = (currentItem * 100) / totalItems;
                        worker.ReportProgress(progress, string.Format("Fetching '{0}' from {1}...", api.Name, region));
                        try
                        {
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                            int before = this.objects.Count;     
                            api.Read(creds, region);
                            worker.ReportProgress(progress, string.Format("{0} items read.\n", objects.Count - before));
                        }
                        catch (Exception ex)
                        {
                            worker.ReportProgress(progress, ex);
                        }
                        finally
                        {
                            currentItem++;
                        }
                    }
                    currentItem++;
                }
            }
            finally
            {
                SaveToFile(); 
                worker.ReportProgress(100, "Done\n");
            }
        }

        private List<AWSAPI> GetSupportedAPIs()
        {
            List<AWSAPI> apis = new List<AWSAPI>();
            apis.Add(new AWSLambdaAPI(this.objects, this.MaxItems));
            apis.Add(new AWSS3API(this.objects, this.maxItems));
            return apis;            
       }

        private void SaveToFile()
        {
            StreamWriter sw = new StreamWriter("objects.json", false);
            try
            {
                JsonWriter writer = new JsonTextWriter(sw);
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, this.objects);
                }
                finally
                {
                    writer.Close();
                }
            }
            finally
            {
                sw.Close();
            }

        }

        private void LoadFromFile()
        {
            try
            {
                StreamReader sr = new StreamReader("objects.json");
                try
                {
                    JsonReader reader = new JsonTextReader(sr);
                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<AWSObject> objs  = serializer.Deserialize<List<AWSObject>>(reader);
                        foreach (AWSObject o in objs){
                            this.objects.Add(o);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}