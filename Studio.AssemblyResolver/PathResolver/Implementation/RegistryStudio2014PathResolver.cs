using System;
using Microsoft.Win32;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class RegistryStudio2014PathResolver: AbstractRegistryPathResolver
    {
        public override string GetStudioVersion()
        {
            return "Studio3";
        }
    }
}
