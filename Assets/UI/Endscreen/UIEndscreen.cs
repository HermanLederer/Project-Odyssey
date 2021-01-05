using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Odyssey
{
	public class UIEndscreen : MonoBehaviour
	{
		// TODO: Get rid of demoSceneNameContainer
		[SerializeField] Demo.GameSceneNameContainer demoSceneNameContainer;
		[SerializeField] GameData gameData;
		
		VisualElement m_Endscreen;
		VisualElement m_EndingPanel;
		VisualElement m_RealEndingPanel;
		VisualElement m_FalseEndingPanel;
		VisualElement m_MomentumPanel;

		#region MonoBehaviour methods

		private void OnEnable()
		{
			m_Endscreen = GetComponent<UIDocument>().rootVisualElement;

			m_EndingPanel = m_Endscreen.Q("ending-panel");
			m_RealEndingPanel = m_EndingPanel.Q("real-ending");
			m_FalseEndingPanel = m_EndingPanel.Q("false-ending");
			m_MomentumPanel = m_Endscreen.Q("visit-momentum");

			// Ending panel
			if (gameData.isRealEndingFound)
			{
				m_RealEndingPanel.Q<Label>("label-final-message").text = gameData.finalMessage;

				m_RealEndingPanel.Q("button-share").RegisterCallback<ClickEvent>(ev => Share());
				m_RealEndingPanel.Q("button-continue").RegisterCallback<ClickEvent>(ev => OpenMainMenu());

				m_RealEndingPanel.style.display = DisplayStyle.Flex;
			}
			else // false ending
			{
				m_FalseEndingPanel.Q<Label>("label-final-message").text = gameData.finalMessage;

				m_FalseEndingPanel.Q("button-share").RegisterCallback<ClickEvent>(ev => Share());
				m_FalseEndingPanel.Q("button-continue").RegisterCallback<ClickEvent>(ev => OpenMainMenu());
				m_FalseEndingPanel.Q("button-again").RegisterCallback<ClickEvent>(ev => InviteToMomentum());

				m_MomentumPanel.Q("yes").RegisterCallback<ClickEvent>(ev => { OpenMomentum(); Restart(); });
				m_MomentumPanel.Q("no").RegisterCallback<ClickEvent>(ev => Restart());

				m_FalseEndingPanel.style.display = DisplayStyle.Flex;
			}
		}

		#endregion

		#region UIEndscreen methods

		private void Share()
		{
			Application.OpenURL("https://twitter.com/");
		}

		private void OpenMomentum()
		{
			Application.OpenURL("https://prod-v3.odyssey.ninja/");
		}

		private void OpenMainMenu()
		{
			SceneManager.LoadScene("Titlescreen");
		}

		private void Restart()
		{
			SceneManager.LoadScene(demoSceneNameContainer.gameSceneName);
		}

		private void InviteToMomentum()
		{
			m_EndingPanel.style.display = DisplayStyle.None;
			m_MomentumPanel.style.display = DisplayStyle.Flex;
		}


		#endregion
	}
}
