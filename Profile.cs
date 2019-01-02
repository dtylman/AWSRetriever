using System;
using System.Collections.Generic;
using Amazon;
using CloudOps;

namespace heaven
{
    public class Profile : List<ProfileRecord>
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public static Profile AllServices()
        {
            Profile p = new Profile()
            {
                name = "Default"
            };
            string regions = RegionsString.All().Text();
            foreach (Operation op in OperationFactory.All())
            {
                p.Add(new ProfileRecord(op.ServiceName, op.Name, regions, true));
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

        public static Operation FindOpeartion(ProfileRecord p)
        {
            foreach (Operation op in OperationFactory.All())
            {
                if (op.ServiceName == p.ServiceName)
                {
                    if (op.Name == p.Name)
                    {
                        return op;
                    }
                }
            }
            return null;
        }

        public void Set(ProfileRecord p)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Name == p.Name)
                {
                    if (this[i].ServiceName == p.ServiceName)
                    {
                        this[i] = p;
                        return;
                    }
                }
            }
        }

        public void EnableRegion(string region, bool enabled)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].EnableRegion(region, enabled);
            }
        }
    }
}