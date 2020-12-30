using UnityEngine;
using UnityEngine.Playables;

namespace Odyssey
{
	public class TreeEnding : StateMachineBehaviour
	{
		// Editor fields
		[SerializeField]
		public PlayableAsset cutscene;
		[SerializeField]
		[TextArea(3,10)]
		public string finalMessage;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameManager.Instance.End();
		}
	}
}
