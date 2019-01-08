using System.Collections.Generic;
using System.IO;
using CloudOps;
using Retriever.Properties;
using Newtonsoft.Json;
using AWSRetriver.Controls;

namespace Retriever
{
    namespace Model
    {
        public class Profile : List<ProfileRecord>
        {
            private string name;

            public string Name { get => name; set => name = value; }

            public Profile()
            {

            }

            public static Profile AllServices()
            {
                Profile p = new Profile()
                {
                    name = "Default"
                };
                string regions = RegionsString.All().Text();
                foreach (Operation op in OperationFactory.All())
                {
                    p.Add(new ProfileRecord(op.ServiceName, op.Name, regions, true, Settings.Default.PageSize));
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

            public ProfileRecord Find(string service, string operation)
            {
                foreach (ProfileRecord pr in this)
                {
                    if (pr.ServiceName == service)
                    {
                        if (pr.Name == operation)
                        {
                            return pr;
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

            public void Save()
            {
                Save("");
            }

            public void Save(string fileName)
            {
                string outFileName = fileName;
                if (fileName == "")
                {
                    if ((this.name == null) || (this.name == ""))
                    {
                        this.name = "Default";
                    }
                    outFileName = this.Name + ".json";
                }
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(outFileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, this);
                }
            }

            public static Profile Load(string fileName)
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(fileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<Profile>(reader);
                }
            }
        }
    }
}