using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Amazon;
using Amazon.Runtime;
using AWSRetriver.Controls;
using CloudOps;
using NickAc.ModernUIDoneRight;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;
using Retriever.Model;
using Retriever.Properties;
using NickAc.ModernUIDoneRight.Controls;

namespace Retriever
{
    public partial class FormMain : ModernForm
    {
        private AWSCredentials creds;
        private Scanner scanner;
        private Profile profile;
        private CloudObjects cloudObjects = new CloudObjects();
        private ProgressMessages progressMessages = new ProgressMessages();

        public FormMain()
        {
            InitializeComponent();

            this.appBar.ToolTip = new ModernToolTip();

            PopulateActions();            

            InitializeScanner();
        }

        private void InitializeScanner()
        {
            scanner = new Scanner
            {
                MaxTasks = Configuration.Instance.ConcurrentConnecitons,
                TimeOut = Configuration.Instance.Timeout // 15 minutes default
            };
            scanner.Progress.ProgressChanged += Scanner_ProgressChanged;
        }

        private void PopulateActions()
        {
            AppAction aboutAction = new AppAction();
            aboutAction.Click += AboutAction_Click;
            aboutAction.Image = Resources.About50;
            aboutAction.Cursor = Cursors.Hand;
            aboutAction.ToolTip = "About AWSRetriever...";
            appBar.Actions.Add(aboutAction);

            AppAction stopAction = new AppAction();
            stopAction.Image = Resources.Private50;
            stopAction.Click += StopAction_Click;
            stopAction.Cursor = Cursors.Hand;
            stopAction.ToolTip = "Stop Scanning";
            appBar.Actions.Add(stopAction);

            AppAction loadProfileAction = new AppAction();
            loadProfileAction.Image = Resources.Form50;
            loadProfileAction.Click += LoadProfileAction_Click;
            loadProfileAction.Cursor = Cursors.Hand;
            loadProfileAction.ToolTip = "Loads a saved profile";
            appBar.Actions.Add(loadProfileAction);

            SidebarTextItem scanAction = new SidebarTextItem("Full Scan");
            scanAction.Click += ScanAction_Click;
            this.sidebarControl.Items.Add(scanAction);

            SidebarTextItem runAction = new SidebarTextItem("Run Single");
            runAction.Click += RunAction_Click;
            this.sidebarControl.Items.Add(runAction);

            SidebarTextItem editProfileAction = new SidebarTextItem("Profile Editor");
            editProfileAction.Click += EditProfileAction_Click;
            this.sidebarControl.Items.Add(editProfileAction);

            SidebarTextItem editCredentialsAction = new SidebarTextItem("Set Credentials");
            editCredentialsAction.Click += EditCredentialsAction_Click;
            this.sidebarControl.Items.Add(editCredentialsAction);

            SidebarTextItem configureAction = new SidebarTextItem("Settings");
            configureAction.Click += ConfigureAction_Click;
            this.sidebarControl.Items.Add(configureAction);
        }

        private void ConfigureAction_Click(object sender, MouseEventArgs e)
        {
            FormAction("Done", delegate
             {
                 FormConfig formConfig = new FormConfig();
                 formConfig.ShowDialog();
             });
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormAction("Loading profile...",
                delegate
                {
                    LoadProfile(Configuration.Instance.Profile, Profile.AllServices());
                }, false);
            FormAction("Loading objects..", LoadObjectsFromFile, false);
            FormAction("Loading messages..", LoadMessagesFromFile, false);
        }

