using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Odyssey
{
	public class SpeechBubble : MonoBehaviour
	{
		// Editor fields
		[SerializeField] private Text question;

		public static SpeechBubble Instance { get; private set; }

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

		#endregion

		#region SpeechBubble methods

		public void Ask(string question)
		{
			this.question.text = question;
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		#endregion
	}
}
