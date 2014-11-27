using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class RegistryStudio2011PathResolver : IPathResolver
    {
        internal const string RootRegistryKeyPath = @"SOFTWARE\SDL\Studio2";
        internal const string InstallLocation = "InstallLocation";

        public string Resolve()
        {
            string path = null;

            try
            {
                var registryKey = Registry.LocalMachine.OpenSubKey(RootRegistryKeyPath);
                if (registryKey != null) path = registryKey.GetValue(InstallLocation, false) as string;
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return path;
        }
    }
}
