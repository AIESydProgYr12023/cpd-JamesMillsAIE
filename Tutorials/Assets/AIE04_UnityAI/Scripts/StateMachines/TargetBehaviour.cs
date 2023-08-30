using UnityEngine;

namespace AIE04_UnityAI.StateMachines
{
	public class TargetBehaviour : StateMachineBehaviour
	{
		private static readonly int targetingHash = Animator.StringToHash("Targeting");

		private StateMachineAgent stateMachine;
		
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			stateMachine = _animator.GetBehaviour<StateMachineAgent>();

			stateMachine.NavigationAgent.SetDestination(stateMachine.Target);
		}

		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			if(!stateMachine.NavigationAgent.hasPath)
				_animator.SetBool(targetingHash, false);
		}
	}
}