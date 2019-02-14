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
            if ( (type==null) || (obj==null) || string.IsNullOrEmpty(suffix))
            {
                return;
            }
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (p.CanRead)
                {
                    if (p.Name.EndsWith(suffix))
                    {
                        var val = p.GetValue(obj);
                        if (val != null)
                        {
                            Add(p.Name, val.ToString());
                        }
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