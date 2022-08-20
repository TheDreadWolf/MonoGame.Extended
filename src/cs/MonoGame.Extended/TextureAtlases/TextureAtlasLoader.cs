using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Resources;
using System.IO;

namespace MonoGame.Extended.TextureAtlases
{
    public class TextureAtlasLoader : ResourceLoader<TextureAtlas>
    {
        private readonly JsonConfigLoader<TexturePackerFile> _configLoader;

        public TextureAtlasLoader() : base()
        {
            _configLoader = new JsonConfigLoader<TexturePackerFile>();
        }

        public override TextureAtlas LoadResource(string path, ResourceManager resourceManager)
        {
            TexturePackerFile texturePackerFile = _configLoader.LoadResource(path, resourceManager);

            string directory = Path.GetDirectoryName(path);
            string texturePath = Path.Combine(directory, texturePackerFile.Metadata.Image);
            Texture2D texture = resourceManager.LoadResource<Texture2D>(texturePath);
            string name = Path.GetFileNameWithoutExtension(path);
            var atlas =  new TextureAtlas(name, texture);

            var regionCount = texturePackerFile.Regions.Count;

            for (var i = 0; i < regionCount; i++)
            {
                atlas.CreateRegion(
                    Path.GetFileNameWithoutExtension(texturePackerFile.Regions[i].Filename),
                    texturePackerFile.Regions[i].Frame.X,
                    texturePackerFile.Regions[i].Frame.Y,
                    texturePackerFile.Regions[i].Frame.Width,
                    texturePackerFile.Regions[i].Frame.Height);
            }
            return atlas;
        }
    }
}
