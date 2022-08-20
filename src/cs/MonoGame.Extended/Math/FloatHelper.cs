using System.Runtime.CompilerServices;
using System;

namespace MonoGame.Extended
{
    public static class FloatHelper
    {
        public const float Deg2Rad = 0.0174532924f;
        public const float Rad2Deg = 57.29578f;
        public const float PI = (float)Math.PI;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref float value1, ref float value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Radians(float x) => x * 0.0174532925f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Degrees(float x) => x * 57.295779513f;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float f)
        {
            return (float)Math.Round(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceil(float f)
        {
            return (float)Math.Ceiling(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CeilToInt(float f)
        {
            return (int)Math.Ceiling((double)f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FastCeilToInt(float y)
        {
            return 32768 - (int)(32768f - y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float f)
        {
            return (float)Math.Floor(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloorToInt(float f)
        {
            return (int)Math.Floor((double)f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FastFloorToInt(float x)
        {
            // we shift to guaranteed positive before casting then shift back after
            return (int)(x + 32768f) - 32768;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundToInt(float f)
        {
            return (int)Math.Round(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int TruncateToInt(float f)
        {
            return (int)Math.Truncate(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp01(float value)
        {
            if (value < 0f)
                return 0f;

            if (value > 1f)
                return 1f;

            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                return min;

            if (value > max)
                return max;

            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int value, int min, int max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;

            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinOf(float a, float b, float c)
        {
            return MathF.Min(a, MathF.Min(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxOf(float a, float b, float c)
        {
            return MathF.Max(a, MathF.Max(b, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinOf(float a, float b, float c, float d)
        {
            return MathF.Min(a, MathF.Min(b, MathF.Min(c, d)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MinOf(float a, float b, float c, float d, float e)
        {
            return MathF.Min(a, MathF.Min(b, MathF.Min(c, MathF.Min(d, e))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxOf(float a, float b, float c, float d)
        {
            return MathF.Max(a, MathF.Max(b, MathF.Max(c, d)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MaxOf(float a, float b, float c, float d, float e)
        {
            return MathF.Max(a, MathF.Max(b, MathF.Max(c, MathF.Max(d, e))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float from, float to, float t)
        {
            return from + (to - from) * Math.Clamp(t,0f,1f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float InverseLerp(float from, float to, float t)
        {
            if (from < to)
            {
                if (t < from)
                    return 0.0f;
                else if (t > to)
                    return 1.0f;
            }
            else
            {
                if (t < to)
                    return 1.0f;
                else if (t > from)
                    return 0.0f;
            }

            return (t - from) / (to - from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float UnclampedLerp(float from, float to, float t)
        {
            return from + (to - from) * t;
        }
    }
}
