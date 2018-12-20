using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System.Linq;
using System.ComponentModel;

namespace heaven.APIs
{
    internal class S3 : AWSService
    {
        public S3(List<AWSObject> container, int maxItems) : base(container, maxItems)
        {
        }

        public override string Name {
            get
            {
                return "S3";
            }
        }

        public override void Scan(AWSCredentials credentials, RegionEndpoint region, BackgroundWorker worker, int currentProgress)
        {           
            AmazonS3Client client = new AmazonS3Client(credentials, region);            
            ListBucketsResponse resp = client.ListBuckets();

            CheckError(resp.HttpStatusCode, resp);
            foreach (S3Bucket buck in resp.Buckets)
            {
                // if bucket already exists, don't add it...
                AWSObject awsObject = this.list.FirstOrDefault(item => item.Name == buck.BucketName);
                if (awsObject == null)
                {
                    awsObject = new AWSObject
                    {
                        Name = buck.BucketName,
                        Region = region.SystemName,
                        LastModified = buck.CreationDate.ToString(),
                    };
                    AddObject(awsObject,buck);
                }
            }
        }
    }
}