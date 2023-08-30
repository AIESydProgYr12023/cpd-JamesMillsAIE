using UnityEngine;
using UnityEngine.AI;

namespace AIE04_UnityAI.StateMachines
{
	public class StateMachineAgent : StateMachineBehaviour
	{
		private static readonly int targetingHash = Animator.StringToHash("Targeting");
		
		public Vector3 Target { get; private set; }
		public NavMeshAgent NavigationAgent { get; private set; }

		private Animator animator;

		public void SetTarget(Vector3 _target)
		{
			Target = _target;
			animator.SetBool(targetingHash, true);
		}
		
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			NavigationAgent = _animator.GetComponent<HumanoidAgent>().NavigationAgent;
			animator = _animator;
		}
	}
}