using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;

namespace Retriever
{
    public class Configuration
    {
        private string accessKeyID;
        private string secretAccessKey;
        private int pageSize = 18;
        private int concurrentConnecitons = 15;
        private int timeout = 900000;
        private string profile = "default.profile.js";
        private string awsUser;
        private string proxyHost;
        private int proxyPort = 1080;
        private string proxyUser;
        private string proxyPassword;

        public static Configuration Instance { get => instance; }

        [Category("AWS")]
        [Description("AWS Access Key ID")]
        [PasswordPropertyText(true)]
        public string AccessKeyID { get => accessKeyID; set => accessKeyID = value; }
        [Category("AWS")]
        [Description("AWS Secret Key")]
        [PasswordPropertyText(true)]
        public string SecretAccessKey { get => secretAccessKey; set => secretAccessKey = value; }
        [Category("AWS")]
        [Description("AWS User Profle to use")]
        public string AwsUser { get => awsUser; set => awsUser = value; }
        [Category("AWS")]
        [Description("Default Page Size for Pagination Request (can be overriden by Profile)")]        
        public int PageSize { get => pageSize; set => pageSize = value; }

        [Category("Connection")]
        [Description("Number of concurrent connections when scanning.")]        
        public int ConcurrentConnecitons { get => concurrentConnecitons; set => concurrentConnecitons = value; }
        [Category("Connection")]
        [Description("API call timeout")]
        public int Timeout { get => timeout; set => timeout = value; }
        [Category("Connection")]
        [Description("Proxy Hostname to use")]
        public string ProxyHost { get => proxyHost; set => proxyHost = value; }
        [Category("Connection")]
        [Description("Proxy Port")]
        public int ProxyPort { get => proxyPort; set => proxyPort = value; }
        [Category("Connection")]
        [Description("Proxy Authentication User")]
        public string ProxyUser { get => proxyUser; set => proxyUser = value; }
        [Category("Connection")]
        [Description("Proxy Authentication Password")]
        [PasswordPropertyText(true)]
        public string ProxyPassword { get => proxyPassword; set => proxyPassword = value; }

        [Category("Profile")]
        [Description("Default profile file to load at startup")]
        public string Profile { get => profile; set => profile = value; }

        private static Configuration instance;        

        public static String ConfigFileName
        {
            get
            {                
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AWSRetriever","config.js");
            }
        }

        public void Save()
        {
            string dirName = Path.GetDirectoryName(ConfigFileName);
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(ConfigFileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, this);
            }
        }

      

        public static void Load()
        {
            try
            {

                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(ConfigFileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    instance = serializer.Deserialize<Configuration>(reader);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                instance = new Configuration();
            }            
        }
    }
}