        private void LoadProfileAction_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Profile.FileFilter;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.LoadProfile(openFileDialog.FileName, this.profile);
            }
        }

        private void AboutAction_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog(this);
        }

        private void EditCredentialsAction_Click(object sender, MouseEventArgs e)
        {
            FormAction("Ready", ShowCredentialsDialog);
        }

        private void StopAction_Click(object sender, EventArgs e)
        {
            FormAction("Stopping...", delegate ()
            {
                if (this.scanner != null)
                {

                    this.scanner.Cancel();
                }
            });
        }

        private void EditProfileAction_Click(object sender, MouseEventArgs e)
        {
            FormAction("Ready", ShowProfileDialog);
        }

        private void RunAction_Click(object sender, MouseEventArgs e)
        {
            FormAction("Ready", ShowRunDialog);
        }

        private void ShowRunDialog()
        {
            FormRun form = new FormRun();
            form.Profile = this.profile;
            DialogResult dr = form.ShowDialog();

            if (dr == DialogResult.OK)
            {
                if (form.Operation == null)
                {
                    SetStatus(new ApplicationException("No opeation selected"));
                    return;
                }
                if (this.creds == null)
                {
                    ShowCredentialsDialog();
                }
                foreach (var region in form.SelectedRegions)
                {
                    Operation op = form.Operation;
                    op.Proxy = this.Proxy;
                    scanner.Invokations.Enqueue(new OperationInvokation(op, region, this.creds, Configuration.Instance.PageSize));
                }
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync();
                }                
            }
        }

        private void ScanAction_Click(object sender, MouseEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                ModernMessageBox.ShowError(new ApplicationException("Scan in progress. Stop it first."));
                return;
            }                
            FormAction("Scanning...", delegate
             {
                 ValidateCredentials();
                 statusLabel.Text = String.Empty;
                 ClearObjects();
                 ClearProgressMessages();
                 QueueOperations();
                 if (!backgroundWorker.IsBusy)
                 {
                     backgroundWorker.RunWorkerAsync();
                 }
             });
        }

        private void ValidateCredentials()
        {
            if (this.creds == null)
            {
                ShowCredentialsDialog();
            }
            if (this.creds != null)
            {
                if (this.creds.GetCredentials() != null)
                {
                    return;
                }
            }
            throw new ApplicationException("Invalid credentials");
        }        

        #region background worker

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (creds == null)
            {
                throw new ApplicationException("No Credentials are provided");
            }
            scanner.Scan();
        }


        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is InvokationResult ir)
            {
                this.cloudObjects.Update(ir);
                this.listViewFound.VirtualListSize = this.cloudObjects.Count;
                this.progressMessages.Add(new ProgressMessage(ir));
                this.listViewMessages.VirtualListSize = this.progressMessages.Count;
                listViewMessages.EnsureVisible(this.progressMessages.Count - 1);
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
                ModernMessageBox.ShowError(e.Error);
            }
            else if (e.Cancelled)
            {
                SetStatus("Canceled");                
            }
            else
            {
                SetStatus("Done");
            }            
            FormAction("Saving objects...", cloudObjects.Save);
        }

        #endregion

        private void UpdateStatusBar(InvokationResult ir)
        {
            this.progressBar.Value = ir.Progress;
            this.statusLabel.Text = ir.ResultText();
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

        private void QueueOperations()
        {
            SetStatus("Queuing work items...");
            foreach (ProfileRecord p in this.profile)
            {
                if (p.Enabled)
                {
                    Operation op = Profile.FindOpeartion(p);
                    if (op != null)
                    {
                        op.Proxy = this.Proxy;
                        foreach (RegionEndpoint region in RegionsString.ParseSystemNames(p.Regions).Items)
                        {
                            scanner.Invokations.Enqueue(new OperationInvokation(op, region, creds, p.PageSize));
                        }
                    }
                }
            }
        }

        private void ShowCredentialsDialog()
        {
            FormCredentials formCredentials = new FormCredentials();
            DialogResult dr = formCredentials.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.creds = formCredentials.Credentials;
            }
        }

        private void ViewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModernMessageBox.ShowError(new NotImplementedException());
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

        private void ShowProfileDialog()
        {
            FormProfileEditor form = new FormProfileEditor(this.profile);
            form.ShowDialog();

            FormProfiles formProfiles = new FormProfiles();
            formProfiles.Profile = this.profile;
            formProfiles.ShowDialog();
            FormAction("Saving profile", profile.Save);
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
            catch (Exception)
            {
                this.cloudObjects = new CloudObjects();
                throw;
            }

        }

        private void FormAction(string status, Action action, bool showMessageBox = true)
        {
            this.sidebarControl.HideSidebar();
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
                    ModernMessageBox.ShowError(ex);
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

        private void LoadProfile(string fileName, Profile defaultProfile)
        {
            try
            {
                this.profile = Profile.Load(fileName);
                Configuration.Instance.Profile = fileName;
            }
            catch (Exception ex)
            {
                ModernMessageBox.ShowError(
                    new ApplicationException(String.Format("Failed to load profile '{0}': {1}, creating new.", fileName, ex.Message)));
                this.profile = defaultProfile;
            }
            finally
            {
                RefreshProfileName();
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public WebProxy Proxy
        {
            get
            {
                if (string.IsNullOrEmpty(Configuration.Instance.ProxyHost))
                {
                    return null;
                }
                return new WebProxy(Configuration.Instance.ProxyHost, Configuration.Instance.ProxyPort)
                {
                    Credentials = new NetworkCredential(Configuration.Instance.ProxyUser, Configuration.Instance.ProxyPassword)
                };
            }
        }

        private void RefreshProfileName()
        {
            this.appBar.Text = String.Format("{0} - (Active Profile: '{1}')", AssemblyProduct, this.profile.Name);
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
            ClearObjects();
        }

        private void ClearObjects()
        {
            cloudObjects.Clear();
            listViewFound.VirtualListSize = 0;
        }

        private void ClearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearProgressMessages();
        }

        private void ClearProgressMessages()
        {
            progressMessages.Clear();
            listViewMessages.VirtualListSize = 0;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.progressMessages.Save();
        }

        private void runAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewMessages.SelectedIndices.Count > 0)
            {
                FormAction("Run Again...", delegate
                {
                    int idx = this.listViewMessages.SelectedIndices[0];
                    ProgressMessage pm = this.progressMessages[idx];
                    ProfileRecord pr = this.profile.Find(pm.Service, pm.Operation);
                    Operation op = Profile.FindOpeartion(pr);
                    op.Proxy = this.Proxy;
                    var region = RegionEndpoint.GetBySystemName(pm.RegionSystemName);

                    scanner.Invokations.Enqueue(new OperationInvokation(op, region, this.creds, pr.PageSize));
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync();
                    }
                });
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                SetStatus("Running..");
            } else
            {
                this.Cursor = Cursors.Default;
                this.progressBar.Value = 0;
            }            
        }
    }
}