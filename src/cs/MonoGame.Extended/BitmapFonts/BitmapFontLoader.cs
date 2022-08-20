using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Resources;
using MonoGame.Extended.TextureAtlases;
using System.IO;
using System.Linq;

namespace MonoGame.Extended.BitmapFonts
{
    public class BitmapFontLoader : ResourceLoader<BitmapFont>
    {
        public override BitmapFont LoadResource(string path, ResourceManager resourceManager)
        {
            SharpFNT.BitmapFont fntFile = SharpFNT.BitmapFont.FromFile(path);

            int pageCount = fntFile.Pages.Count;
            var textures = new Texture2D[pageCount];

            int index = 0;
            string texturePath = Path.GetDirectoryName(path);
            foreach(var kvp in fntFile.Pages)
            {
                textures[index] = resourceManager.LoadResource<Texture2D>(Path.Combine(texturePath,kvp.Value));
                ++index;
            }

            int lineHeight = fntFile.Common.LineHeight;
            int regionCount = fntFile.Characters.Count;
            var regions = new BitmapFontRegion[regionCount];

            index = 0;
            foreach(var kvp in fntFile.Characters)
            {
                int character = kvp.Key;
                int textureIndex = kvp.Value.Page;
                int x = kvp.Value.X;
                var y = kvp.Value.Y;
                var width = kvp.Value.Width;
                var height = kvp.Value.Height;
                var xOffset = kvp.Value.XOffset;
                var yOffset = kvp.Value.YOffset;
                var xAdvance = kvp.Value.XAdvance;
                var textureRegion = new TextureRegion2D(textures[textureIndex], x, y, width, height);
                regions[index] = new BitmapFontRegion(textureRegion, character, xOffset, yOffset, xAdvance);
                ++index;
            }

            var characterMap = regions.ToDictionary(r => r.Character);
            var kerningsCount = fntFile.KerningPairs.Count;

            index = 0;
            foreach(var kvp in fntFile.KerningPairs)
            {
                int first = kvp.Key.First;
                var second = kvp.Key.Second;
                var amount = kvp.Value;

                // Find region
                if (!characterMap.TryGetValue(first, out var region))
                    continue;

                region.Kernings[second] = amount;
            }

            string name = Path.GetFileNameWithoutExtension(path);
            return new BitmapFont(name, regions, lineHeight);
        }
    }
}
