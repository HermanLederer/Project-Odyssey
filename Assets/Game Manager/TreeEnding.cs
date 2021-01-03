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
		[SerializeField]
		public bool isRealEnding;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (cutscene) GameManager.Instance.End(cutscene, finalMessage.Replace("\n", "").Replace("\r", ""), isRealEnding);
			else GameManager.Instance.End(finalMessage.Replace("\n", "").Replace("\r", ""), isRealEnding);
		}
	}
}
