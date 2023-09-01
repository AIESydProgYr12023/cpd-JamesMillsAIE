using UnityEngine;

namespace AIE03_MobileJoystick
{
	public class PlayerController : MonoBehaviour
	{
		private MobileJoystick joystick;

		private void Start() => joystick = FindObjectOfType<MobileJoystick>();

		private void Update()
		{
			Vector2 axis = joystick.Value;
			transform.position += (transform.right * axis.x + transform.forward * axis.y) * Time.deltaTime;
		}
	}
}