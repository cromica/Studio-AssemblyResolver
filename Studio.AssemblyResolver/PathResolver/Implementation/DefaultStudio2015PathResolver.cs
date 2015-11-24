using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class DefaultStudio2015PathResolver: IPathResolver
    {
        public string Resolve()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"SDL\SDL Trados Studio\Studio4\");

        }
    }
}
