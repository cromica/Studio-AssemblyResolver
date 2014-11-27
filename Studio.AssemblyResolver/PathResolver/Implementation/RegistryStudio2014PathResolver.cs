using System;
using Microsoft.Win32;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class RegistryStudio2014PathResolver: IPathResolver
    {
        internal const string RootRegistryKeyPath = @"SOFTWARE\SDL\Studio3";
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
