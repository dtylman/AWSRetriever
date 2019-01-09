using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CloudOps;
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

            internal static ProgressMessages Load()
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader("messages.json"))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<ProgressMessages>(reader);
                }
            }

            internal void Save()
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter("messages.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, this);
                }
            }
        }
    }
}

/*
 * string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "SaveFileDialog Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    AppSerializer.SaveListView(filename, listViewMessages);                    
                }

            }
            
     
       public void Save()
            {
              
            }

            public static CloudObjects Load()
            {
               

            }
     
     
     */
