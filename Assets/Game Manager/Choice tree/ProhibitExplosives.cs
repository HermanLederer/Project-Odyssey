using UnityEngine;
using UnityEngine.Playables;

namespace Odyssey
{
	public class ProhibitExplosives : StateMachineBehaviour
	{
		// Editor fields
		[SerializeField] public PlayableAsset cutscene;

		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameManager.Instance.Ask(cutscene, "Without that shop our town is getting poor. Should we sell our museum?");
		}
	}
}
