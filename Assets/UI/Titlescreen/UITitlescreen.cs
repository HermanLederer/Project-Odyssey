using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Odyssey
{
	[RequireComponent(typeof(UIDocument))]
	[RequireComponent(typeof(AudioSource))]
	public class UITitlescreen : MonoBehaviour
	{
		// TODO: Get rid of this
		[SerializeField] Demo.GameSceneNameContainer demoSceneNameContainer;

		VisualElement m_Titlescreen;
		VisualElement m_MainMenu;
		VisualElement m_LevelSelector;

		// UI Audio
		AudioSource audioSource;
		[Header("Audio clips")]
		[SerializeField] AudioClip click;

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
		}

		private void OnEnable()
		{
			m_Titlescreen = GetComponent<UIDocument>().rootVisualElement;
			m_MainMenu = m_Titlescreen.Q("main-menu");
			m_LevelSelector = m_Titlescreen.Q("level-selector");

			// Main menu
			m_Titlescreen.Q<Button>("button-play").RegisterCallback<ClickEvent>(ev => TitlescreenLevelSelector());
			m_Titlescreen.Q<Button>("button-momentum").RegisterCallback<ClickEvent>(ev => Learn());
			m_Titlescreen.Q<Button>("button-quit").RegisterCallback<ClickEvent>(ev => ExitGame());

			// Level selector
			m_Titlescreen.Q<Button>("button-level1").RegisterCallback<ClickEvent>(ev => GotoLevel1());
		}

		public void TitlescreenLevelSelector()
		{
			audioSource.PlayOneShot(click);
			m_MainMenu.style.display = DisplayStyle.None;
			m_LevelSelector.style.display = DisplayStyle.Flex;
		}

		public void TitlescreenMainMenu()
		{
			audioSource.PlayOneShot(click);
			m_LevelSelector.style.display = DisplayStyle.None;
			m_MainMenu.style.display = DisplayStyle.Flex;
		}

		private void Learn()
		{
			audioSource.PlayOneShot(click);
			Application.OpenURL("https://prod-v3.odyssey.ninja/");
		}

		public void GotoLevel1() => StartCoroutine(PlayClickAndGotoLevel1());

		IEnumerator PlayClickAndGotoLevel1()
		{
			audioSource.PlayOneShot(click);
			yield return new WaitForSeconds(click.length);
			SceneManager.LoadScene(demoSceneNameContainer.gameSceneName);
		}

		public void ExitGame() => StartCoroutine(PlayClickAndQuit());

		IEnumerator PlayClickAndQuit()
		{
			audioSource.PlayOneShot(click);
			yield return new WaitForSeconds(click.length);
			Application.Quit();
		}
	}
}