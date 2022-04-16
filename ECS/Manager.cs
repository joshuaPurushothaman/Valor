namespace Valor.ECS
{
	class Manager
	{
		int currentEntityID = 0;
		int currentComponentID = 0;
		readonly List<IComponentList> componentLists = new();
		readonly Dictionary<Type, IComponentList> componentListsByType = new();

		//	Singleton
		private static readonly Lazy<Manager> lazy = new(() => new Manager());
		public static Manager Instance { get { return lazy.Value; } }

		public int GetNextEntityID()
		{
			currentEntityID++;
			return currentEntityID;
		}

		public int GetComponentID<T>() where T : struct
		{
			if (!componentListsByType.ContainsKey(typeof(T)))
			{
				var componentList = new ComponentList<T>();
				componentLists.Add(componentList);
				componentListsByType.Add(typeof(T), componentList);
				currentComponentID++;

				return currentComponentID;
			}
			
			return componentListsByType.Keys.ToList().IndexOf(typeof(T));
		}

		public Manager AddComponent<T>(int entityID, T component) where T : struct
		{
			if (componentListsByType.TryGetValue(typeof(T), out var componentList))
			{
				componentList.Add(entityID, component);
			}
			else
			{
				componentList = new ComponentList<T>();
				componentLists.Add(componentList);
				componentListsByType.Add(typeof(T), componentList);
				componentList.Add(entityID, component);
			}
			
			return this;
		}
	}

}
