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
                Save("objects.json");
            }
            
            public void Save(string fileName)
            {
                JsonSerializer serializer = new JsonSerializer();
                StreamWriter sw = new StreamWriter(fileName);
                try
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        writer.Formatting = Formatting.Indented;
                        serializer.Serialize(writer, this);
                    }
                }
                finally
                {
                    sw.Close();
                }
            }

            
            public static CloudObjects Load()
            {
                JsonSerializer serializer = new JsonSerializer();
                StreamReader sr = new StreamReader("objects.json");
                try
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        return serializer.Deserialize<CloudObjects>(reader);
                    }
                }
                finally
                {
                    sr.Close();
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

            public void Update(OperationResult ir)
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

            /// <summary>
            /// Save only the AWS objects to a file specified by filename
            /// </summary>
            /// <param name="fileName"></param>
            public void Export(string fileName)
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("[")                        ;
                    foreach (CloudObject cobo in this)
                    {
                        sw.WriteLine("" +
                            "  {" +
                            "  \"Type\" : \"" + cobo.TypeName + "\",");
                        sw.WriteLine(                         
                            "  \"Source\" : " + cobo.Source + ",},");
                    }
                    sw.WriteLine("]");
                }
            }
        }
    }
}