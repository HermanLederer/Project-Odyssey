using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineProtectionArea : MonoBehaviour
{
	public void Start()
	{
		ShutDown();
	}

	public void Open()
	{
		GetComponentInChildren<SpriteRenderer>().enabled = true;
	}

	public void ShutDown()
	{
		GetComponentInChildren<SpriteRenderer>().enabled = false;
	}
}
