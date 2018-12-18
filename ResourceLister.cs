using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using heaven.APIs;
using Newtonsoft.Json;

namespace heaven
{
    internal class ResourceLoader
    {
        private readonly List<AWSAPI> apis = new List<AWSAPI>();
        private string accessKey;
        private string secretKey;
        private int maxItems = 100;
        private readonly List<AWSObject> objects = new List<AWSObject>();

        public string AccessKey { get => accessKey; set => accessKey = value; }


        public string SecretKey { get => secretKey; set => secretKey = value; }
        public int MaxItems { get => maxItems; set => maxItems = value; }

        public IEnumerable<AWSObject> Objects
        {
            get
            {
                return this.objects;
            }
        }

        public ResourceLoader()
        {
            this.apis.Add(new AWSLambdaAPI(this.objects, this.MaxItems));
            this.apis.Add(new AWSS3API(this.objects, this.maxItems));
            LoadFromFile();
        }


        internal void Load(BackgroundWorker worker, DoWorkEventArgs e)
        {
            this.objects.Clear();
            try
            {
                AWSCredentials creds = GetCredentials();
                List<RegionEndpoint> regions = new List<RegionEndpoint>(RegionEndpoint.EnumerableAllRegions);
                int totalItems = this.apis.Count * regions.Count;
                int currentItem = 0;
                foreach (AWSAPI api in this.apis)
                {
                    foreach (RegionEndpoint region in regions)
                    {
                        int progress = (currentItem * 100) / totalItems;
                        worker.ReportProgress(progress, string.Format("Fetching '{0}' from {1}", api.Name, region));
                        try
                        {
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                            api.Read(creds, region);
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
                worker.ReportProgress(100, "Done");
            }
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

        private AWSCredentials GetCredentials()
        {
            if (!string.IsNullOrEmpty(this.AccessKey))
            {
                return new BasicAWSCredentials(this.AccessKey, this.SecretKey);
            }
            return FallbackCredentialsFactory.GetCredentials();
        }


    }
}
