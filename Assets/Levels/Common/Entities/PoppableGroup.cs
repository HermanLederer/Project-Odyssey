using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PoppableGroup : MonoBehaviour
{
	private AudioSource audioSource;

	[SerializeField] private float speed = 0.1f;
	[SerializeField] private AudioClip presenceLoop = null;

	private float initialPresenceVolume = 0;

	public void Awake()
	{
		TryGetComponent<AudioSource>(out audioSource);
		if (audioSource) initialPresenceVolume = audioSource.volume;
	}

	public void PopIn()
	{
		if (audioSource)
		{ 
			audioSource.clip = presenceLoop;
			audioSource.volume = initialPresenceVolume;
			audioSource.Play();
		}

		var delay = 0f;
		foreach (Transform child in transform)
		{
			var poppable = child.GetComponent<Poppable>();
			StartCoroutine(PopInDelayed(delay, poppable));
			delay += speed;
		}
	}

	public void PopOut()
	{
		if (audioSource) StartCoroutine(FadeOutPresenceLoop());
		var delay = 0f;
		foreach (Transform child in transform)
		{
			var poppable = child.GetComponent<Poppable>();
			StartCoroutine(PopOutDelayed(delay, poppable));
			delay += speed;
		}
	}

	private IEnumerator PopInDelayed(float delay, Poppable poppable)
	{
		yield return new WaitForSeconds(delay);
		poppable.PopIn();
	}

	private IEnumerator PopOutDelayed(float delay, Poppable poppable)
	{
		yield return new WaitForSeconds(delay);
		poppable.PopOut();
	}

	private IEnumerator FadeOutPresenceLoop()
	{
		var fade = 1f;
		while (fade > 0f)
		{
			fade -= 2 * Time.deltaTime;
			audioSource.volume = initialPresenceVolume * fade;
			yield return null;
		}

		audioSource.Stop();
	}
}
