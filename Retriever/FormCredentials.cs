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
                if (!string.IsNullOrEmpty(this.AccessKey) && (!string.IsNullOrEmpty(this.SecretKey)))
                {
                    return new BasicAWSCredentials(this.AccessKey, this.SecretKey);
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

        public string AccessKey { get{
            return  this.txtAccessKey.Text;
        } }

        public string SecretKey { get {
            return this.txtSecretKey.Text;
        }}

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
            if (!string.IsNullOrEmpty(Settings.Default.SecretAccessKey))
            {
                this.txtSecretKey.Text = Settings.Default.SecretAccessKey;
            }
            if (!string.IsNullOrEmpty(Settings.Default.SettingsKey))
            {
                this.txtAccessKey.Text = Settings.Default.SettingsKey;
            }
            if (!string.IsNullOrEmpty(Settings.Default.AWSUser))
            {
                this.cmbProfile.Text = Settings.Default.AWSUser;
            }
        }

        private void modernButton1_Click(object sender, EventArgs e)
        {
            if (this.checkBoxSave.Checked)
            {
                Settings.Default.SecretAccessKey = this.txtSecretKey.Text;
                Settings.Default.SettingsKey = this.txtAccessKey.Text;
                Settings.Default.AWSUser = this.cmbProfile.Text;
                Settings.Default.Save();
            }
        }
    }
}        
