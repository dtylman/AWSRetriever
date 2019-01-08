using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using CloudOps;
using Newtonsoft.Json;

namespace Retriever
{
    namespace Model
    {
        public class CloudObjects : List<CloudObject>
        {
            public void Save()
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter("objects.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, this);
                }
            }

            public static CloudObjects Load()
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader("objects.json"))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<CloudObjects>(reader);
                }

            }

            public void RetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
            {                
                CloudObject cobo = this[e.ItemIndex];
                e.Item = new ListViewItem(cobo.Service);
                e.Item.SubItems.Add(cobo.TypeName);
                e.Item.SubItems.Add(cobo.Region);                
                e.Item.SubItems.Add(cobo.Names.FirstValue);
                e.Item.SubItems.Add(cobo.Ids.FirstValue);
                e.Item.SubItems.Add(cobo.Arns.FirstValue);
                e.Item.Tag = cobo;

            }

            public void Update(InvokationResult ir)
            {
                if (ir.IsError())
                {
                    return;
                }
                foreach (CloudObject cobo in ir.Operation.CollectedObjects)
                {
                    CloudObject exists = this.FirstOrDefault(item => item.Source.Equals(cobo.Source));
                    if (exists == null)
                    {
                        Add(cobo);
                    }
                }
            }
            
        }
    }
}