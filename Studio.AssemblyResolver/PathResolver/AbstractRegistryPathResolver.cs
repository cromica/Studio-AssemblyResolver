using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Studio.AssemblyResolver.PathResolver
{
    public abstract class AbstractRegistryPathResolver : IPathResolver
    {
        internal const string InstallLocation64Bit = @"SOFTWARE\Wow6432Node\SDL";
        internal const string InstallLocation32Bit = @"SOFTWARE\SDL";
        internal const string InstallLocationKey = "InstallLocation";

        public abstract string GetStudioVersion();

        public string Resolve()
        {
            string path = null;

            try
            {
                var registryPath = Environment.Is64BitOperatingSystem
                    ? string.Format(@"{0}\{1}", InstallLocation32Bit, GetStudioVersion())
                    : string.Format(@"{0}\{1}", InstallLocation64Bit, GetStudioVersion());
                var registryKey = Registry.LocalMachine.OpenSubKey(registryPath);
                if (registryKey != null) path = registryKey.GetValue(InstallLocationKey,false) as string;
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return path;
        }
    }
}
