using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Factory : MonoBehaviour
{
	private AudioSource audioSource;

	// Editor properties
	[SerializeField] private Sprite spriteOpen;
	[SerializeField] private Sprite spriteShutDown;
	[SerializeField] private Sprite spriteAbandoned;
	[SerializeField] private ParticleSystem smokeParticles;
	[SerializeField] private ParticleSystem smokeParticles2;

	public void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void Start()
	{
		Open();
	}

	public void Open()
	{
		GetComponent<SpriteRenderer>().sprite = spriteOpen;
		smokeParticles.Play();
		audioSource.Play();
	}

	public void ShutDown()
	{
		GetComponent<SpriteRenderer>().sprite = spriteShutDown;
		smokeParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		StartCoroutine(FadeOutPresenceLoop(audioSource.volume));
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

	private IEnumerator FadeOutPresenceLoop(float startVolume)
	{
		var fade = 1f;
		while (fade > 0f)
		{
			fade -= 2 * Time.deltaTime;
			audioSource.volume = startVolume * fade;
			yield return null;
		}

		audioSource.Stop();
	}
}
