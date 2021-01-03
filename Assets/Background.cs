using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Background : MonoBehaviour
{
	// Editor components
	[SerializeField] private Sprite spriteNormal;
	[SerializeField] private Sprite spriteContaminated;
	[SerializeField] private Light2D sun;

	public void Start()
	{
		Naturalize();
	}

	public void Naturalize()
	{
		GetComponent<SpriteRenderer>().sprite = spriteNormal;
		sun.intensity = 1f;
	}

	public void Contaminate()
	{
		GetComponent<SpriteRenderer>().sprite = spriteContaminated;
		sun.intensity = 0.8f;
	}
}
