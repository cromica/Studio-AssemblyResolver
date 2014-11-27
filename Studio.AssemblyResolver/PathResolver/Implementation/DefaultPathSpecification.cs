using System.IO;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class DefaultPathSpecification : IPathSpecification
    {
        public bool IsSatisfiedBy(string path)
        {
            return Directory.Exists(Path.GetDirectoryName(path));
        }
    }
}
