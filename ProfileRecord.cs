
namespace heaven
{
    public class ProfileRecord
    {
        private string serviceName;
        private string name;
        private string regions;

        public ProfileRecord(string serviceName, string name, string regions)
        {
            this.serviceName = serviceName;
            this.name = name;
            this.regions = regions;
        }

        public string ServiceName { get => serviceName; set => serviceName = value; }
        public string Name { get => name; set => name = value; }
        public string Regions { get => regions; set => regions = value; }
    }
}