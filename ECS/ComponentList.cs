namespace Valor.ECS
{
	interface IComponentList
	{
	}

	class ComponentList<T> : IComponentList where T : struct
	{
		public List<T> components = new();
	}

	static class ExtensionMethods
	{
		public static void Add<T>(this IComponentList list, int entityID, T component) where T : struct
		{
			if (list is ComponentList<T> componentList)
			{
				componentList.components.Insert(entityID, component);
			}
		}
	}
}
