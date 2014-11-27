using System.Collections.Generic;
using System.Linq;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    internal class CascadePathResolver : IPathResolver
    {
        public IEnumerable<IPathResolver> Nodes;
        public IPathSpecification Specification;
       
        public string Resolve()
        {
            foreach (var pathResolver in Nodes.Where(pathResolver => Specification.IsSatisfiedBy(pathResolver.Resolve())))
            {
                return pathResolver.Resolve();
            }
            return string.Empty;
        }
    }
}
