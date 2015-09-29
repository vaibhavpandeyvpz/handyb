using Handyb.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Handyb
{
    public partial class Frontend : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr filter, int flags);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        private static extern bool UnregisterDeviceNotification(IntPtr handle);

        private static readonly Guid CLASS_GUID = Guid.Parse("{3f966bd9-fa04-4ec5-991c-d326973b5128}");

        private const Int32 COMBOBOX_SETIH = 0x153;

        private const int CONSOLE_DIVIDER = 48;

        private const int DBT_DEVICEARRIVAL = 0x8000;

        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

        private const int DBT_DEVTYP_PORT = 0x00000003;

        [StructLayout(LayoutKind.Sequential)]
        private struct DEV_BROADCAST_HDR
        {
            internal int Size;

            internal int DeviceType;

            internal int Reserved;

            internal Guid ClassGuid;

            internal short Name;
        }

        public const int WM_DEVICECHANGE = 0x0219;

        private static IntPtr hNotification;

        private readonly Adb Adb;

        private class DeviceItem
        {
            public string Text
            {
                get
                {
                    if (Value.IsOnline)
                    {
                        return string.Format("{0} [{1}] - {2}", Value.Model, Value.Serial, Value.State);
                    }
                    else
                    {
                        return string.Format("{0} - {1}", Value.Serial, Value.State);
                    }
                }
            }

            public Adb.Device Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private class RebootItem
        {
            public string Text { get; set; }

            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public class Writer : TextWriter
        {
            RichTextBox Box = null;

            public Writer(RichTextBox output)
            {
                Box = output;
            }

            public override void Write(char value)
            {
                base.Write(value);
                if (value != '\r')
                {
                    Box.AppendText(value.ToString());
                }
            }

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }

        public Frontend()
        {
            InitializeComponent();
            Adb = new Adb(Find("adb"));
        }

        public static string Find(string exe)
        {
            if (!exe.EndsWith(".exe"))
            {
                exe += ".exe";
            }
            if (File.Exists(exe))
            {
                return exe;
            }
            string env;
            env = Environment.GetEnvironmentVariable("ANDROID_SDK_HOME");
            if (!string.IsNullOrEmpty(env))
            {
                string path;
                if (File.Exists(path = Path.Combine(env, "platform-tools", exe)))
                {
                    return path;
                }
            }
            env = Environment.ExpandEnvironmentVariables(Environment.GetEnvironmentVariable("PATH"));
            if (!string.IsNullOrEmpty(env))
            {
                string path;
                string[] paths = env.Split(';');
                foreach (var p in paths)
                {
                    if (File.Exists(path = Path.Combine(p, exe)))
                    {
                        return path;
                    }
                }
            }
            return string.Empty;
        }

        private void OnDashboardClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterDeviceNotification(hNotification);
        }

        private void OnDashboardLoad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Adb.Exe))
            {
                MessageBox.Show(Resources.ADB_NOT_FOUND_MESSAGE, Resources.ADB_NOT_FOUND_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
            else
            {
                DEV_BROADCAST_HDR dbi = new DEV_BROADCAST_HDR
                {
                    ClassGuid = CLASS_GUID,
                    DeviceType = DBT_DEVTYP_PORT,
                    Reserved = 0,
                    Name = 0
                };
                dbi.Size = Marshal.SizeOf(dbi);
                IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
                Marshal.StructureToPtr(dbi, buffer, true);
                hNotification = RegisterDeviceNotification(Handle, buffer, 0);
                Console.SetOut(new Writer(OutputText));
                OutputText.TextChanged += (a, b) =>
                {
                    OutputText.SelectionStart = OutputText.Text.Length;
                    OutputText.ScrollToCaret();
                };
                Profile.Click += (a, b) => { Process.Start("http://forum.xda-developers.com/member.php?u=5490832"); };
                Profile.MouseEnter += (a, b) =>
                {
                    Profile.Cursor = Cursors.Hand;
                    Profile.ForeColor = Color.MidnightBlue;
                };
                Profile.MouseLeave += (a, b) =>
                {
                    Profile.Cursor = Cursors.Default;
                    Profile.ForeColor = Color.RoyalBlue;
                };
                RebootBox.Items.Add(new RebootItem
                {
                    Text = Resources.REBOOT_BOOTLOADER,
                    Value = "bootloader"
                });
                RebootBox.Items.Add(new RebootItem
                {
                    Text = Resources.REBOOT_DOWNLOAD,
                    Value = "download"
                });
                RebootBox.Items.Add(new RebootItem
                {
                    Text = Resources.REBOOT_RECOVERY,
                    Value = "recovery"
                });
                RebootBox.Items.Add(new RebootItem
                {
                    Text = Resources.REBOOT_SYSTEM,
                    Value = "system"
                });
                RebootBox.SelectedIndex = RebootBox.Items.Count - 1;
                Rooted.Text = string.Format(Resources.ROOT_STATUS, "Unknown");
                Website.Click += (a, b) => { Process.Start("http://www.vaibhavpandey.com"); };
                Website.MouseEnter += (a, b) =>
                {
                    Website.Cursor = Cursors.Hand;
                    Website.ForeColor = Color.MidnightBlue;
                };
                Website.MouseLeave += (a, b) =>
                {
                    Website.Cursor = Cursors.Default;
                    Website.ForeColor = Color.RoyalBlue;
                };
                SendMessage(DevicesBox.Handle, COMBOBOX_SETIH, -1, 24);
                SendMessage(RebootBox.Handle, COMBOBOX_SETIH, -1, 24);
                ResizeTextBox(ConnectBox, 22);
                Console.WriteLine(Resources.OUTPUT_CHECKING_VERSION);
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    b.Result = Adb.Version();
                    Worker.ReportProgress(100);
                },
                (a, b) =>
                {
                    Version v;
                    if ((v = (Version)b.Result) != null)
                    {
                        Console.WriteLine(Resources.OUTPUT_VERSION_FOUND, v);
                        Version.Text = v.ToString();
                        Refresh.PerformClick();
                    }
                    else
                    {
                        Console.WriteLine(Resources.OUTPUT_VERSION_NOT_FOUND, v);
                    }
                });
            }
        }

        private void OnComboBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Font f = cb.Font;
            int y = 6;
            if ((e.State & DrawItemState.Focus) == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
                if (e.Index >= 0)
                {
                    e.Graphics.DrawString(cb.Items[e.Index].ToString(), f, new SolidBrush(SystemColors.WindowText), new Point(e.Bounds.X, e.Bounds.Y + y));
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds);
                if (e.Index >= 0)
                {
                    e.Graphics.DrawString(cb.Items[e.Index].ToString(), f, new SolidBrush(SystemColors.HighlightText), new Point(e.Bounds.X, e.Bounds.Y + y));
                }
            }
        }

        private void OnConnectClick(object sender, EventArgs e)
        {
            var urn = ConnectBox.Text;
            IPAddress ip;
            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
            if (IPAddress.TryParse(urn.TrimEnd(':', '5'), out ip))
            {
                Console.WriteLine(Resources.OUTPUT_CONNECTION_ATTEMPT, urn);
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    b.Result = Adb.Connect(urn);
                    Worker.ReportProgress(100);
                },
                (a, b) =>
                {
                    if ((bool)b.Result)
                    {
                        Console.WriteLine(Resources.OUTPUT_CONNECTION_SUCCESS, urn);
                        RunDelayed(() => { Refresh.PerformClick(); }, 2 * 1000);
                    }
                    else
                    {
                        Console.WriteLine(Resources.OUTPUT_CONNECTION_FAILED, urn);
                    }
                });
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_CONNECTION_INVALID_IP);
            }
        }

        private void OnDevicesBoxChanged(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                Console.WriteLine(Resources.OUTPUT_DEVICE_SELECTED, device.Model, device.Product, device.Serial);
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    b.Result = Adb.IsRooted(device.Serial);
                    Worker.ReportProgress(100);
                },
                (a, b) =>
                {
                    if ((bool)b.Result)
                    {
                        Rooted.BackColor = Color.LightGreen;
                        Rooted.Text = string.Format(Resources.ROOT_STATUS, "Yes");
                    }
                    else
                    {
                        Rooted.BackColor = Color.Salmon;
                        Rooted.Text = string.Format(Resources.ROOT_STATUS, "No");
                    }
                });
            }
            else
            {
                Rooted.BackColor = Color.White;
                Rooted.Text = string.Format(Resources.ROOT_STATUS, "Unknown");
            }
        }

        private void OnGetPropClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    b.Result = Adb.Properties(device.Serial);
                    Worker.ReportProgress(100);
                },
                (a, b) =>
                {
                    Dictionary<string, string> r;
                    if ((r = (Dictionary<string, string>)b.Result)!= null)
                    {
                        using (DeviceProperties properties = new DeviceProperties(r))
                        {
                            properties.ShowDialog();
                        }
                    }
                });
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnInstallClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if (((item = (DevicesBox.SelectedItem as DeviceItem)) != null) && (device = item.Value).IsOnline && (ChooseApk.ShowDialog() == DialogResult.OK))
            {
                string[] files = ChooseApk.FileNames;
                Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                Console.WriteLine(Resources.OUTPUT_INSTALLING_APPS, files.Length, device.Model, device.Serial);
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    Dictionary<string, bool> result = new Dictionary<string, bool>();
                    foreach (var f in files)
                    {
                        result[f] = Adb.Install(device.Serial, f);
                    }
                    b.Result = result;
                    Worker.ReportProgress(100);
                },
                (a, b) =>
                {
                    var result = (Dictionary<string, bool>)b.Result;
                    foreach (var k in result.Keys)
                    {
                        if (result[k])
                        {
                            Console.WriteLine(Resources.OUTPUT_INSTALL_SUCCESS, k);
                        }
                        else
                        {
                            Console.WriteLine(Resources.OUTPUT_INSTALL_FAILED, k);
                        }
                    }
                });
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnKillClick(object sender, EventArgs e)
        {
            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
            Console.WriteLine(Resources.OUTPUT_STOPPING_ADB);
            RunInBackground((a, b) =>
            {
                Worker.ReportProgress(1);
                Adb.Kill();
                Worker.ReportProgress(100);
            },
            (a, b) => { });
        }

        private void OnLogcatClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                Adb.Logcat(device.Serial);
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnPullClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                using (PullFile pull = new PullFile())
                {
                    if (pull.ShowDialog() == DialogResult.OK)
                    {
                        string local = pull.GetLocalPath();
                        string remote = pull.GetRemotePath();
                        if (string.IsNullOrEmpty(local))
                        {
                            Console.WriteLine(Resources.OUTPUT_ENTER_LOCAL);
                        }
                        else if (!Directory.Exists(local))
                        {
                            Console.WriteLine(Resources.OUTPUT_NOT_EXISTS, local);
                        }
                        else
                        {
                            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                            Console.WriteLine(Resources.OUTPUT_PULLING, remote, local, device.Model, device.Serial);
                            RunInBackground((a, b) =>
                            {
                                Worker.ReportProgress(1);
                                b.Result = Adb.Pull(device.Serial, remote, local);
                                Worker.ReportProgress(100);
                            },
                            (a, b) =>
                            {
                                if ((bool)b.Result)
                                {
                                    Console.WriteLine(Resources.OUTPUT_PULLING_FAILED, remote);
                                }
                                else
                                {
                                    Console.WriteLine(Resources.OUTPUT_PULLING_SUCCESS, remote);
                                }
                            });
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnPushClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                using (PushFile push = new PushFile())
                {
                    if (push.ShowDialog() == DialogResult.OK)
                    {
                        string local = push.GetLocalPath();
                        string remote = push.GetRemotePath();
                        if (string.IsNullOrEmpty(local))
                        {
                            Console.WriteLine(Resources.OUTPUT_ENTER_LOCAL);
                        }
                        else if (!File.Exists(local))
                        {
                            Console.WriteLine(Resources.OUTPUT_NOT_EXISTS, local);
                        }
                        else
                        {
                            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                            Console.WriteLine(Resources.OUTPUT_PUSHING, local, remote, device.Model, device.Serial);
                            RunInBackground((a, b) =>
                            {
                                Worker.ReportProgress(1);
                                b.Result = Adb.Push(device.Serial, local, remote);
                                Worker.ReportProgress(100);
                            },
                            (a, b) =>
                            {
                                if ((bool)b.Result)
                                {
                                    Console.WriteLine(Resources.OUTPUT_PUSHING_SUCCESS, local);
                                }
                                else
                                {
                                    Console.WriteLine(Resources.OUTPUT_PUSHING_FAILED, local);
                                }
                            });
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnRebootClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                var reboot = RebootBox.SelectedItem as RebootItem;
                Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                Console.WriteLine(Resources.OUTPUT_REBOOTING, device.Model, reboot.Text);
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    Adb.Reboot(device.Serial, reboot.Value);
                    Worker.ReportProgress(100);
                },
                (a, b) => { });
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
            Console.WriteLine(Resources.OUTPUT_REFRESHING);
            RunInBackground((a, b) =>
            {
                Worker.ReportProgress(1);
                b.Result = Adb.Devices();
                Worker.ReportProgress(100);
            },
            (a, b) =>
            {
                List<Adb.Device> list = (List<Adb.Device>)b.Result;
                Console.WriteLine(Resources.OUTPUT_REFRESHING_RESULT, list.Count);
                DevicesBox.Items.Clear();
                Rooted.BackColor = Color.White;
                Rooted.Text = string.Format(Resources.ROOT_STATUS, "Unknown");
                foreach (var d in list)
                {
                    DevicesBox.Items.Add(new DeviceItem
                    {
                        Value = d
                    });
                }
                if (DevicesBox.Items.Count >= 1)
                {
                    DevicesBox.SelectedIndex = 0;
                }
            });
        }

        private void OnRemountClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                Console.WriteLine(Resources.OUTPUT_SCREENSHOT);
                RunInBackground((a, b) =>
                {
                    Worker.ReportProgress(1);
                    b.Result = Adb.Screenshot(device.Serial);
                    Worker.ReportProgress(100);
                },
                (a, b) =>
                {
                    string p;
                    if (string.IsNullOrEmpty(p = (string)b.Result))
                    {
                        Console.WriteLine(Resources.OUTPUT_SCREENSHOT_FAILED);
                    }
                    else
                    {
                        Console.WriteLine(Resources.OUTPUT_SCREENSHOT_SUCCESS, p);
                        Process.Start(p);
                    }
                });
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnResetClick(object sender, EventArgs e)
        {
            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
            Console.WriteLine(Resources.OUTPUT_RESTARTING_ADB);
            RunInBackground((a, b) =>
            {
                Worker.ReportProgress(1);
                b.Result = Adb.Kill() && Adb.Start();
                Worker.ReportProgress(100);
            },
            (a, b) =>
            {
                if ((bool)b.Result)
                {
                    RunDelayed(() => { Refresh.PerformClick(); }, 2 * 1000);
                }
            });
        }

        private void OnShellClick(object sender, EventArgs e)
        {
            Adb.Device device;
            DeviceItem item;
            if ((item = (DevicesBox.SelectedItem as DeviceItem)) != null && ((device = item.Value).IsOnline))
            {
                Adb.Shell(device.Serial);
            }
            else
            {
                Console.WriteLine(Resources.OUTPUT_DEVICE_OFFLINE);
            }
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
            Console.WriteLine(Resources.OUTPUT_STARTING_ADB);
            RunInBackground((a, b) =>
            {
                Worker.ReportProgress(1);
                b.Result = Adb.Start();
                Worker.ReportProgress(100);
            },
            (a, b) =>
            {
                if ((bool)b.Result)
                {
                    RunDelayed(() => { Refresh.PerformClick(); }, 2 * 1000);
                }
            });
        }

        private void OnWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                Progress.Style = ProgressBarStyle.Marquee;
            }
            else if (e.ProgressPercentage == 100)
            {
                Progress.Style = ProgressBarStyle.Blocks;
            }
        }

        private static void ResizeTextBox(MaskedTextBox tb, float height)
        {
            Font original = tb.Font;
            Font custom = new Font(original.FontFamily, original.Size, original.Style, GraphicsUnit.Pixel);
            if (height < 8)
            {
                height = 8;
            }
            float size = custom.FontFamily.GetEmHeight(custom.Style);
            float spacing = custom.FontFamily.GetLineSpacing(custom.Style);
            float em = (height - 7) * size / spacing;
            custom = new Font(custom.FontFamily, em, custom.Style, GraphicsUnit.Pixel);
            tb.Font = custom;
        }

        private void RunDelayed(Action action, int millis)
        {
            Dispatcher d = Dispatcher.CurrentDispatcher;
            new Task(() =>
            {
                Thread.Sleep(millis);
                d.BeginInvoke(action);
            }).Start();
        }

        private void RunInBackground(Action<object, DoWorkEventArgs> run, Action<object, RunWorkerCompletedEventArgs> completed)
        {
            if (Worker.IsBusy)
            {
                var result = MessageBox.Show(Resources.WORKER_BUSY_MESSAGE, Resources.WORKER_BUSY_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Worker.CancelAsync();
                }
                else
                {
                    return;
                }
            }
            DoWorkEventHandler a = new DoWorkEventHandler(run);
            RunWorkerCompletedEventHandler b = null;
            b = new RunWorkerCompletedEventHandler((o, e) =>
            {
                Worker.DoWork -= a;
                Worker.RunWorkerCompleted -= b;
                completed(o, e);
            });
            Worker.DoWork += a;
            Worker.RunWorkerCompleted += b;
            Worker.RunWorkerAsync();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICEARRIVAL:
                        if (Marshal.ReadInt32(m.LParam, 4) == DBT_DEVTYP_PORT)
                        {
                            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                            Console.WriteLine(Resources.OUTPUT_DEVICE_ADDED);
                            RunDelayed(() => { Refresh.PerformClick(); }, 2 * 1000);
                        }
                        break;
                    case DBT_DEVICEREMOVECOMPLETE:
                        if (Marshal.ReadInt32(m.LParam, 4) == DBT_DEVTYP_PORT)
                        {
                            Console.WriteLine(new String('-', CONSOLE_DIVIDER));
                            Console.WriteLine(Resources.OUTPUT_DEVICE_REMOVED);
                            RunDelayed(() => { Refresh.PerformClick(); }, 1 * 1000);
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }
    }
}
