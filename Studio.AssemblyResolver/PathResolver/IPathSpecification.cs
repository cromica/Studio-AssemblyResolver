namespace Studio.AssemblyResolver.PathResolver
{
    public interface IPathSpecification
    {
        bool IsSatisfiedBy(string path);
    }
}
