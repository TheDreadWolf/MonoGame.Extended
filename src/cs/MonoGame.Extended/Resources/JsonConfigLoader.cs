using System.Text.Json;
using System.IO;

namespace MonoGame.Extended.Resources
{
    public class JsonConfigLoader<T> : ResourceLoader<T>
    {
        public override T LoadResource(string path, ResourceManager resourceManager)
        {
            string text = File.ReadAllText(path);
            T config = JsonSerializer.Deserialize<T>(text);
            return config;
        }

        
    }
}
