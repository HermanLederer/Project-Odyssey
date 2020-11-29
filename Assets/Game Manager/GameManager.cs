using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odyssey
{
	public class GameManager : MonoBehaviour
	{
		// Editor fields
		[SerializeField] private GameObject speechBubble;

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
			PresentChoiceConsequences();
		}

		public void MakeCoice2()
		{
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
			yield return new WaitForSeconds(1f);
			SpeechBubble.Instance.Show();
		}

		#endregion
	}
}

