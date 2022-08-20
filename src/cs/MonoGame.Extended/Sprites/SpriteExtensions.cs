using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Extended.Sprites
{
    public static class SpriteExtensions
    {
        public static void BeginEXT
       (
           this SpriteBatch spriteBatch,
           SpriteSortMode sortMode = SpriteSortMode.Deferred,
           BlendState blendState = null,
           SamplerState samplerState = null,
           DepthStencilState depthStencilState = null,
           RasterizerState rasterizerState = null,
           Effect effect = null,
           Matrix? transformMatrix = null
       )
        {
            blendState ??= BlendState.AlphaBlend;
            samplerState ??= SamplerState.LinearClamp;
            depthStencilState ??= DepthStencilState.None;
            rasterizerState ??= RasterizerState.CullCounterClockwise;
            Matrix matrixValue = transformMatrix.GetValueOrDefault();

            spriteBatch.Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, matrixValue);
        }

        public static void Draw(this Sprite sprite, SpriteBatch spriteBatch, Vector2 position, float rotation, Vector2 scale, float? depth = null)
        {
            Draw(spriteBatch, sprite, position, rotation, scale, depth);
        }

        public static void Draw(this SpriteBatch spriteBatch, Sprite sprite, Transform2 transform, float? depth = null)
        {
            Draw(spriteBatch, sprite, transform.WorldPosition, transform.WorldRotation, transform.WorldScale, depth);
        }

        public static void Draw(this SpriteBatch spriteBatch, Sprite sprite, Vector2 position, float rotation = 0, float? depth = null)
        {
            Draw(spriteBatch, sprite, position, rotation, Vector2.One,depth);
        }

        public static void Draw(this SpriteBatch spriteBatch, Sprite sprite, Vector2 position, float rotation, Vector2 scale, float? depth = null)
        {
            if (sprite == null) throw new ArgumentNullException(nameof(sprite));

            depth ??= sprite.Depth;

            if (sprite.IsVisible)
            {
                var texture = sprite.TextureRegion.Texture;
                var sourceRectangle = sprite.TextureRegion.Bounds;
                spriteBatch.Draw(texture, position, sourceRectangle, sprite.Color * sprite.Alpha, rotation, sprite.Origin, scale, sprite.Effect, depth.Value);
            }
        }
    }
}
