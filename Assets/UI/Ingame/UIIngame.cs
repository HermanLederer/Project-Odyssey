using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Odyssey
{
	[RequireComponent(typeof(UIDocument))]
	public class UIIngame : MonoBehaviour
	{
		// TODO: Get rid of demoSceneNameContainer
		[SerializeField] Demo.GameSceneNameContainer demoSceneNameContainer;

		// UI container
		VisualElement m_Ingame;

		// Question UI
		VisualElement m_Question;
		Label m_QuestionLabel;

		// Ending UI
		VisualElement m_RealEnding;
		VisualElement m_FalseEnding;

		// Info UI
		VisualElement m_Info;

		// Singleton
		//public static UIIngame Instance { get; private set; }

		#region MonoBehaviour methods

		private void Awake()
		{
			//if (Instance != null)
			//{
			//	Destroy(this);
			//	return;
			//}

			//Instance = this;
		}

		private void OnEnable()
		{
			// UI elements
			m_Ingame = GetComponent<UIDocument>().rootVisualElement;
			m_Question = m_Ingame.Q("question");
			m_QuestionLabel = m_Ingame.Q<Label>("label-question");
			m_RealEnding = m_Ingame.Q("real-ending");
			m_FalseEnding = m_Ingame.Q("false-ending");
			m_Info = m_Ingame.Q("info");
			
			// Question
			m_Question.Q("yes").RegisterCallback<ClickEvent>(ev => ChoseYes());
			m_Question.Q("no").RegisterCallback<ClickEvent>(ev => ChoseNo());

			// Endings
			m_RealEnding.Q("button-share").RegisterCallback<ClickEvent>(ev => Share());
			m_RealEnding.Q("button-continue").RegisterCallback<ClickEvent>(ev => OpenMainMenu());

			m_FalseEnding.Q("button-share").RegisterCallback<ClickEvent>(ev => Share());
			m_FalseEnding.Q("button-continue").RegisterCallback<ClickEvent>(ev => OpenMainMenu());
			m_FalseEnding.Q("button-again").RegisterCallback<ClickEvent>(ev => InviteToMomentum());
		}

		#endregion

		#region UIIngame methods

		private void ChoseYes()
		{
			if (GameManager.Instance) GameManager.Instance.MakeCoice1();
		}

		private void ChoseNo()
		{
			if (GameManager.Instance) GameManager.Instance.MakeCoice2();
		}

		public void Ask(string question)
		{
			m_QuestionLabel.text = question;
			m_Question.style.display = DisplayStyle.Flex;
		}

		public void HideQuestion()
		{
			m_Question.style.display = DisplayStyle.None;
		}

		public void End(string finalMessage, bool isRealEnding)
		{
			m_Question.style.display = DisplayStyle.None;

			if (isRealEnding)
			{
				m_RealEnding.Q<Label>("label-final-message").text = finalMessage;
				m_RealEnding.style.display = DisplayStyle.Flex;
			}
			else // false ending
			{
				m_FalseEnding.Q<Label>("label-final-message").text = finalMessage;
				m_FalseEnding.style.display = DisplayStyle.Flex;
			}
		}

		private void InviteToMomentum()
		{
			m_Info.style.display = DisplayStyle.Flex;
			m_Question.style.display = DisplayStyle.Flex;
			m_QuestionLabel.text = "Visit Odyssey Momemntum?";

			m_Question.Q("yes").RegisterCallback<ClickEvent>(ev => { OpenMomentum(); Restart(); });
			m_Question.Q("no").RegisterCallback<ClickEvent>(ev => Restart());
		}

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

		#endregion
	}
}
