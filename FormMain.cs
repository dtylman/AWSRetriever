using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Amazon;
using Amazon.Runtime;
using AWSRetriver.Controls;
using CloudOps;
using Retriever.Model;
using Retriever.Properties;

namespace Retriever
{
    public partial class FormMain : Form
    {
        private AWSCredentials creds;
        private Scanner scanner;        
        private Profile profile;
        private CloudObjects cloudObjects = new CloudObjects();
        private ProgressMessages progressMessages = new ProgressMessages();

        public FormMain()
        {
            InitializeComponent();

            InitializeBackgroundWorker();
            scanner = new Scanner
            {
                MaxTasks = Settings.Default.ConcurrentConnecitons,
                TimeOut = Settings.Default.Timeout // 15 minutes default
            };
            scanner.Progress.ProgressChanged += Scanner_ProgressChanged;
        }

        #region background worker

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (creds == null)
            {
                throw new ApplicationException("No Credentials are provided");
            }

            try
            {              
                scanner.Scan();
                // TODO: make sure all background events are processed (don't sure where i am missing a mutex...)                
                Thread.Sleep(1000);
            }
            finally
            {
                backgroundWorker.ReportProgress(100, "Done");
            }
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is InvokationResult ir)
            {
                this.cloudObjects.Update(ir);
                this.listViewFound.VirtualListSize = this.cloudObjects.Count;
                this.progressMessages.Add(new ProgressMessage(ir));
                this.listViewMessages.VirtualListSize = this.progressMessages.Count;
                listViewMessages.EnsureVisible(this.progressMessages.Count-1);
                UpdateStatusBar(ir);
            }
            else
            {
                //?!
                Console.WriteLine(e);
            }
        }


        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetStatus(e.Error);
                ShowErrorDiaglog(e.Error);
            }
            else if (e.Cancelled)
            {
                SetStatus("Canceled");
                this.progressBar.Value = 0;
            }
            else
            {
                SetStatus("Done");
            }

            buttonScan.Enabled = true;
            buttonStop.Enabled = false;

            FormAction("Saving objects...", cloudObjects.Save);
        }

        #endregion

        private void UpdateStatusBar(InvokationResult ir)
        {
            this.progressBar.Value = ir.Progress;
            this.statusLabel.Text = ir.ResultText();
        }

        private void ShowErrorDiaglog(Exception e)
        {
            MessageBox.Show("Error:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetStatus(Exception e)
        {
            SetStatus("Error: " + e.Message);
        }

        private void SetStatus(string message)
        {
            this.statusLabel.Text = message;

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void Scanner_ProgressChanged(object sender, InvokationResult e)
        {
            if (backgroundWorker.CancellationPending)
            {
                return;
            }
            if (backgroundWorker.IsBusy) // only when it is working...
            {
                backgroundWorker.ReportProgress(e.Progress, e);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (this.creds == null)
            {
                ShowCredentialsDialog();
            }
            statusLabel.Text = String.Empty;
            this.buttonScan.Enabled = false;
            this.buttonStop.Enabled = true;
            this.listViewFound.Items.Clear();
            this.listViewMessages.Items.Clear();
            QueueItems();
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void QueueItems()
        {
            backgroundWorker.ReportProgress(0, "Queuing items...");
            foreach (ProfileRecord p in this.profile)
            {
                if (p.Enabled)
                {
                    Operation op = Profile.FindOpeartion(p);
                    if (op != null)
                    {
                        foreach (RegionEndpoint region in RegionsString.ParseSystemNames(p.Regions).Items)
                        {
                            scanner.Invokations.Enqueue(new OperationInvokation(op, region, creds, p.PageSize));
                        }
                    }
                }
            }
        }

        private void ToolStripButtonStop_Click(object sender, EventArgs e)
        {
            this.scanner.Cancel();
        }

        private void MenuItemSetCredentials_Click(object sender, EventArgs e)
        {
            ShowCredentialsDialog();
        }

        private void ShowCredentialsDialog()
        {
            FormCredentials formCredentials = new FormCredentials();
            DialogResult dr = formCredentials.ShowDialog(this);
            if (dr == DialogResult.OK)
            {                
                this.creds = formCredentials.Credentials;
                if (formCredentials.SaveCredentials)
                {
                    Settings.Default.SecretAccessKey = this.creds.GetCredentials().AccessKey;
                    Settings.Default.SettingsKey = this.creds.GetCredentials().SecretKey;
                    Settings.Default.Save();
                }
            }
        }

        private void ViewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowErrorDiaglog(new NotImplementedException());
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void ShowAboutBox()
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void ListViewFound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewFound.SelectedIndices.Count > 0)
            {
                CloudObject cobo = this.cloudObjects[this.listViewFound.SelectedIndices[0]];                
                this.propertyGridObject.SelectedObject = cobo;
                this.richTextBoxCobo.Text = cobo.Source;
            }
        }

        private void BtnManageProfiles_Click(object sender, EventArgs e)
        {
            ShowProfileDialog();
        }

        private void ShowProfileDialog()
        {
            FormProfiles formProfiles = new FormProfiles();
            formProfiles.Profile = this.profile;
            formProfiles.ShowDialog();
            FormAction("Saving profile", profile.Save);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormAction("Loading profile...", LoadProfileFromFile, false);
            FormAction("Loading objects..", LoadObjectsFromFile, false);
            FormAction("Loading messages..", LoadMessagesFromFile, false);
        }

        private void LoadMessagesFromFile()
        {
            try
            {
                this.progressMessages = ProgressMessages.Load();
                this.listViewMessages.VirtualListSize = this.progressMessages.Count;
            }
            catch (Exception)
            {
                this.progressMessages = new ProgressMessages();
                throw;
            }
        }

        private void LoadObjectsFromFile()
        {
            try
            {
                this.cloudObjects = CloudObjects.Load();
                this.listViewFound.VirtualListSize = this.cloudObjects.Count;
            }
            catch(Exception)
            {
                this.cloudObjects = new CloudObjects();
                throw;
            }
            
        }

        private void FormAction(string status, Action action, bool showMessageBox = true)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetStatus(status);
            try
            {
                action.Invoke();
                SetStatus("Ready");
            }
            catch (Exception ex)
            {
                if (showMessageBox)
                {
                    ShowErrorDiaglog(ex);
                }
                else
                {
                    SetStatus(ex.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;                
            }
        }
       
        private void LoadProfileFromFile()
        {
            try
            {
                this.profile = Profile.Load("default");
            }
            catch (Exception ex)
            {
                SetStatus(String.Format("Failed to load profile: %v, creating new", ex.Message));
                this.profile = Profile.AllServices();                
            }
            finally
            {
                this.txtProfileName.Text = this.profile.Name;
            }
        }

       

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            FormRun form = new FormRun();
            form.Profile = this.profile;
            DialogResult dr = form.ShowDialog();
            if (form.Operation == null)
            {
                SetStatus(new ApplicationException("No opeation selected"));
                return;
            }
            if (dr == DialogResult.OK)
            {
                if (this.creds == null)
                {
                    ShowCredentialsDialog();
                }
                foreach (var region in form.SelectedRegions)
                {                      
                    scanner.Invokations.Enqueue(new OperationInvokation(form.Operation, region, this.creds, Settings.Default.PageSize));
                }                                    
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }


        private void ListViewFound_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            cloudObjects.RetrieveVirtualItem(e);
        }

        private void ListViewMessages_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            progressMessages.RetrieveVirtualItem(e);
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cloudObjects.Clear();
            listViewFound.VirtualListSize = 0;
        }

        private void ClearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            progressMessages.Clear();
            listViewMessages.VirtualListSize = 0;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.progressMessages.Save();
        }

        private void ViewInProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
