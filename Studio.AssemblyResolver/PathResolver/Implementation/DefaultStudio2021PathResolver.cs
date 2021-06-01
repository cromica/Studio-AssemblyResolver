using System;
using System.IO;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class DefaultStudio2021PathResolver : IPathResolver
    {
        public string Resolve()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"SDL\SDL Trados Studio\Studio16\");
        }
    }
}