namespace Handyb
{
    partial class DeviceProperties
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
            this.PropertyList = new System.Windows.Forms.ListView();
            this.Names = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Values = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Search = new System.Windows.Forms.TextBox();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.ColumnCount = 1;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table.Controls.Add(this.PropertyList, 0, 1);
            this.Table.Controls.Add(this.Search, 0, 0);
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Name = "Table";
            this.Table.RowCount = 2;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.896797F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.1032F));
            this.Table.Size = new System.Drawing.Size(344, 281);
            this.Table.TabIndex = 0;
            // 
            // PropertyList
            // 
            this.PropertyList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PropertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Names,
            this.Values});
            this.PropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyList.FullRowSelect = true;
            this.PropertyList.GridLines = true;
            this.PropertyList.Location = new System.Drawing.Point(3, 28);
            this.PropertyList.Name = "PropertyList";
            this.PropertyList.Size = new System.Drawing.Size(338, 250);
            this.PropertyList.TabIndex = 1;
            this.PropertyList.UseCompatibleStateImageBehavior = false;
            this.PropertyList.View = System.Windows.Forms.View.Details;
            this.PropertyList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPropertyListKeyUp);
            // 
            // Names
            // 
            this.Names.Text = "Name";
            this.Names.Width = 128;
            // 
            // Values
            // 
            this.Values.Text = "Value";
            this.Values.Width = 192;
            // 
            // Search
            // 
            this.Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Search.Location = new System.Drawing.Point(3, 3);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(338, 20);
            this.Search.TabIndex = 0;
            this.Search.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // DeviceProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 281);
            this.Controls.Add(this.Table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 320);
            this.Name = "DeviceProperties";
            this.Text = "Device Properties";
            this.Load += new System.EventHandler(this.OnDevicePropertiesLoad);
            this.Table.ResumeLayout(false);
            this.Table.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.ListView PropertyList;
        private System.Windows.Forms.ColumnHeader Names;
        private System.Windows.Forms.ColumnHeader Values;
        private System.Windows.Forms.TextBox Search;



    }
}