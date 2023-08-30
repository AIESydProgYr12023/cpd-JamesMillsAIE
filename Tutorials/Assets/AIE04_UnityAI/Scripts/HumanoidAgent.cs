using AIE04_UnityAI.StateMachines;

using UnityEngine;
using UnityEngine.AI;

namespace AIE04_UnityAI
{
	[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
	public class HumanoidAgent : MonoBehaviour
	{
		public NavMeshAgent NavigationAgent { get; private set; }

		[SerializeField] private new Camera camera;

		private Animator animator;
		private StateMachineAgent stateMachine;

		private void Awake()
		{
			NavigationAgent = gameObject.GetComponent<NavMeshAgent>();
			animator = gameObject.GetComponent<Animator>();

			stateMachine = animator.GetBehaviour<StateMachineAgent>();
		}

		private void Update()
		{
			if(Input.GetMouseButtonDown(0))
			{
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out RaycastHit hit))
				{
					stateMachine.SetTarget(hit.point);
				}
			}
		}
	}
}