using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Valor
{
	namespace MathUtils
	{
		public static class Functions
		{
			public static double Degrees(double radians)
			{
				return radians * 180 / Math.PI;
			}

			public static double Radians(double degrees)
			{
				return degrees * Math.PI / 180;
			}

			public static float Dot(Vector3f a, Vector3f b)
			{
				return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
			}

			public static Vector3f Cross(Vector3f a, Vector3f b)
			{
				return new Vector3f(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
			}

			public static float Length(Vector3f a)
			{
				return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
			}
			public static Vector3f Normalize(Vector3f a)
			{
				return new Vector3f(a.X / Length(a), a.Y / Length(a), a.Z / Length(a));
			}
		}

		public struct Triangle
		{
			public Vector3f[] points = new Vector3f[3];

			public Triangle(Vector3f v1, Vector3f v2, Vector3f v3)
			{
				points[0] = v1;
				points[1] = v2;
				points[2] = v3;
			}
		}

		public class Mesh
		{
			public List<Triangle> triangles = new();
		}
	}
}
