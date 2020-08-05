using System;

namespace SearchInstalledPrograms
{
    class Program
    {
        static void Main(string[] args)
        {


            string filter = args.Length > 0 ? args[0] : "";


            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (Microsoft.Win32.RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        string displayName = subkey.GetValue("DisplayName")?.ToString() ?? "";

                        if (displayName.Contains(filter, StringComparison.InvariantCultureIgnoreCase))
                            Console.WriteLine(subkey.GetValue("DisplayName"));
                    }
                }
            }
        }
    }
}
