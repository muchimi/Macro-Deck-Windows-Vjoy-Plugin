using System;
using System.Collections.Generic;
using System.Text;

namespace muchimi_vjoy
{

    public class AppItem
    {
        /// <summary>
        /// display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// full path to the application
        /// </summary>
        public string Path { get; set; }

        public AppItem Self => this;
    }

    /// <summary>
    /// gets a list of installed applications on the machine
    /// </summary>
    public static class InstalledApplications
    {


        public static IList<AppItem> Applications()
        {

            var regKey = Microsoft.Win32.Registry.LocalMachine;
            var subKey = regKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
            var subKeyNames = subKey.GetSubKeyNames();

            var list = new List<AppItem>();

            foreach (string subKeyName in subKeyNames)
            {
                var sk = subKey.OpenSubKey(subKeyName);
                if (sk == null)
                    continue;

                if (ValueNameExists(sk.GetValueNames(), "DisplayName") && ValueNameExists(sk.GetValueNames(), "DisplayVersion"))
                {
                    var item = new AppItem()
                    {
                        DisplayName = sk.GetValue("DisplayName")?.ToString(),
                        Version = sk.GetValue("DisplayVersion")?.ToString()
                    };
                    list.Add(item);

                    sk.Close();
                }
                
            }

            subKey.Close();

            return list;
        }

        private static bool ValueNameExists(string[] valueNames, string valueName)
        {
            foreach (string s in valueNames)
            {
                if (String.Equals(s, valueName, StringComparison.CurrentCultureIgnoreCase)) return true;
            }

            return false;
        }
    }
}
