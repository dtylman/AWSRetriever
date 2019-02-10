using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;

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
        private string configFileName;

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

        public static string DefaultFileName
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AWSRetriever", "config.js");
            }
        }

        public string ConfigFileName { get => configFileName; set => configFileName = value; }

        private static Configuration instance;

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



        public static void Load(string configFileName)
        {
            try
            {

                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(configFileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    instance = serializer.Deserialize<Configuration>(reader);
                    instance.ConfigFileName = configFileName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                instance = new Configuration();
            }
        }

        public WebProxy GetWebProxy()
        {
            if (string.IsNullOrEmpty(Instance.ProxyHost))
            {
                return null;
            }
            return new WebProxy(Instance.ProxyHost, Instance.ProxyPort)
            {
                Credentials = new NetworkCredential(Instance.ProxyUser, Instance.ProxyPassword)
            };
        }

        public AWSCredentials GetCredentials()
        {
            if (!string.IsNullOrEmpty(this.AccessKeyID) && (!string.IsNullOrEmpty(this.SecretAccessKey)))
            {
                return new BasicAWSCredentials(this.AccessKeyID, this.SecretAccessKey);
            }
            else if (!string.IsNullOrEmpty(this.awsUser))
            {
                SharedCredentialsFile credentialsFile = new SharedCredentialsFile();
                if (!credentialsFile.TryGetProfile(awsUser, out CredentialProfile credentialProfile))
                {
                    throw new ApplicationException(string.Format("Profile '{0}' does not exists", awsUser));
                }
                if (!AWSCredentialsFactory.TryGetAWSCredentials(credentialProfile, credentialsFile, out AWSCredentials credentials))
                {
                    throw new ApplicationException(string.Format("Failed to get credentials for profile '{0}'", awsUser));
                }
                return credentials;
            }
            else
            {
                return FallbackCredentialsFactory.GetCredentials();
            }
        }
    }
}