using System;
using System.Collections.Generic;
using Amazon;
using CloudOps;

namespace heaven
{
    public class Profile : List<ProfileRecord>
    {
        public string Name { get; private set; }

        public static Profile AllServices()
        {
            Profile p = new Profile()
            {
                Name = "Default"
            };            
            var regions = string.Join(" ", RegionEndpoint.EnumerableAllRegions);            
            foreach (Operation op in OperationFactory.All())
            {
                p.Add(new ProfileRecord(op.ServiceName, op.Name, regions));
            }

            return p;
        }

        public IEnumerable<string> Services()
        {
            HashSet<string> items = new HashSet<string>();
            foreach (ProfileRecord profileRecord in this)
            {
                items.Add(profileRecord.ServiceName);
            }
            return items;
        }
    }
}