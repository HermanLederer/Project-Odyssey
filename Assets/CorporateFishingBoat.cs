using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorporateFishingBoat : MonoBehaviour
{
	// Editor fields
	[SerializeField] private float sinSpeed = 0f;
	[SerializeField] private float flaotAmopunt = 0.1f;
	[SerializeField] private float tiltAmopunt = 0.1f;
	[SerializeField] private ParticleSystem appearParticles = null;
	[SerializeField] private ParticleSystem incomeParticlesParticles = null;
	[SerializeField] private Transform spriteTransform = null;

	private float sinValue = 0f;

	private void Awake()
	{
		spriteTransform.GetComponent<SpriteRenderer>().enabled = false;

		sinValue = Random.Range(0f, 1f);
	}

	private void Update()
	{
		sinValue += sinSpeed * Time.deltaTime;
		spriteTransform.localPosition = Vector3.up * Mathf.Sin(sinValue) * flaotAmopunt;
		spriteTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(sinValue - Mathf.PI / 2) * tiltAmopunt);
	}

	public void SailIn()
	{
		spriteTransform.GetComponent<SpriteRenderer>().enabled = true;
		appearParticles.Play();
		incomeParticlesParticles.Play();
	}

	public void SailOut()
	{
		spriteTransform.GetComponent<SpriteRenderer>().enabled = false;
		appearParticles.Play();
		incomeParticlesParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
