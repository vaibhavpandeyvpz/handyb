namespace Handyb
{
    partial class Frontend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frontend));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.OutputBox = new System.Windows.Forms.Panel();
            this.OutputText = new System.Windows.Forms.RichTextBox();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Screenshot = new System.Windows.Forms.Button();
            this.Logcat = new System.Windows.Forms.Button();
            this.Rooted = new System.Windows.Forms.Label();
            this.DevicesBox = new System.Windows.Forms.ComboBox();
            this.Kill = new System.Windows.Forms.Button();
            this.GetProp = new System.Windows.Forms.Button();
            this.Shell = new System.Windows.Forms.Button();
            this.Reboot = new System.Windows.Forms.Button();
            this.Pull = new System.Windows.Forms.Button();
            this.Push = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.RebootBox = new System.Windows.Forms.ComboBox();
            this.Links = new System.Windows.Forms.Panel();
            this.Profile = new System.Windows.Forms.Label();
            this.Website = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.TextBoxPanel = new System.Windows.Forms.Panel();
            this.ConnectBox = new System.Windows.Forms.MaskedTextBox();
            this.Install = new System.Windows.Forms.Button();
            this.ChooseApk = new System.Windows.Forms.OpenFileDialog();
            this.StatusBar.SuspendLayout();
            this.OutputBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Links.SuspendLayout();
            this.TextBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Progress,
            this.Version});
            this.StatusBar.Location = new System.Drawing.Point(3, 336);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(458, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // Version
            // 
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(0, 17);
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.Color.Black;
            this.OutputBox.Controls.Add(this.OutputText);
            this.OutputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OutputBox.Location = new System.Drawing.Point(3, 236);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Padding = new System.Windows.Forms.Padding(5);
            this.OutputBox.Size = new System.Drawing.Size(458, 100);
            this.OutputBox.TabIndex = 3;
            // 
            // OutputText
            // 
            this.OutputText.BackColor = System.Drawing.Color.Black;
            this.OutputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputText.ForeColor = System.Drawing.Color.LawnGreen;
            this.OutputText.Location = new System.Drawing.Point(5, 5);
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.Size = new System.Drawing.Size(448, 90);
            this.OutputText.TabIndex = 0;
            this.OutputText.Text = "";
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnWorkerProgressChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Screenshot, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Logcat, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Rooted, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.DevicesBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Kill, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.GetProp, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Shell, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Reboot, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Pull, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Push, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Connect, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Reset, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Refresh, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.RebootBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Links, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Start, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Install, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 233);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Screenshot
            // 
            this.Screenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Screenshot.Location = new System.Drawing.Point(231, 79);
            this.Screenshot.Name = "Screenshot";
            this.Screenshot.Size = new System.Drawing.Size(108, 32);
            this.Screenshot.TabIndex = 26;
            this.Screenshot.Text = "Screenshot";
            this.Screenshot.UseVisualStyleBackColor = true;
            this.Screenshot.Click += new System.EventHandler(this.OnRemountClick);
            // 
            // Logcat
            // 
            this.Logcat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logcat.Location = new System.Drawing.Point(345, 117);
            this.Logcat.Name = "Logcat";
            this.Logcat.Size = new System.Drawing.Size(110, 32);
            this.Logcat.TabIndex = 25;
            this.Logcat.Text = "Logcat";
            this.Logcat.UseVisualStyleBackColor = true;
            this.Logcat.Click += new System.EventHandler(this.OnLogcatClick);
            // 
            // Rooted
            // 
            this.Rooted.BackColor = System.Drawing.Color.White;
            this.Rooted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rooted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rooted.Location = new System.Drawing.Point(346, 194);
            this.Rooted.Margin = new System.Windows.Forms.Padding(4);
            this.Rooted.Name = "Rooted";
            this.Rooted.Size = new System.Drawing.Size(108, 35);
            this.Rooted.TabIndex = 24;
            this.Rooted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DevicesBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.DevicesBox, 2);
            this.DevicesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DevicesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DevicesBox.FormattingEnabled = true;
            this.DevicesBox.ItemHeight = 24;
            this.DevicesBox.Location = new System.Drawing.Point(3, 4);
            this.DevicesBox.Margin = new System.Windows.Forms.Padding(3, 4, 4, 2);
            this.DevicesBox.Name = "DevicesBox";
            this.DevicesBox.Size = new System.Drawing.Size(221, 30);
            this.DevicesBox.TabIndex = 22;
            this.DevicesBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnComboBoxDrawItem);
            this.DevicesBox.SelectedIndexChanged += new System.EventHandler(this.OnDevicesBoxChanged);
            // 
            // Kill
            // 
            this.Kill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kill.Location = new System.Drawing.Point(345, 41);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(110, 32);
            this.Kill.TabIndex = 18;
            this.Kill.Text = "Kill";
            this.Kill.UseVisualStyleBackColor = true;
            this.Kill.Click += new System.EventHandler(this.OnKillClick);
            // 
            // GetProp
            // 
            this.GetProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GetProp.Location = new System.Drawing.Point(231, 117);
            this.GetProp.Name = "GetProp";
            this.GetProp.Size = new System.Drawing.Size(108, 32);
            this.GetProp.TabIndex = 15;
            this.GetProp.Text = "Properties";
            this.GetProp.UseVisualStyleBackColor = true;
            this.GetProp.Click += new System.EventHandler(this.OnGetPropClick);
            // 
            // Shell
            // 
            this.Shell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Shell.Location = new System.Drawing.Point(345, 79);
            this.Shell.Name = "Shell";
            this.Shell.Size = new System.Drawing.Size(110, 32);
            this.Shell.TabIndex = 14;
            this.Shell.Text = "Shell";
            this.Shell.UseVisualStyleBackColor = true;
            this.Shell.Click += new System.EventHandler(this.OnShellClick);
            // 
            // Reboot
            // 
            this.Reboot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reboot.Location = new System.Drawing.Point(117, 79);
            this.Reboot.Name = "Reboot";
            this.Reboot.Size = new System.Drawing.Size(108, 32);
            this.Reboot.TabIndex = 13;
            this.Reboot.Text = "Reboot";
            this.Reboot.UseVisualStyleBackColor = true;
            this.Reboot.Click += new System.EventHandler(this.OnRebootClick);
            // 
            // Pull
            // 
            this.Pull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pull.Location = new System.Drawing.Point(231, 155);
            this.Pull.Name = "Pull";
            this.Pull.Size = new System.Drawing.Size(108, 32);
            this.Pull.TabIndex = 6;
            this.Pull.Text = "Pull";
            this.Pull.UseVisualStyleBackColor = true;
            this.Pull.Click += new System.EventHandler(this.OnPullClick);
            // 
            // Push
            // 
            this.Push.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Push.Location = new System.Drawing.Point(345, 155);
            this.Push.Name = "Push";
            this.Push.Size = new System.Drawing.Size(110, 32);
            this.Push.TabIndex = 5;
            this.Push.Text = "Push";
            this.Push.UseVisualStyleBackColor = true;
            this.Push.Click += new System.EventHandler(this.OnPushClick);
            // 
            // Connect
            // 
            this.Connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Connect.Location = new System.Drawing.Point(117, 41);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(108, 32);
            this.Connect.TabIndex = 4;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.OnConnectClick);
            // 
            // Reset
            // 
            this.Reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reset.Location = new System.Drawing.Point(345, 3);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(110, 32);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.OnResetClick);
            // 
            // Refresh
            // 
            this.Refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Refresh.Location = new System.Drawing.Point(231, 3);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(108, 32);
            this.Refresh.TabIndex = 1;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.OnRefreshClick);
            // 
            // RebootBox
            // 
            this.RebootBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebootBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RebootBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RebootBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootBox.FormattingEnabled = true;
            this.RebootBox.ItemHeight = 24;
            this.RebootBox.Location = new System.Drawing.Point(3, 80);
            this.RebootBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.RebootBox.Name = "RebootBox";
            this.RebootBox.Size = new System.Drawing.Size(108, 30);
            this.RebootBox.Sorted = true;
            this.RebootBox.TabIndex = 12;
            this.RebootBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnComboBoxDrawItem);
            // 
            // Links
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Links, 2);
            this.Links.Controls.Add(this.Profile);
            this.Links.Controls.Add(this.Website);
            this.Links.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Links.Location = new System.Drawing.Point(3, 117);
            this.Links.Name = "Links";
            this.tableLayoutPanel1.SetRowSpan(this.Links, 3);
            this.Links.Size = new System.Drawing.Size(222, 113);
            this.Links.TabIndex = 16;
            // 
            // Profile
            // 
            this.Profile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Profile.AutoSize = true;
            this.Profile.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Profile.Location = new System.Drawing.Point(55, 39);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(108, 13);
            this.Profile.TabIndex = 5;
            this.Profile.Text = "@vpzvaibhavpandey";
            // 
            // Website
            // 
            this.Website.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Website.AutoSize = true;
            this.Website.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Website.Location = new System.Drawing.Point(46, 57);
            this.Website.Name = "Website";
            this.Website.Size = new System.Drawing.Size(130, 13);
            this.Website.TabIndex = 4;
            this.Website.Text = "www.vaibhavpandey.com";
            // 
            // Start
            // 
            this.Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Start.Location = new System.Drawing.Point(231, 41);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(108, 32);
            this.Start.TabIndex = 17;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.OnStartClick);
            // 
            // TextBoxPanel
            // 
            this.TextBoxPanel.BackColor = System.Drawing.Color.White;
            this.TextBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxPanel.Controls.Add(this.ConnectBox);
            this.TextBoxPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextBoxPanel.Location = new System.Drawing.Point(3, 42);
            this.TextBoxPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxPanel.Name = "TextBoxPanel";
            this.TextBoxPanel.Padding = new System.Windows.Forms.Padding(6);
            this.TextBoxPanel.Size = new System.Drawing.Size(108, 30);
            this.TextBoxPanel.TabIndex = 21;
            // 
            // ConnectBox
            // 
            this.ConnectBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConnectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectBox.Location = new System.Drawing.Point(6, 6);
            this.ConnectBox.Mask = "###.###.###.###:5555";
            this.ConnectBox.Name = "ConnectBox";
            this.ConnectBox.Size = new System.Drawing.Size(94, 13);
            this.ConnectBox.TabIndex = 24;
            // 
            // Install
            // 
            this.Install.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Install.Location = new System.Drawing.Point(231, 193);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(108, 37);
            this.Install.TabIndex = 23;
            this.Install.Text = "Install";
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.OnInstallClick);
            // 
            // ChooseApk
            // 
            this.ChooseApk.Filter = "Android APKs|*.apk";
            this.ChooseApk.Multiselect = true;
            this.ChooseApk.Title = "Choose APK Files";
            // 
            // Frontend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.StatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(480, 400);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "Frontend";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Handyb - http://git.io/vcebx";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnDashboardClosing);
            this.Load += new System.EventHandler(this.OnDashboardLoad);
            this.Click += new System.EventHandler(this.OnDashboardLoad);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.OutputBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Links.ResumeLayout(false);
            this.Links.PerformLayout();
            this.TextBoxPanel.ResumeLayout(false);
            this.TextBoxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Panel OutputBox;
        private System.Windows.Forms.RichTextBox OutputText;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Pull;
        private System.Windows.Forms.Button Push;
        private System.Windows.Forms.ComboBox RebootBox;
        private System.Windows.Forms.Button Reboot;
        private System.Windows.Forms.Button GetProp;
        private System.Windows.Forms.Button Shell;
        private System.Windows.Forms.Panel Links;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Kill;
        private System.Windows.Forms.Label Profile;
        private System.Windows.Forms.Label Website;
        private System.Windows.Forms.ComboBox DevicesBox;
        private System.Windows.Forms.Panel TextBoxPanel;
        private System.Windows.Forms.MaskedTextBox ConnectBox;
        private System.Windows.Forms.Label Rooted;
        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.OpenFileDialog ChooseApk;
        private System.Windows.Forms.ToolStripStatusLabel Version;
        private System.Windows.Forms.Button Logcat;
        private System.Windows.Forms.Button Screenshot;
    }
}

