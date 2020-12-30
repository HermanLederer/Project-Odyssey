using UnityEngine;
using UnityEngine.Playables;

namespace Odyssey
{
	public class TreeChoice : StateMachineBehaviour
	{
		// Editor fields
		[SerializeField]
		public PlayableAsset cutscene;
		[SerializeField]
		[TextArea(3,10)]
		public string nextQuestion;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (cutscene) GameManager.Instance.Ask(cutscene, nextQuestion);
			else GameManager.Instance.Ask(nextQuestion);
		}
	}
}
