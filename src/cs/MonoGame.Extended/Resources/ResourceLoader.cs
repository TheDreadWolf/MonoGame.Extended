using System.Collections.Generic;

namespace MonoGame.Extended.Resources
{
    public interface IResourceLoader{}

    public abstract class ResourceLoader<T> : IResourceLoader
    {
        public abstract T LoadResource(string path, ResourceManager resourceManager);
    }
}
