using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Handyb
{
    class Adb
    {
        private static readonly Regex REGEX_DEVICES = new Regex(@"^([a-z0-9_-]+(?:\s?[\.a-z0-9_-]+)?(?:\:\d{1,})?)\s+(bootloader|device|download|offline|recovery|sideload|unauthorized|unknown)(?:\s+(?:product:([^\s]+)))?(?:\s+(?:model:([^\s]+)))?(?:\s+(?:device:([^\s]+)))?(?:\s+(?:transport_id:(\d)))$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex REGEX_GETPROP = new Regex(@"^\[([^]]+)\]\:\s*\[(.*)\]$", RegexOptions.Compiled);

        private static readonly Regex REGEX_VERSION = new Regex(@"^.*(\d+)\.(\d+)\.(\d+)$");

        private const int TIMEOUT_EXECUTION = 30 * 1000;

        public string Exe { get; private set; }

        public class Device
        {
            public string Name { get; internal set; }

            public bool IsOnline
            {
                get
                {
                    return string.Equals(State, "Device");
                }
            }

            public string Product { get; internal set; }

            public string Model { get; internal set; }

            public string Serial { get; internal set; }

            public string State { get; internal set; }
        }

        public class Result
        {
            public int Code { get; internal set; }

            public string Error { get; internal set; }

            public string Output { get; internal set; }
        }

        public Adb(string exe)
        {
            Exe = exe;
        }

        public bool Connect(string urn)
        {
            var r = Execute("connect", urn);
            if (r.Code == 0)
            {
                return r.Output.Contains("connected to " + urn);
            }
            return false;
        }

        public List<Device> Devices()
        {
            List<Device> list = new List<Device>();
            var output = Execute("devices", "-l").Output;
            using (StringReader s = new StringReader(output))
            {
                string line;
                while ((line = s.ReadLine()) != null)
                {
                    Match m = REGEX_DEVICES.Match(line);
                    if (m.Success)
                    {
                        Device device = new Device
                        {
                            Serial = m.Groups[1].Value,
                            State = FirstCharToUpper(m.Groups[2].Value)
                        };
                        if (device.IsOnline)
                        {
                            device.Product = m.Groups[3].Value;
                            device.Model = m.Groups[4].Value;
                            device.Name = m.Groups[5].Value;
                        }
                        list.Add(device);
                    }
                }
            }
            return list;
        }

        public Result Execute(params string[] args)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = string.Join(" ", args.Select((arg) => { return " \"" + arg.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\""; })),
                    CreateNoWindow = true,
                    FileName = Exe,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            StringBuilder error = new StringBuilder();
            StringBuilder output = new StringBuilder();
            using (AutoResetEvent eHandle = new AutoResetEvent(false))
            using (AutoResetEvent oHandle = new AutoResetEvent(false))
            {
                p.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data == null)
                    {
                        eHandle.Set();
                    }
                    else
                    {
                        error.AppendLine(e.Data);
                    }
                };
                p.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data == null)
                    {
                        oHandle.Set();
                    }
                    else
                    {
                        output.AppendLine(e.Data);
                    }
                };
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                if (!p.WaitForExit(TIMEOUT_EXECUTION) || !oHandle.WaitOne(TIMEOUT_EXECUTION) || !eHandle.WaitOne(TIMEOUT_EXECUTION))
                {
                    p.Kill();
                    p.WaitForExit();
                }
            }
            var result = new Result
            {
                Code = p.ExitCode,
                Error = error.ToString(),
                Output = output.ToString()
            };
            return result;
        }

        private static string FirstCharToUpper(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length > 1)
                {
                    return char.ToUpper(str[0]) + str.Substring(1);
                }
                return str.ToUpper();
            }
            return null;
        }

        public bool Install(string serial, string apk)
        {
            var r = Execute("-s", serial, "install", apk);
            if (r.Code == 0)
            {
                return r.Output.Trim().EndsWith("Success");
            }
            return false;
        }

        public bool IsRooted(string serial)
        {
            var r = Execute("-s", serial, "shell", "su", "-c", "id");
            if (r.Code == 0)
            {
                return r.Output.Contains("uid=0");
            }
            return false;
        }

        public bool Kill()
        {
            return Execute("kill-server").Code == 0;
        }

        public void Logcat(string serial)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = string.Format("-s {0} logcat -v threadtime", serial),
                    FileName = Exe
                }
            };
            p.Start();
        }

        public Dictionary<string, string> Properties(string serial)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            var o = Execute("-s", serial, "shell", "getprop").Output;
            using (StringReader reader = new StringReader(o))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = REGEX_GETPROP.Match(line);
                    if (match.Success)
                    {
                        string key = match.Groups[1].Value.Trim();
                        string value = match.Groups[2].Value.Trim();
                        properties[key] = value;
                    }
                }
            }
            return properties;
        }

        public bool Pull(string serial, string remote, string local)
        {
            var o = Execute("-s", serial, "pull", remote, local).Error.Trim();
            return !string.IsNullOrEmpty(o) && !o.StartsWith("failed to copy") && !o.EndsWith("does not exist");
        }

        public bool Push(string serial, string local, string remote)
        {
            var o = Execute("-s", serial, "push", local, remote).Error.Trim();
            return !string.IsNullOrEmpty(o) && !o.StartsWith("failed to copy");
        }

        public bool Reboot(string serial, string mode = null)
        {
            return Execute("-s", serial, "reboot", mode).Code == 0;
        }

        public string Screenshot(string serial)
        {
            var rnd = Guid.NewGuid().ToString();
            var r = Execute("-s", serial, "shell", "screencap", "-p", "/data/local/tmp/" + rnd + ".png");
            if (r.Code == 0)
            {
                var d = Path.Combine(Path.GetTempPath(), rnd + ".png");
                if (Pull(serial, "/data/local/tmp/" + rnd + ".png", d))
                {
                    Execute("-s", serial, "shell", "rm", "/data/local/tmp/" + rnd + ".png");
                    return d;
                }
            }
            return null;
        }

        public void Shell(string serial)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = string.Format("-s {0} shell", serial),
                    FileName = Exe
                }
            };
            p.Start();
        }

        public bool Start()
        {
            return Execute("start-server").Code == 0;
        }

        public Version Version()
        {
            var r = Execute("version");
            if (r.Code == 0)
            {
                using (StringReader s = new StringReader(r.Output))
                {
                    string line;
                    while ((line = s.ReadLine()) != null)
                    {
                        Match m = REGEX_VERSION.Match(line);
                        if (m.Success)
                        {
                            return new Version(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value));
                        }
                    }
                }
            }
            return null;
        }
    }
}
