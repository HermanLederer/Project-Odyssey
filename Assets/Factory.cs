using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	// Editor components
	[SerializeField] private Sprite spriteOpen;
	[SerializeField] private Sprite spriteShutDown;
	[SerializeField] private ParticleSystem smokeParticles;

	public void Start()
	{
		Open();
	}

	public void Open()
	{
		GetComponent<SpriteRenderer>().sprite = spriteOpen;
		smokeParticles.Play();
	}

	public void ShutDown()
	{
		GetComponent<SpriteRenderer>().sprite = spriteShutDown;
		smokeParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
