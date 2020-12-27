using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UITitlescreen : MonoBehaviour
{
	VisualElement m_Titlescreen;
	VisualElement m_MainMenu;
	VisualElement m_LevelSelector;

	private void OnEnable()
	{
		m_Titlescreen = GetComponent<UIDocument>().rootVisualElement;
		m_MainMenu = m_Titlescreen.Q("main-menu");
		m_LevelSelector = m_Titlescreen.Q("level-selector");

		// Main menu
		m_Titlescreen.Q<Button>("button-play").RegisterCallback<ClickEvent>(ev => TitlescreenLevelSelector());
		//titlescreen.Q<Button>("button-momentum").RegisterCallback<ClickEvent>(ev => TitlescreenLevelSelector());
		m_Titlescreen.Q<Button>("button-quit").RegisterCallback<ClickEvent>(ev => ExitGame());

		// Level selector
		m_Titlescreen.Q<Button>("button-level1").RegisterCallback<ClickEvent>(ev => GotoLevel1());
	}

	public void TitlescreenLevelSelector()
	{
		m_MainMenu.style.display = DisplayStyle.None;
		m_LevelSelector.style.display = DisplayStyle.Flex;
	}

	public void TitlescreenMainMenu()
	{
		m_LevelSelector.style.display = DisplayStyle.None;
		m_MainMenu.style.display = DisplayStyle.Flex;
	}

	public void GotoLevel1()
	{
		SceneManager.LoadScene("Game");
	}

	public void GoToEndscreen()
	{
		SceneManager.LoadScene("Endscreen");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
