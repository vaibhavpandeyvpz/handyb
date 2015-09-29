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
    public partial class DeviceProperties : Form
    {
        class Prop
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        private List<Prop> Props = new List<Prop>();

        public DeviceProperties(Dictionary<string, string> data)
        {
            InitializeComponent();
            foreach (var pair in data)
            {
                Props.Add(new Prop { Key = pair.Key, Value = pair.Value });
            }
        }

        private void OnDevicePropertiesLoad(object sender, EventArgs e)
        {
            PropertyList.Items.AddRange(Props.Select(c => new ListViewItem(new string[] { c.Key, c.Value })).ToArray());
        }

        private void OnPropertyListKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                var b = new StringBuilder();
                foreach (ListViewItem item in PropertyList.SelectedItems)
                {
                    b.AppendLine(string.Format("{0}: {1}", item.SubItems[0].Text, item.SubItems[1].Text));
                }
                Clipboard.SetText(b.ToString());
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            PropertyList.Items.Clear();
            PropertyList.Items.AddRange(Props.Where(i => string.IsNullOrEmpty(Search.Text) || i.Key.Contains(Search.Text) || i.Value.Contains(Search.Text))
                .Select(c => new ListViewItem(new string[] { c.Key, c.Value })).ToArray());
        }
    }
}
