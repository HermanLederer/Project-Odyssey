using UnityEngine;
using UnityEngine.Playables;

namespace Odyssey
{
	public class House2Explosion : StateMachineBehaviour
	{
		// Editor fields
		[SerializeField] public PlayableAsset cutscene;

		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameManager.Instance.Ask(cutscene, "Owner of House 3 exploded House 2!! Should we shut down the explosive shop?");
		}
	}
}
