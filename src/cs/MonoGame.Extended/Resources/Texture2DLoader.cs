using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace MonoGame.Extended.Resources
{
    public class Texture2DLoader : ResourceLoader<Texture2D>
    {
        private readonly GraphicsDevice _graphicsDevice;

        public Texture2DLoader(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public override Texture2D LoadResource(string path, ResourceManager resourceManager)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                return Texture2D.FromStream(_graphicsDevice, fileStream);
            }
        }
    }
}
