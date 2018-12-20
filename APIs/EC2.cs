using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace heaven.APIs
{
    internal class EC2 : AWSService
    {
        public EC2(List<AWSObject> list, int maxItems) : base(list, maxItems)
        {
        }

        public override string Name
        {
            get
            {
                return "EC2";
            }
        }

        public override void Scan(AWSCredentials credentials, RegionEndpoint region, BackgroundWorker worker, int currentProgress)
        {
            AmazonEC2Client client = new AmazonEC2Client(credentials, region);
            DescribeInstance(region, client);
            worker.ReportProgress(currentProgress, "Key pairs;");
            DescribeKeyPairs(region, client);
            worker.ReportProgress(currentProgress, "Volumes;");
            DescribeVolumes(region, client);
        }

        private void DescribeVolumes(RegionEndpoint region, AmazonEC2Client client)
        {
            DescribeVolumesResponse resp = new DescribeVolumesResponse();
            do
            {
                DescribeVolumesRequest req = new DescribeVolumesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = this.maxItems
                };
                resp = client.DescribeVolumes(req);
                CheckError(resp.HttpStatusCode, resp);
                foreach (Volume volume in resp.Volumes)
                {
                    AWSObject awsobject = new AWSObject
                    {
                        Region = region.SystemName,
                        Name = volume.VolumeId,
                        Description = volume.Size.ToString(),
                        LastModified = volume.CreateTime.ToString()
                    };
                    AddObject(awsobject, volume);
                }
            } while (!string.IsNullOrEmpty(resp.NextToken));
        }

        private void DescribeKeyPairs(RegionEndpoint region, AmazonEC2Client client)
        {
            DescribeKeyPairsResponse resp = client.DescribeKeyPairs();
            CheckError(resp.HttpStatusCode, resp);
            foreach (KeyPairInfo kp in resp.KeyPairs)
            {
                AWSObject awsobject = new AWSObject
                {
                    Region = region.SystemName,
                    Name = kp.KeyName,
                    Description = kp.KeyFingerprint
                };
                AddObject(awsobject, kp);
            }
        }

        private void DescribeInstance(RegionEndpoint region, AmazonEC2Client client)
        {
            DescribeInstancesResponse resp = new DescribeInstancesResponse();
            do
            {
                DescribeInstancesRequest req = new DescribeInstancesRequest
                {
                    MaxResults = this.maxItems,
                    NextToken = resp.NextToken
                };
                resp = client.DescribeInstances(req);
                CheckError(resp.HttpStatusCode, resp);
                foreach (Reservation reservation in resp.Reservations)
                {
                    foreach (Instance instance in reservation.Instances)
                    {
                        AWSObject awsobject = new AWSObject
                        {
                            Region = region.SystemName,
                            Name = instance.ImageId,
                            Arn = "",
                            Description = String.Format("{0} {1} {2}", instance.Platform, instance.PublicDnsName, instance.VirtualizationType),
                            LastModified = instance.LaunchTime.ToString(),
                            Version = "",
                            Role = reservation.OwnerId
                        };
                        AddObject(awsobject, instance);
                    }
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }


}
