using UnityEngine;
using UnityEngine.EventSystems;

namespace AIE03_MobileJoystick
{
	public class MobileJoystick : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
	{
		public Vector2 Value { get; private set; }

		[SerializeField] private RectTransform handle;
		[SerializeField] private RectTransform background;
		[SerializeField, Range(0, 1)] private float deadZone = .25f;

		private Vector3 initialPos;
		private Vector2 sizeDifference;

		private void Start()
		{
			initialPos = handle.position;
			sizeDifference = new Vector2
			{
				x = (background.rect.size.x - handle.rect.size.x) * .5f,
				y = (background.rect.size.y - handle.rect.size.y) * .5f
			};
		}

		public void OnDrag(PointerEventData _eventData)
		{
			Value = Vector2.ClampMagnitude(new Vector2
			{
				x = (_eventData.position.x - background.position.x) / sizeDifference.x,
				y = (_eventData.position.y - background.position.y) / sizeDifference.y
			}, 1);

			handle.position = new Vector3
			{
				x = Value.x * sizeDifference.x + background.position.x,
				y = Value.y * sizeDifference.y + background.position.y
			};

			Value = Value.magnitude < deadZone ? Vector2.zero : Value;
		}

		public void OnEndDrag(PointerEventData _eventData)
		{
			Value = Vector2.zero;
			handle.position = initialPos;
		}

		public void OnPointerDown(PointerEventData _eventData) => OnDrag(_eventData);

		public void OnPointerUp(PointerEventData _eventData) => OnEndDrag(_eventData);
	}
}