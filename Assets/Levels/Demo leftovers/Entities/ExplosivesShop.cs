using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odyssey
{
	public class ExplosivesShop : MonoBehaviour
	{
		// Editor components
		[SerializeField] private Sprite spriteShutDown;

		public void Explode()
		{
			GetComponent<SpriteRenderer>().sprite = spriteShutDown;
		}
	}
}