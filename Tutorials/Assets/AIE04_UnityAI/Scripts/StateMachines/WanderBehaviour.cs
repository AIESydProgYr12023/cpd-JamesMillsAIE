using UnityEngine;
using UnityEngine.AI;

namespace AIE04_UnityAI.StateMachines
{
	public class WanderBehaviour : StateMachineBehaviour
	{
		private NavMeshAgent agent;
		
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			agent = _animator.GetBehaviour<StateMachineAgent>().NavigationAgent;
		}

		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			if(!agent.hasPath)
			{
				Vector3 pos = Random.onUnitSphere * 5 + agent.transform.position;
				agent.SetDestination(pos);
			}
		}
	}
}