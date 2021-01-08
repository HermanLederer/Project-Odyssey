using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poppable : MonoBehaviour
{
	[SerializeField] protected ParticleSystem appearParticles = null;
	[SerializeField] protected Transform spriteTransform = null;
	[SerializeField] protected AudioSource popAudioSource = null;
	[SerializeField] protected AudioSource presenceAudioSource = null;
	[SerializeField] protected AudioClip spawnSound = null;
	[SerializeField] protected AudioClip presenceLoop = null;
	[SerializeField] protected bool hideOnStart = false;

	private float initialPresenceVolume = 0;

	public void Start()
	{
		if (presenceAudioSource) initialPresenceVolume = presenceAudioSource.volume;

		if (hideOnStart)
			spriteTransform.gameObject.SetActive(false);
	}

	public virtual void PopIn()
	{
		spriteTransform.gameObject.SetActive(true);
		appearParticles.Play();
		popAudioSource.PlayOneShot(spawnSound);
		if (presenceAudioSource)
		{
			presenceAudioSource.clip = presenceLoop;
			presenceAudioSource.volume = initialPresenceVolume;
			presenceAudioSource.Play();
		}
	}

	public virtual void PopOut()
	{
		spriteTransform.gameObject.SetActive(false);
		appearParticles.Play();
		popAudioSource.PlayOneShot(spawnSound);
		if (presenceAudioSource) StartCoroutine(FadeOutPresenceLoop());
	}

	private IEnumerator FadeOutPresenceLoop()
	{
		var fade = 1f;
		while (fade > 0f)
		{
			fade -= 2 * Time.deltaTime;
			presenceAudioSource.volume = initialPresenceVolume * fade;
			yield return null;
		}

		presenceAudioSource.Stop();
	}
}
