using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heaven
{
    public partial class FormMain : Form
    {
        private string _accessKey;
        private string _secretKey;
        private string _profileName;
        private string _profilesLocation;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AWSCredentials credentials = null;
            if (!string.IsNullOrEmpty(this._accessKey))
            {
                credentials = new BasicAWSCredentials(this._accessKey, this._secretKey);
            }
            CredentialProfile basicProfile;
            AWSCredentials awsCredentials;
            var sharedFile = new SharedCredentialsFile();
            if (!string.IsNullOrEmpty(this._profileName))
            {
                if (!string.IsNullOrEmpty(this._profilesLocation))
                {

                }
                AWSCredentialsFactory.TryGetAWSCredentials(_profileName, out basicProfile);
            }
            sharedFile.TryGetProfile(SharedCredentialsFile.DefaultProfileName)
            if (sharedFile.TryGetProfile("basic_profile", out basicProfile) &&
                AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out awsCredentials))
            {
                using (var client = new AmazonS3Client(awsCredentials, basicProfile.Region))
                {
                    var response = client.ListBuckets();
                }
            }
            var client = new AmazonCloudFormationClient();
            var request = new DescribeStacksRequest();
            var response = client.DescribeStacks(request);

            foreach (var stack in response.Stacks)
            {
                Console.WriteLine("Stack: {0}", stack.StackName);
                Console.WriteLine("  Status: {0}", stack.StackStatus);
                Console.WriteLine("  Created: {0}", stack.CreationTime);

                var ps = stack.Parameters;

                if (ps.Any())
                {
                    Console.WriteLine("  Parameters:");

                    foreach (var p in ps)
                    {
                        Console.WriteLine("    {0} = {1}",
                          p.ParameterKey, p.ParameterValue);
                    }

                }

            }
        }
    }
}
