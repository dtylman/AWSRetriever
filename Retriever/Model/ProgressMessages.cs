using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Retriever
{
    namespace Model
    {
        public class ProgressMessages : List<ProgressMessage>
        {
            public void RetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
            {
                ProgressMessage pm = this[e.ItemIndex];
                e.Item = new ListViewItem(pm.Time.ToString());
                e.Item.SubItems.Add(pm.Operation);
                e.Item.SubItems.Add(pm.Service);
                e.Item.SubItems.Add(pm.Region);
                e.Item.SubItems.Add(pm.Result);
                e.Item.ImageIndex = pm.ImageIndex;
            }

            [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
            internal static ProgressMessages Load()
            {
                JsonSerializer serializer = new JsonSerializer();
                StreamReader sr = new StreamReader("messages.json");
                try
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        return serializer.Deserialize<ProgressMessages>(reader);
                    }
                }
                finally
                {
                    sr.Close();
                }
            }

            [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
            internal void Save()
            {
                JsonSerializer serializer = new JsonSerializer();
                StreamWriter sw = new StreamWriter("messages.json");
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
        }
    }
}
