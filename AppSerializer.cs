using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CloudOps;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace heaven
{
    internal class AppSerializer
    {
        public void SaveCloudObjects(List<CloudObject> objects)
        {
            SharpSerializer serializer = new SharpSerializer(true);
            serializer.Serialize(objects, "objects.bin");
        }

        public List<CloudObject> LoadCloudObjects()
        {
            SharpSerializer serializer = new SharpSerializer(true);
            return (List<CloudObject>)serializer.Deserialize("objects.bin");
        }

        public Profile LoadProfile()
        {
            SharpSerializer serializer = new SharpSerializer();
            return (Profile)serializer.Deserialize("profile.xml");
        }

        public void SaveProfile(Profile profile)
        {
            SharpSerializer serializer = new SharpSerializer();
            serializer.Serialize(profile, "profile.xml");
        }

        public void SaveListView(string filename, ListView listView)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {

                foreach (ListViewItem item in listView.Items)
                {
                    StringBuilder line = new StringBuilder();
                    line.Append(item.Name);
                    line.Append(",");
                    foreach (var si in item.SubItems)
                    {
                        line.Append(si);
                        line.Append(",");
                    }
                }
            }
        }


    }
}