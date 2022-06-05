using SFML.System;

namespace Valor
{
	namespace MathUtils
	{
		public class Mesh
		{
			public List<Triangle> triangles = new();

			public static Mesh LoadFromFile(string path)
			{
				Mesh mesh = new();
				var lines = File.ReadAllLines(path);

				List<Vector3f> vertices = new();

				foreach (var line in lines)
				{
					var parts = line.Split(' ');
					if (parts[0] == "v")
					{
						var vertex = new Vector3f(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
						vertices.Add(vertex);
					}
					else if (parts[0] == "f")
					{
						var triangle = new Triangle(
							vertices[int.Parse(parts[1]) - 1],
							vertices[int.Parse(parts[2]) - 1],
							vertices[int.Parse(parts[3]) - 1]);
						mesh.triangles.Add(triangle);
					}
					//else
						//Console.WriteLine($"Unknown line: {line}");
				}
				
				return mesh;
			}
		}
	}
}
