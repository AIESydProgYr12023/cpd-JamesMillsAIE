using System;

using Object = UnityEngine.Object;

namespace AIE07_ProgrammingPatterns
{
	[Serializable]
	public struct FactoryObject
	{
		public Object createable;
		public string key;
	}
}