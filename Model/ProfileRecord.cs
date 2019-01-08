using AWSRetriver.Controls;

namespace Retriever
{
    namespace Model
    {
        public class ProfileRecord
        {
            private string serviceName;
            private string name;
            private string regions;
            private bool enabled;
            private int pageSize;

            public ProfileRecord()
            {

            }

            public ProfileRecord(string serviceName, string name, string regions, bool enabled, int pageSize)
            {
                this.serviceName = serviceName;
                this.name = name;
                this.regions = regions;
                this.enabled = enabled;
                this.pageSize = pageSize;
            }

            public string ServiceName { get => serviceName; set => serviceName = value; }
            public string Name { get => name; set => name = value; }
            public string Regions { get => regions; set => regions = value; }
            public bool Enabled { get => enabled; set => enabled = value; }
            public int PageSize { get => pageSize; set => pageSize = value; }

            public void EnableRegion(string region, bool enabled)
            {
                RegionsString rs = RegionsString.ParseSystemNames(this.regions);
                if (enabled)
                {
                    rs.AddSystemName(region);
                }
                else
                {
                    rs.RemoveSystemName(region);
                }
                this.regions = rs.Text();
            }
        }
    }
}