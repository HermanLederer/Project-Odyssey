using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

namespace Odyssey
{
	[RequireComponent(typeof(PlayableDirector))]
	[RequireComponent(typeof(Animator))]
	public class GameManager : MonoBehaviour
	{
		// Editor fields
		[Header("Set this per level")]
		[SerializeField] private UIIngame ui;

		// Other components
		private PlayableDirector playableDirector;
		private Animator choiceTree;

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

			playableDirector = GetComponent<PlayableDirector>();
			choiceTree = GetComponent<Animator>();
		}

		private void Start()
		{

		}

		private void Update()
		{

		}

		#endregion

		#region GameManager methods

		public void MakeCoice1() => choiceTree.SetTrigger("Choice1");

		public void MakeCoice2() => choiceTree.SetTrigger("Choice2");

		public void Ask(string question) => ui.Ask(question);

		public void Ask(PlayableAsset playable, string question)
		{
			playableDirector.playableAsset = playable;
			StartCoroutine(PlayPlayableAndAsk(question));
		}

		private IEnumerator PlayPlayableAndAsk(string question)
		{
			UIIngame.Instance.Hide();
			playableDirector.Play();
			yield return new WaitForSeconds((float) playableDirector.duration);
			Ask(question);
		}

		public void End()
		{
			SceneManager.LoadScene("Endscreen");
			Instance = null;
		}

		#endregion
	}
}

