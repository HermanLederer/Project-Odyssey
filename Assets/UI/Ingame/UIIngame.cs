using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Odyssey
{
	[RequireComponent(typeof(UIDocument))]
	[RequireComponent(typeof(AudioSource))]
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

		// UI Audio
		AudioSource audioSource;
		[Header("Audio clips")]
		[SerializeField] AudioClip click;
		[SerializeField] AudioClip clickYes;
		[SerializeField] AudioClip clickNo;
		[SerializeField] AudioClip win;
		[SerializeField] AudioClip lose;

		#region MonoBehaviour methods

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
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
			if (GameManager.Instance)
			{
				GameManager.Instance.MakeCoice1();
				audioSource.PlayOneShot(clickYes);
			}
		}

		private void ChoseNo()
		{
			if (GameManager.Instance)
			{
				GameManager.Instance.MakeCoice2();
				audioSource.PlayOneShot(clickNo);
			}

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
				audioSource.PlayOneShot(win);
			}
			else // false ending
			{
				m_FalseEnding.Q<Label>("label-final-message").text = finalMessage;
				m_FalseEnding.style.display = DisplayStyle.Flex;
				audioSource.PlayOneShot(lose);
			}
		}

		private void InviteToMomentum()
		{
			m_RealEnding.style.display = DisplayStyle.None;
			m_FalseEnding.style.display = DisplayStyle.None;
			m_Info.style.display = DisplayStyle.Flex;
			m_Question.style.display = DisplayStyle.Flex;
			m_QuestionLabel.text = "Visit Odyssey Momemntum?";

			m_Question.Q("yes").RegisterCallback<ClickEvent>(ev => { OpenMomentum(); Restart(); });
			m_Question.Q("no").RegisterCallback<ClickEvent>(ev => Restart());
		}

		private void Share()
		{
			audioSource.PlayOneShot(click);
			Application.OpenURL("https://twitter.com/");
		}

		private void OpenMomentum()
		{
			Application.OpenURL("https://prod-v3.odyssey.ninja/");
		}

		private void OpenMainMenu()
		{
			audioSource.PlayOneShot(click);
			SceneManager.LoadScene("Titlescreen");
		}

		private void Restart()
		{
			audioSource.PlayOneShot(click);
			SceneManager.LoadScene(demoSceneNameContainer.gameSceneName);
		}

		#endregion
	}
}
