using System;
using System.Collections.Generic;
using Amazon;
using CloudOps;

namespace heaven
{
    public class Profile
    {
        private readonly Dictionary<string, ProfileService> services = new Dictionary<string, ProfileService>();

        public Profile()
        {
            
        }

        public Dictionary<string, ProfileService> Services => services;

        public void Set(string serviceName, Operation op, string region, bool enabled)
        {
            if (this.services.ContainsKey(serviceName))
            {
                this.services[serviceName].Set(op, region, enabled);
            } else
            {
                this.services.Add(serviceName, new ProfileService(op, region, enabled));
            }
        }

        public static Profile Everything()
        {
            Profile p = new Profile();
            foreach (Operation op in OperationFactory.All())
            {
                foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
                {
                    p.Set(op.ServiceName, op, region.SystemName, true);
                }
            }
            return p;
        }
    }
}