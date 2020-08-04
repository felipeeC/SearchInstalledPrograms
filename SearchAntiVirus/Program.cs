using System;

namespace SearchAntiVirus {
    class Program {
        static void Main(string[] args) {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registry_key)) {
                foreach (string subkey_name in key.GetSubKeyNames()) {
                    using (Microsoft.Win32.RegistryKey subkey = key.OpenSubKey(subkey_name)) {
                        Console.WriteLine(subkey.GetValue("DisplayName"));
                    }
                }
            }


        }
    }
}
