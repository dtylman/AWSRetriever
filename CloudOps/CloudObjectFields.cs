using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace CloudOps
{
    public class CloudObjectFields : Dictionary<string, string>
    {        
        public CloudObjectFields()
        {

        }

        public CloudObjectFields(Type type, object obj, string suffix)
        {
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (p.CanRead)
                {
                    if (p.Name.EndsWith(suffix))
                    {
                        Add(p.Name, p.GetValue(obj).ToString());
                    }
                }

            }
        }

        public string FirstValue
        {
            get
            {
                if (Count == 0)
                {
                    return "";
                }
                return this.First().Value;
            }
        }
    }
}