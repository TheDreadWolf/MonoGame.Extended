using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;

namespace MonoGame.Extended.Screens.Transitions
{
    public class FadeTransition : Transition
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;

        public FadeTransition(GraphicsDevice graphicsDevice, Color color, float duration = 1.0f)
            : base(duration)
        {
            Color = color;

            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public override void Dispose()
        {
            _spriteBatch.Dispose();
        }

        public Color Color { get; }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.BeginEXT(samplerState: SamplerState.PointClamp);
            _spriteBatch.FillRectangle(0, 0, _graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height, Color * Value);
            _spriteBatch.End();
        }
    }
}
