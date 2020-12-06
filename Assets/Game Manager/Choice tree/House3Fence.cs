using UnityEngine;
using UnityEngine.Playables;

namespace Odyssey
{
	public class House3Fence : StateMachineBehaviour
	{
		// Editor fields
		[SerializeField] public PlayableAsset cutscene;

		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameManager.Instance.Ask(cutscene, "We spent too much money on that fence! Should we sell our museum?");
		}
	}
}
