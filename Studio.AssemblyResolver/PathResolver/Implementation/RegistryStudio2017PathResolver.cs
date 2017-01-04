using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class RegistryStudio2017PathResolver: AbstractRegistryPathResolver
    {
        public override string GetStudioVersion()
        {
            return "Studio5";
        }
    }
}
