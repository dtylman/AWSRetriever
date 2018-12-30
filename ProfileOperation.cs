using CloudOps;
using System;
using System.Collections.Generic;

namespace heaven
{
    public class ProfileOperation
    {
        private readonly Dictionary<string, bool> regions = new Dictionary<string, bool>();
        private Operation operation;

        public ProfileOperation(Operation op, string region, bool enabled)
        {
            this.operation = op;
            this.regions[region] = enabled;
        }

        public Operation Operation { get => operation;  }

        public Dictionary<string, bool> Regions => regions;

        public bool Enabled
        {
            set
            {
                foreach (KeyValuePair<string, bool> item in regions)
                {
                    regions[item.Key] = value;
                }
            }
        }

        public void Set(Operation op,  string region, bool enabled)
        {
            this.operation = op;
            this.regions[region] = enabled;
        }
    }
}