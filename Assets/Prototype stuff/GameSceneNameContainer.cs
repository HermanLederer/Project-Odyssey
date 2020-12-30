using UnityEngine;
using UnityEngine.SceneManagement;

namespace Odyssey.Demo
{
	/// <summary>
	/// Is only meant to be used until the ability to have multiple levels is implemented!
	/// Helps renaimng the scenes and switching which one the game goes to when you start playing
	/// there is only one place where you need to set the name of the scene and it is here.
	/// Sorry for incoherent explanation, but this is menat to be deleted anyway.
	/// </summary>
	[CreateAssetMenu(fileName = "New Demo Scene Container", menuName = "Odyssey/Demo/Demo Scene Container")]
	public class GameSceneNameContainer : ScriptableObject
	{
		public string gameSceneName;
	}
}

