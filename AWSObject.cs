using Amazon;

namespace heaven
{
    internal class AWSObject
    {
        public string Arn;
        public string Description;
        public RegionEndpoint Region;
        public object Object;
        public string LastModified;
        public string Version;
        public string Role;

        public AWSObject()
        {
        }
    }
}