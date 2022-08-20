using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace MonoGame.Extended
{
    [DebuggerDisplay("{DebugDisplayString,nq}")]
    public struct Point4 : IEquatable<Point4>, IEquatableByRef<Point4>
    {
        public static readonly Point4 Zero = new Point4();

        public int X;

        public int Y;

        public int Z;

        public int W;

        public Point4(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static bool operator ==(Point4 first, Point4 second)
        {
            return first.Equals(ref second);
        }

        public bool Equals(Point4 point)
        {
            return Equals(ref point);
        }

        public bool Equals(ref Point4 point)
        {
            return (point.X == X) && (point.Y == Y) && (point.Z == Z) && point.Z == Z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point4)
                return Equals((Point4) obj);
            return false;
        }

        public static bool operator !=(Point4 first, Point4 second)
        {
            return !(first == second);
        }

        public static Point4 operator +(Point4 point, Vector4 vector)
        {
            return Add(point, vector);
        }

        public static Point4 Add(Point4 point, Vector4 vector)
        {
            Point4 p;
            p.X = point.X + (int)vector.X;
            p.Y = point.Y + (int)vector.Y;
            p.Z = point.Z + (int)vector.Z;
            p.W = point.W + (int)vector.W;
            return p;
        }

        public static Point4 operator -(Point4 point, Vector4 vector)
        {
            return Subtract(point, vector);
        }

        public static Point4 Subtract(Point4 point, Vector4 vector)
        {
            Point4 p;
            p.X = point.X - (int)vector.X;
            p.Y = point.Y - (int)vector.Y;
            p.Z = point.Z - (int)vector.Z;
            p.W = point.W - (int)vector.W;
            return p;
        }

        public static Vector4 operator -(Point4 point1, Point4 Vector2)
        {
            return Displacement(point1, Vector2);
        }

        public static Vector4 Displacement(Point4 Vector2, Point4 point1)
        {
            Vector4 vector;
            vector.X = Vector2.X - point1.X;
            vector.Y = Vector2.Y - point1.Y;
            vector.Z = Vector2.Z - point1.Z;
            vector.W = Vector2.W - point1.W;
            return vector;
        }

        public override int GetHashCode()
        {
            var yHash = Y.GetHashCode();
            var zHash = Z.GetHashCode();
            var wHash = W.GetHashCode();
            return X.GetHashCode() ^ (yHash << 8) ^ (yHash >> 24) ^ (zHash << 16) ^ (zHash >> 16) ^ (wHash << 24) ^ (wHash >> 8);
        }

        public static Point4 Minimum(Point4 first, Point4 second)
        {
            return new Point4
            (
                first.X < second.X ? first.X : second.X,
                first.Y < second.Y ? first.Y : second.Y,
                first.Z < second.Z ? first.Z : second.Z,
                first.W < second.W ? first.W : second.W
            );
        }

        public static Point4 Maximum(Point4 first, Point4 second)
        {
            return new Point4
           (
               first.X > second.X ? first.X : second.X,
               first.Y > second.Y ? first.Y : second.Y,
               first.Z > second.Z ? first.Z : second.Z,
               first.W > second.W ? first.W : second.W
           );
        }

        public static implicit operator Vector4(Point4 point)
        {
            return new Vector4(point.X, point.Y, point.Z,point.W);
        }

        public static implicit operator Point4(Vector4 vector)
        {
            return new Point4((int)vector.X, (int)vector.Y, (int)vector.Z,(int)vector.W);
        }

        public override string ToString()
        {
            return (
                "{X:" + X.ToString() +
                " Y:" + Y.ToString() +
                " Z:" + Z.ToString() +
                " W:" + W.ToString() +
                "}"
            );
        }

        internal string DebugDisplayString => ToString();
    }
}
