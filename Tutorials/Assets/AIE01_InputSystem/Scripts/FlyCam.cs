using UnityEngine;
using UnityEngine.InputSystem;

namespace AIE01_InputSystem
{
	[RequireComponent(typeof(Camera))]
	public class FlyCam : MonoBehaviour
	{
		public static bool Focused
		{
			get => Cursor.lockState == CursorLockMode.Locked;
			set
			{
				Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
				Cursor.visible = !value;
			}
		}

		[SerializeField] private float acceleration = 10;
		[SerializeField] private float sprintMultiplier = 4;
		[SerializeField] private float lookSensitivity = 0.1f;
		[SerializeField] private float dampingCoefficient = 5f;

		[Header("Input Actions")]
		[SerializeField] private bool usePlayerInputComponent = true;
		[SerializeField] private InputActionReference horizontalMoveAction;
		[SerializeField] private InputActionReference verticalMoveAction;
		[SerializeField] private InputActionReference focusAction;
		[SerializeField] private InputActionReference lookAction;
		[SerializeField] private InputActionReference sprintAction;

		private Vector3 velocity;
		private bool isSprinting;

		private void OnEnable()
		{
			if(!usePlayerInputComponent)
			{
				horizontalMoveAction.action.Enable();
				verticalMoveAction.action.Enable();
				focusAction.action.Enable();
				lookAction.action.Enable();
				sprintAction.action.Enable();
			}

			lookAction.action.performed += OnLookPerformed;
			sprintAction.action.performed += OnSprintPerformed;
			sprintAction.action.canceled += OnSprintCanceled;
		}

		private void OnDisable()
		{
			if(!usePlayerInputComponent)
			{
				horizontalMoveAction.action.Disable();
				verticalMoveAction.action.Disable();
				focusAction.action.Disable();
				lookAction.action.Disable();
				sprintAction.action.Disable();
			}

			lookAction.action.performed -= OnLookPerformed;
			sprintAction.action.performed -= OnSprintPerformed;
			sprintAction.action.canceled -= OnSprintCanceled;
		}

		private void Update()
		{
			Focused = focusAction.action.IsPressed();
			
			if(Focused)
				UpdateVelocity();

			velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime);
			transform.position += velocity * Time.deltaTime;
		}

		private void UpdateVelocity()
		{
			velocity += GetAccelerationVector() * Time.deltaTime;
		}

		private Vector3 GetAccelerationVector()
		{
			Vector3 moveInput = Vector3.zero;

			void AddMovement(float _value, Vector3 _dir)
			{
				moveInput += _dir * _value;
			}

			Vector2 horiInput = horizontalMoveAction.action.ReadValue<Vector2>();
			float vertInput = verticalMoveAction.action.ReadValue<float>();
			
			AddMovement(horiInput.x, Vector3.right);
			AddMovement(horiInput.y, Vector3.forward);
			AddMovement(vertInput, Vector3.up);

			Vector3 direction = transform.TransformVector(moveInput.normalized);
			return direction * (acceleration * (isSprinting ? sprintMultiplier : 1f));
		}

		private void OnLookPerformed(InputAction.CallbackContext _context)
		{
			if(!Focused)
				return;

			Vector2 lookDelta = lookSensitivity * _context.ReadValue<Vector2>();

			Quaternion rotation = transform.rotation;
			Quaternion hori = Quaternion.AngleAxis(lookDelta.x, Vector3.up);
			Quaternion vert = Quaternion.AngleAxis(lookDelta.y, Vector3.left);
			transform.rotation = hori * rotation * vert;
		}

		private void OnSprintPerformed(InputAction.CallbackContext _context) => isSprinting = true;
		private void OnSprintCanceled(InputAction.CallbackContext _context) => isSprinting = false;
	}
}