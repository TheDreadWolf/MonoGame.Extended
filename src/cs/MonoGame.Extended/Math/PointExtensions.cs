using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace MonoGame.Extended
{
    public static class PointExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }
    }
}
