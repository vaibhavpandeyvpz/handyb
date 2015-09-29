using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Handyb
{
    public partial class PullFile : Form
    {
        public PullFile()
        {
            InitializeComponent();
        }

        public string GetLocalPath()
        {
            return LocalText.Text;
        }

        public string GetRemotePath()
        {
            return RemoteText.Text;
        }

        private void OnBrowseClick(object sender, EventArgs e)
        {
            if (FolderChooser.ShowDialog() == DialogResult.OK)
            {
                LocalText.Text = FolderChooser.SelectedPath;
            }
        }
    }
}
