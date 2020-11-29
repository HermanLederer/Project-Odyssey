using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Editor fields
	[SerializeField] private GameObject speechBubble;

	public GameManager Instance { get; private set; }

	#region MonoBehaviour methods

	private void Awake()
	{
		if (Instance == null)
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

	#region GameManager methods

	public void PresentChoice()
	{
		
	}

	public void PresentChoiceConsequences()
	{

	}

	#endregion
}
