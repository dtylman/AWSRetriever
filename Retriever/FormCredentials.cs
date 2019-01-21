using System;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using NickAc.ModernUIDoneRight.Forms;
using Retriever.Properties;

namespace Retriever
{
    public partial class FormCredentials : ModernForm
    {
        public FormCredentials()
        {
            InitializeComponent();
            this.cmbProfile.Items.AddRange(new SharedCredentialsFile().ListProfileNames().ToArray());
        }

        /// <summary>
        /// Gets the credentials from the GUI
        /// </summary>
        /// <value>The credentials.</value>
        public AWSCredentials Credentials
        {
            get
            {
                if (!string.IsNullOrEmpty(this.AccessKeyID) && (!string.IsNullOrEmpty(this.SecretAccessKey)))
                {
                    return new BasicAWSCredentials(this.AccessKeyID, this.SecretAccessKey);
                }
                else if (!string.IsNullOrEmpty(this.ProfileName))
                {
                    SharedCredentialsFile credentialsFile = new SharedCredentialsFile();
                    if (!credentialsFile.TryGetProfile(ProfileName, out CredentialProfile credentialProfile))
                    {
                        throw new ApplicationException(string.Format("Profile '{0}' does not exists", ProfileName));
                    }
                    if (!AWSCredentialsFactory.TryGetAWSCredentials(credentialProfile, credentialsFile, out AWSCredentials credentials))
                    {
                        throw new ApplicationException(string.Format("Failed to get credentials for profile '{0}'", ProfileName));
                    }
                    return credentials;
                }
                else
                {
                    return FallbackCredentialsFactory.GetCredentials();
                }
            }
        }

        public string AccessKeyID
        {
            get
            {
                return this.txtAccessKeyID.Text;
            }
        }

        public string SecretAccessKey
        {
            get
            {
                return this.txtSecretAccessKey.Text;
            }
        }

        public string ProfileName
        {
            get
            {
                if (cmbProfile.SelectedItem == null)
                {
                    return "";
                }
                return cmbProfile.SelectedItem.ToString();
            }
        }

        private void FormCredentials_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Configuration.Instance.SecretAccessKey))
            {
                this.txtSecretAccessKey.Text = Configuration.Instance.SecretAccessKey;
            }
            if (!string.IsNullOrEmpty(Configuration.Instance.AccessKeyID))
            {
                this.txtAccessKeyID.Text = Configuration.Instance.AccessKeyID;
            }
            if (!string.IsNullOrEmpty(Configuration.Instance.AwsUser))
            {
                this.cmbProfile.Text = Configuration.Instance.AwsUser;
            }
        }

        private void modernButton1_Click(object sender, EventArgs e)
        {
            if (this.checkBoxSave.Checked)
            {
                Configuration.Instance.AccessKeyID= this.txtAccessKeyID.Text; 
                Configuration.Instance.SecretAccessKey = this.txtSecretAccessKey.Text; 
                Configuration.Instance.AwsUser = this.cmbProfile.Text;
                Configuration.Instance.Save();
            }
        }
    }
}        
