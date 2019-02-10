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
using System.Threading.Tasks;

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
                TimeOut = Configuration.Instance.Timeout
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
            stopAction.Image = Resources.Stop50;
            stopAction.Click += StopAction_Click;
            stopAction.Cursor = Cursors.Hand;
            stopAction.ToolTip = "Stop Scanning";
            appBar.Actions.Add(stopAction);

            AppAction loadProfileAction = new AppAction();
            loadProfileAction.Image = Resources.Import50;
            loadProfileAction.Click += LoadProfileAction_Click;
            loadProfileAction.Cursor = Cursors.Hand;
            loadProfileAction.ToolTip = "Loads a saved profile";
            appBar.Actions.Add(loadProfileAction);

            SidebarTextItem scanAction = new SidebarTextItem("Full Scan (by profile)");
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
            FormAction("Ready",  delegate()
            {
                ShowProfileDialog(null, null);
            });
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
                WebProxy proxy = Configuration.Instance.GetWebProxy();
                foreach (var region in form.SelectedRegions)
                {                    
                    scanner.Invokations.Enqueue(form.Operation.Clone(proxy, region, this.creds, Configuration.Instance.PageSize));
                }
                Start();
            }
        }

        private void ScanAction_Click(object sender, MouseEventArgs e)
        {
            FormAction("Scanning...", delegate
             {
                 ValidateCredentials();
                 statusLabel.Text = String.Empty;
                 ClearObjects();
                 ClearProgressMessages();
                 QueueOperations();
                 Start();
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
        
        
        
        private void UpdateStatusBar(OperationResult ir)
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

        private async void Start()
        {
            if (!this.scanner.Running)
            {
                this.Cursor = Cursors.AppStarting;
                try
                {
                    await Task.Run(() =>
                    {
                        this.scanner.Scan();
                    });
                }
                catch (Exception ex)
                {
                    ModernMessageBox.ShowError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    this.progressBar.Value = 0;
                    FormAction("Saving objects...", cloudObjects.Save);
                }
            }
        }        

        private void Scanner_ProgressChanged(object sender, OperationResult ir)
        {
            this.Invoke((Action)delegate
            {
                this.cloudObjects.Update(ir);
                this.listViewFound.VirtualListSize = this.cloudObjects.Count;
                this.progressMessages.Add(new ProgressMessage(ir));
                this.listViewMessages.VirtualListSize = this.progressMessages.Count;
                listViewMessages.EnsureVisible(this.progressMessages.Count - 1);
                UpdateStatusBar(ir);                
            });
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
                        WebProxy proxy = Configuration.Instance.GetWebProxy();
                        foreach (RegionEndpoint region in RegionsString.ParseSystemNames(p.Regions).Items)
                        {
                            scanner.Invokations.Enqueue(op.Clone(proxy, region, this.creds, p.PageSize));                            
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

        private void ShowProfileDialog(string service, string operation)
        {
            FormProfileEditor form = new FormProfileEditor(this.profile, service, operation);            
            form.ShowDialog();                        
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

        private void RunAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewMessages.SelectedIndices.Count > 0)
            {
                FormAction("Run Again...", delegate
                {
                    int idx = this.listViewMessages.SelectedIndices[0];
                    ProgressMessage pm = this.progressMessages[idx];
                    ProfileRecord pr = this.profile.Find(pm.Service, pm.Operation);
                    Operation op = Profile.FindOpeartion(pr);                    
                    var region = RegionEndpoint.GetBySystemName(pm.RegionSystemName);
                    scanner.Invokations.Enqueue(op.Clone(Configuration.Instance.GetWebProxy(), region, this.creds, pr.PageSize));
                    Start();
                });
            }
        }

        private void ViewInProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewMessages.SelectedIndices.Count > 0)
            {
                ProgressMessage pm = this.progressMessages[listViewMessages.SelectedIndices[0]];
                ShowProfileDialog(pm.Service, pm.Operation);                
            }
        }

        private void SaveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAction("Ready", delegate ()
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".js";
                saveFileDialog.Filter = "JSON (*.js)|*.js";                
                DialogResult dr = saveFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.cloudObjects.Export(saveFileDialog.FileName);
                    ModernMessageBox.Show(string.Format("Saved to '{0}'", saveFileDialog.FileName));
                }
            });            
        }

        private void ListViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewMessages.SelectedIndices.Count > 0)
            {
                ProgressMessage pom = this.progressMessages[this.listViewMessages.SelectedIndices[0]];
                this.propertyGridObject.SelectedObject = pom;
                if (!string.IsNullOrEmpty(pom.Error))
                {
                    this.richTextBoxCobo.Text = pom.Error;
                }
                else
                {
                    this.richTextBoxCobo.Text = pom.Result;
                }
            }
        }
    }
}