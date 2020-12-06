using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIActions : MonoBehaviour
{
	public void GotoLevel1()
	{
		SceneManager.LoadScene("Game");
	}

	public void GoooEndscreen()
	{
		SceneManager.LoadScene("Endscreen");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
