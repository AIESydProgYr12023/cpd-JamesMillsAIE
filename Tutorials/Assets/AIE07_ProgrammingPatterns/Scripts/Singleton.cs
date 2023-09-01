using System;

using UnityEngine;

namespace AIE07_ProgrammingPatterns
{
	public abstract class Singleton<TYPE> : MonoBehaviour
		where TYPE : Singleton<TYPE>
	{
		public static TYPE Instance { get; private set; }

		public static bool IsValid() => Instance != null;

		protected void MarkPersistant() => DontDestroyOnLoad(gameObject);

		protected virtual void OnAwake() { }
		protected virtual void OnDestroyed() { }

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = (TYPE) this;
			}
			else
			{
				Debug.LogException(new InvalidOperationException($"Singleton of type: {typeof(TYPE).Name} already initialized!"));
				Destroy(gameObject);

				return;
			}
			
			OnAwake();
		}

		private void OnDestroy()
		{
			if(Instance == this)
			{
				OnDestroyed();
				Instance = null;
			}
		}
	}
}