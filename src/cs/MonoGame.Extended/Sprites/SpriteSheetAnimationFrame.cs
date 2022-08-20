using System.Diagnostics;

namespace MonoGame.Extended.Sprites
{
    [DebuggerDisplay("{Index} {Duration}")]
    public class SpriteSheetAnimationFrame
    {
        public SpriteSheetAnimationFrame(int index, float duration = 0.2f)
        {
            Index = index;
            Duration = duration;
        }

        public int Index { get; set; }
        public float Duration { get; set; }
    }
}
