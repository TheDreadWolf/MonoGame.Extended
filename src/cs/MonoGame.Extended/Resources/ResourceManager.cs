using System;
using System.Collections.Generic;

namespace MonoGame.Extended.Resources
{
    public class ResourceManager
    {
        public interface IResourceContainer { };

        public class ResourceContainer<T> : IResourceContainer
        {
            public readonly T Resource;

            public ResourceContainer(T resource)
            {
                Resource = resource;
            }
        }

        private readonly Dictionary<string, WeakReference<IResourceContainer>> _loadedResources;
        private readonly Dictionary<Type, IResourceLoader> _resourceLoaders;

        public ResourceManager()
        {
            _resourceLoaders = new Dictionary<Type, IResourceLoader>();
            _loadedResources = new Dictionary<string, WeakReference<IResourceContainer>>();
        }

        public void RegisterResourceLoader<T>(ResourceLoader<T> loader)
        {
            _resourceLoaders[typeof(T)] = loader;
        }

        public T LoadResource<T> (string path)
        {
            if(_loadedResources.TryGetValue(path,out WeakReference<IResourceContainer> weakRef))
            {
                if (weakRef.TryGetTarget(out IResourceContainer container))
                {
                    if (container is ResourceContainer<T> castContainer)
                    {
                        return castContainer.Resource;
                    }
                }
                else
                {
                    _loadedResources.Remove(path);
                }
            }

            Type loaderType = typeof(T);

            if (_resourceLoaders.TryGetValue(loaderType, out IResourceLoader loader))
            {
                if (loader is ResourceLoader<T> castLoader)
                {
                    //try
                    // {
                    T resource = castLoader.LoadResource(path, this);
                    ResourceContainer<T> container = new(resource);
                    _loadedResources.Add(path, new WeakReference<IResourceContainer>(container));
                    return resource;
                    //}
                    //catch(Exception exception)
                    //{
                    //Console.WriteLine(exception.ToString());
                    //Console.WriteLine(exception.StackTrace);
                    //}
                }
            }
            return default;
        }
    }
}
