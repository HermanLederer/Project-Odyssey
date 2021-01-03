using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odyssey
{
	[CreateAssetMenu(fileName = "New Game Data", menuName = "Odyssey/Game Data")]
	public class GameData : ScriptableObject
	{
		public string finalMessage;
		public bool isRealEndingFound;
	}
}

