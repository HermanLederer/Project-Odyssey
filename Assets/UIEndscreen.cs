using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Odyssey
{
	public class UIEndscreen : MonoBehaviour
	{
		VisualElement m_Endscreen;
		Label m_TitleLabel;
		Label m_DescriptionLabel;
		Label m_ContinueButton;

		#region MonoBehaviour methods

		private void OnEnable()
		{
			m_Endscreen = GetComponent<UIDocument>().rootVisualElement;
			m_TitleLabel = m_Endscreen.Q<Label>("label-question");

			// Main menu
			//m_Endscreen.Q("button-share").RegisterCallback<ClickEvent>(ev => Share());
			m_Endscreen.Q("button-continue").RegisterCallback<ClickEvent>(ev => Continue());
			m_Endscreen.Q("button-again").RegisterCallback<ClickEvent>(ev => PlayAgain());
		}

		#endregion

		#region SpeechBubble methods

		private void Continue()
		{
			SceneManager.LoadScene("Titlescreen");
		}

		private void PlayAgain()
		{
			SceneManager.LoadScene("Game");
		}

		public void Ask(string question)
		{
			m_TitleLabel.text = question;
			m_Endscreen.style.display = DisplayStyle.Flex;
		}

		public void Hide()
		{
			m_Endscreen.style.display = DisplayStyle.None;
		}

		#endregion
	}
}
