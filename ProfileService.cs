using CloudOps;
using System;
using System.Collections.Generic;

namespace heaven
{
    public class ProfileService
    {
        private readonly Dictionary<string, ProfileOperation> operations = new Dictionary<string, ProfileOperation>();

        public ProfileService(Operation op, string region, bool enabled)
        {
            Set(op, region, enabled);
        }

        public Dictionary<string, ProfileOperation> Operations { get => operations; }

        public void Set(Operation op, string region, bool enabled)
        {
            if (this.operations.ContainsKey(op.Name))
            {
                this.operations[op.Name].Set(op, region, enabled);
            } else
            {
                this.operations.Add(op.Name, new ProfileOperation(op, region, enabled));
            }
        }
    }
}