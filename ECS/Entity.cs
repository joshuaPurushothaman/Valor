using System.Collections.Specialized;

namespace Valor.ECS
{
	public struct Entity
	{
		public readonly int id;
		BitVector32 components = new();

		public Entity()
		{
			id = Manager.Instance.GetNextEntityID();
		}

		public Entity AddComponent<T>(T component) where T : struct
		{
			if (TryAddComponent<T>(component) == false)
				throw new Exception($"Entity already has component of type {typeof(T)}");

			//	If it was true, then the call would have succeeded, so return this for method chaining
			return this;
		}

		public bool TryAddComponent<T>(T component) where T : struct
		{
			if (HasComponent<T>())
				return false;

			Manager.Instance.AddComponent<T>(id, component);

			components[Manager.Instance.GetComponentID<T>()] = true;

			return true;
		}

		public bool HasComponent<T>() where T : struct =>
			components[Manager.Instance.GetComponentID<T>()];
	}
}
