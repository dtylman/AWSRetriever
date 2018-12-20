using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System.Linq;

namespace heaven.APIs
{
    internal class AWSS3API : AWSAPI
    {
        public AWSS3API(List<AWSObject> container, int maxItems) : base(container, maxItems)
        {
        }

        public override string Name {
            get
            {
                return "S3: ListBuckets";
            }
        }

        public override void Read(AWSCredentials credentials, RegionEndpoint region)
        {           
            AmazonS3Client client = new AmazonS3Client(credentials, region);            
            ListBucketsResponse resp = client.ListBuckets();
            if (resp.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ApplicationException(resp.ToString());
            }
            foreach (var buck in resp.Buckets)
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
                        Object = buck
                    };
                    AddObject(awsObject);
                }
            }
        }
    }
}