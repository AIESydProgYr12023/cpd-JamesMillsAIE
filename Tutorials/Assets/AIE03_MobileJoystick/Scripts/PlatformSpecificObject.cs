using UnityEngine;

namespace AIE03_MobileJoystick
{
	public class PlatformSpecificObject : MonoBehaviour
	{
		public enum Platform
		{
			WebGL,
			PC,
			Android
		}

		[SerializeField] private Platform platform;

		private void Awake()
		{
		#if UNITY_ANDROID
			gameObject.SetActive(platform == Platform.Android);
		#elif UNITY_WEBGL
			gameObject.SetActive(platform == Platform.WebGL);
		#else
			gameObject.SetActive(platform == Platform.PC);
		#endif
		}
	}
}