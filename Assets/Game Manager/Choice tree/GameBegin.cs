using UnityEngine;

namespace Odyssey
{
	public class GameBegin : StateMachineBehaviour
	{
		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameManager.Instance.Ask("The owner of House 3 hates their neighbor in House 2. Should we finance House 3 to build a fence?");
		}
	}

}