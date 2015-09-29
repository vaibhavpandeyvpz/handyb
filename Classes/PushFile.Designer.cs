namespace Handyb
{
    partial class PushFile
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
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.RemoteText = new System.Windows.Forms.TextBox();
            this.RemoteLabel = new System.Windows.Forms.Label();
            this.LocalLabel = new System.Windows.Forms.Label();
            this.LocalText = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.FileChooser = new System.Windows.Forms.OpenFileDialog();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.ColumnCount = 2;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.Table.Controls.Add(this.RemoteText, 0, 3);
            this.Table.Controls.Add(this.RemoteLabel, 0, 2);
            this.Table.Controls.Add(this.LocalLabel, 0, 0);
            this.Table.Controls.Add(this.LocalText, 0, 1);
            this.Table.Controls.Add(this.Browse, 1, 1);
            this.Table.Controls.Add(this.Submit, 1, 4);
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(4, 4);
            this.Table.Name = "Table";
            this.Table.RowCount = 5;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Table.Size = new System.Drawing.Size(292, 124);
            this.Table.TabIndex = 0;
            // 
            // RemoteText
            // 
            this.Table.SetColumnSpan(this.RemoteText, 2);
            this.RemoteText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoteText.Location = new System.Drawing.Point(3, 75);
            this.RemoteText.Name = "RemoteText";
            this.RemoteText.Size = new System.Drawing.Size(286, 20);
            this.RemoteText.TabIndex = 5;
            this.RemoteText.Text = "/data/local/tmp/";
            // 
            // RemoteLabel
            // 
            this.Table.SetColumnSpan(this.RemoteLabel, 2);
            this.RemoteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoteLabel.Location = new System.Drawing.Point(3, 48);
            this.RemoteLabel.Name = "RemoteLabel";
            this.RemoteLabel.Size = new System.Drawing.Size(286, 24);
            this.RemoteLabel.TabIndex = 4;
            this.RemoteLabel.Text = "Remote Path (Phone)";
            this.RemoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocalLabel
            // 
            this.Table.SetColumnSpan(this.LocalLabel, 2);
            this.LocalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalLabel.Location = new System.Drawing.Point(3, 0);
            this.LocalLabel.Name = "LocalLabel";
            this.LocalLabel.Size = new System.Drawing.Size(286, 24);
            this.LocalLabel.TabIndex = 0;
            this.LocalLabel.Text = "Local Path";
            this.LocalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocalText
            // 
            this.LocalText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalText.Location = new System.Drawing.Point(3, 27);
            this.LocalText.Name = "LocalText";
            this.LocalText.Size = new System.Drawing.Size(198, 20);
            this.LocalText.TabIndex = 1;
            // 
            // Browse
            // 
            this.Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browse.Location = new System.Drawing.Point(207, 26);
            this.Browse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(82, 21);
            this.Browse.TabIndex = 2;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.OnBrowseClick);
            // 
            // Submit
            // 
            this.Submit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Submit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Submit.Location = new System.Drawing.Point(207, 99);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(82, 22);
            this.Submit.TabIndex = 6;
            this.Submit.Text = "Push";
            this.Submit.UseVisualStyleBackColor = true;
            // 
            // FileChooser
            // 
            this.FileChooser.Title = "Choose File To Push";
            // 
            // PushFile
            // 
            this.AcceptButton = this.Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 136);
            this.Controls.Add(this.Table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 175);
            this.Name = "PushFile";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Push File To Phone";
            this.Table.ResumeLayout(false);
            this.Table.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.Label LocalLabel;
        private System.Windows.Forms.TextBox LocalText;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label RemoteLabel;
        private System.Windows.Forms.TextBox RemoteText;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.OpenFileDialog FileChooser;
    }
}