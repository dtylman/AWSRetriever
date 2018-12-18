using System;
using System.Collections.Generic;
using System.ComponentModel;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using heaven.APIs;

namespace heaven
{
    internal class ResourceLoader
    {
        private readonly List<AWSAPI> apis = new List<AWSAPI>();
        private string accessKey = "danny";
        private string secretKey = "bunny";
        private int maxItems = 100;
        private readonly List<AWSObject> objects = new List<AWSObject>();

        public string AccessKey { get => accessKey; set => accessKey = value; }
        public string SecretKey { get => secretKey; set => secretKey = value; }
        public int MaxItems { get => maxItems; set => maxItems = value; }

        public ResourceLoader()
        {            
            this.apis.Add(new AWSLambdaAPI(this.objects,this.MaxItems));
        }

        internal void Load(BackgroundWorker worker, DoWorkEventArgs e)
        {
            this.objects.Clear();
            AWSCredentials creds = GetCredentials();
            List<RegionEndpoint> regions = new List<RegionEndpoint>(RegionEndpoint.EnumerableAllRegions);
            int totalItems = this.apis.Count * regions.Count;
            int currentItem = 0;
            foreach (AWSAPI api in this.apis)
            {                
                foreach (RegionEndpoint region in regions)
                {                    
                    int progress = (currentItem * 100 )/ totalItems ;
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
            worker.ReportProgress(100, "Done");
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
    