using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odyssey
{
	public class SpeechBubble : MonoBehaviour
	{
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

		private void Start()
		{

		}

		private void Update()
		{

		}

		#endregion

		#region SpeechBubble methods

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		#endregion
	}
}
