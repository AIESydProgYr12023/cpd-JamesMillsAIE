using UnityEngine;

namespace AIE07_ProgrammingPatterns
{
	public abstract class InitializeBehaviour : MonoBehaviour, IInitializer
	{
		public bool Initialized { get; private set;  }

		public void Initialize(params object[] _params)
		{
			if(Initialized)
			{
				Debug.LogWarning($"Object {name} has already been initialized!", gameObject);

				return;
			}

			Initialized = true;
			OnInit(_params);
		}

		protected abstract void OnInit(params object[] _params);
	}
}