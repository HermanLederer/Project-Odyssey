using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Odyssey
{
	public class GameManager : MonoBehaviour
	{
		// Editor fields
		[SerializeField] private SpeechBubble speechBubble;
		[SerializeField] private PlayableDirector playableDirector;
		[SerializeField] private PlayableAsset playableOption1;
		[SerializeField] private PlayableAsset playableOption2;

		public static GameManager Instance { get; private set; }

		#region MonoBehaviour methods

		private void Awake()
		{
			if (Instance != null)
			{
				Destroy(this);
				return;
			}

			Instance = this;
			DontDestroyOnLoad(this);
		}

		private void Start()
		{

		}

		private void Update()
		{

		}

		#endregion

		#region GameManager methods

		public void MakeCoice1()
		{
			playableDirector.playableAsset = playableOption1;
			PresentChoiceConsequences();
		}

		public void MakeCoice2()
		{
			playableDirector.playableAsset = playableOption2;
			PresentChoiceConsequences();
		}

		public void PresentChoice()
		{
			SpeechBubble.Instance.Show();
		}

		public void PresentChoiceConsequences()
		{
			StartCoroutine(ShowChoiceConsequences());
		}

		private IEnumerator ShowChoiceConsequences()
		{
			SpeechBubble.Instance.Hide();
			playableDirector.Play();
			yield return new WaitForSeconds((float) playableDirector.duration);
			SpeechBubble.Instance.Show();
		}

		#endregion
	}
}

