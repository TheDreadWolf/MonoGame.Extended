using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace MonoGame.Extended
{
    [DebuggerDisplay("{DebugDisplayString,nq}")]
    public struct Point3 : IEquatable<Point3>, IEquatableByRef<Point3>
    {
        public static readonly Point3 Zero = new Point3();

        public int X;

        public int Y;

        public int Z;

        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Point3 first, Point3 second)
        {
            return first.Equals(ref second);
        }

        public bool Equals(Point3 point)
        {
            return Equals(ref point);
        }
       
        public bool Equals(ref Point3 point)
        {
            return (point.X == X) && (point.Y == Y) && (point.Z == Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3)
                return Equals((Point3) obj);
            return false;
        }

        public static bool operator !=(Point3 first, Point3 second)
        {
            return !(first == second);
        }

        public static Point3 operator +(Point3 point, Vector3 vector)
        {
            return Add(point, vector);
        }

        public static Point3 Add(Point3 point, Vector3 vector)
        {
            Point3 p;
            p.X = point.X + (int)vector.X;
            p.Y = point.Y + (int)vector.Y;
            p.Z = point.Z + (int)vector.Z;
            return p;
        }

        public static Point3 operator -(Point3 point, Vector3 vector)
        {
            return Subtract(point, vector);
        }

        public static Point3 Subtract(Point3 point, Vector3 vector)
        {
            Point3 p;
            p.X = point.X - (int)vector.X;
            p.Y = point.Y - (int)vector.Y;
            p.Z = point.Z - (int)vector.Z;
            return p;
        }

        public static Vector3 operator -(Point3 point1, Point3 point2)
        {
            return Displacement(point1, point2);
        }

        public static Vector3 Displacement(Point3 point2, Point3 point1)
        {
            Vector3 vector;
            vector.X = point2.X - point1.X;
            vector.Y = point2.Y - point1.Y;
            vector.Z = point2.Z - point1.Z;
            return vector;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();
                return hash;
            }
        }

        public static Point3 Minimum(Point3 first, Point3 second)
        {
            return new Point3(first.X < second.X ? first.X : second.X,
                first.Y < second.Y ? first.Y : second.Y,
                first.Z < second.Z ? first.Z : second.Z);
        }

        public static Point3 Maximum(Point3 first, Point3 second)
        {
            return new Point3(first.X > second.X ? first.X : second.X,
                first.Y > second.Y ? first.Y : second.Y,
                first.Z > second.Z ? first.Z : second.Z);
        }

        public static implicit operator Vector3(Point3 point)
        {
            return new Vector3(point.X, point.Y, point.Z);
        }

        public static implicit operator Point3(Vector3 vector)
        {
            return new Point3((int)vector.X, (int)vector.Y, (int)vector.Z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        internal string DebugDisplayString => ToString();
    }
}
