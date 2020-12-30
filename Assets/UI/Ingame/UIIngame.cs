using UnityEngine;
using UnityEngine.UIElements;

namespace Odyssey
{
	[RequireComponent(typeof(UIDocument))]
	public class UIIngame : MonoBehaviour
	{
		VisualElement m_Ingame;
		Label m_QuestionLabel;

		public static UIIngame Instance { get; private set; }

		#region MonoBehaviour methods

		private void Awake()
		{
			if (Instance != null)
			{
				Destroy(this);
				return;
			}

			Instance = this;
		}

		private void OnEnable()
		{
			m_Ingame = GetComponent<UIDocument>().rootVisualElement;
			m_QuestionLabel = m_Ingame.Q<Label>("label-question");

			// Main menu
			m_Ingame.Q("yes").RegisterCallback<ClickEvent>(ev => ChoseYes());
			m_Ingame.Q("no").RegisterCallback<ClickEvent>(ev => ChoseNo());
		}

		#endregion

		#region UIIngame methods

		private void ChoseYes()
		{
			GameManager.Instance.MakeCoice1();
		}

		private void ChoseNo()
		{
			GameManager.Instance.MakeCoice2();
		}

		public void Ask(string question)
		{
			m_QuestionLabel.text = question;
			m_Ingame.style.display = DisplayStyle.Flex;
		}

		public void Hide()
		{
			m_Ingame.style.display = DisplayStyle.None;
		}

		#endregion
	}
}
