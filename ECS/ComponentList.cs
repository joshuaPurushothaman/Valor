namespace Valor.ECS
{
	interface IComponentList
	{
	}

	class ComponentList<T> : IComponentList where T : struct
	{
		public List<T> components = new();
		public Dictionary<int, int> entityIDToIndex = new();
	}

	static class ExtensionMethods
	{
		public static void Add<T>(this IComponentList list, int entityID, T component) where T : struct
		{
			if (list is ComponentList<T> componentList)
			{
				if (componentList.entityIDToIndex.TryGetValue(entityID, out int index))
				{
					componentList.components[index] = component;
				}
				else
				{
					componentList.components.Add(component);
					componentList.entityIDToIndex.Add(entityID, componentList.components.Count - 1);
				}
			}
		}
	}
}
