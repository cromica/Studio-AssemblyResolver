using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Studio.AssemblyResolver.PathResolver;
using Studio.AssemblyResolver.PathResolver.Implementation;

namespace Studio.AssemblyResolver
{
    public class StudioAssemblyResolver
    {
        private readonly IEnumerable<IPathResolver> _resolvers;

        internal StudioAssemblyResolver(IEnumerable<IPathResolver> resolvers)
        {
            this._resolvers = resolvers;
        }

        internal StudioAssemblyResolver()
        {
            this._resolvers = Enumerable.Empty<IPathResolver>();
        }

        public void Resolve()
        {
            AssemblyResolver.StudioPath = TryGetStudioPath();
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += currentDomain_AssemblyResolve;
        }

        private string TryGetStudioPath()
        {
            return new CascadePathResolver
            {
                Specification = new DefaultPathSpecification(),
                Nodes = _resolvers.Concat(new IPathResolver[]
                {
                    new DefaultStudio2014PathResolver(),
                    new RegistryStudio2014PathResolver(),
                    new DefaultStudio2011PathResolver(),
                    new RegistryStudio2014PathResolver()
                })
            }.Resolve();
        }

        private Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (string.IsNullOrEmpty(AssemblyResolver.StudioPath)) return null;
            var folderPath = Path.GetDirectoryName(AssemblyResolver.StudioPath);
            if (folderPath == null) return null;
            var assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(assemblyPath) == false) return null;
            var assembly = Assembly.LoadFrom(assemblyPath);
            return assembly;
        }
    }
}
