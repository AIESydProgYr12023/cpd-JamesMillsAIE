using System.Collections.Generic;

using UnityEngine;

namespace AIE07_ProgrammingPatterns
{
	public class Factory : InitializeBehaviour
	{
		[SerializeField] private List<FactoryObject> objects;

		private readonly Dictionary<string, Object> factoryObjects = new();
		
		#nullable enable
		public T? Create<T>(string _id) where T : Object
		{
			if(factoryObjects.TryGetValue(_id, out Object obj))
				return Instantiate(obj) as T;

			return default;
		}
		#nullable disable

		protected override void OnInit(params object[] _params)
		{
			foreach(FactoryObject obj in objects)
			{
				if(!factoryObjects.ContainsKey(obj.key))
					factoryObjects.Add(obj.key, obj.createable);
			}
		}
	}
}