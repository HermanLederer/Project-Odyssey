using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	// Editor components
	[SerializeField] private Sprite spriteOpen;
	[SerializeField] private Sprite spriteShutDown;
	[SerializeField] private Sprite spriteAbandoned;
	[SerializeField] private ParticleSystem smokeParticles;
	[SerializeField] private ParticleSystem smokeParticles2;

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

	public void Abandon()
	{
		GetComponent<SpriteRenderer>().sprite = spriteAbandoned;
		smokeParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}

	public void IncreaseProduction()
	{
		smokeParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		smokeParticles2.Play(true);
	}
}
