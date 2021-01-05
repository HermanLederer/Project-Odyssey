using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy : MonoBehaviour
{
	// Editor fields
	[SerializeField] private float sinSpeed = 0f;
	[SerializeField] private float flaotAmopunt = 0.1f;
	[SerializeField] private ParticleSystem appearParticles = null;
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
	}

	public void PopIn()
	{
		spriteTransform.GetComponent<SpriteRenderer>().enabled = true;
		appearParticles.Play();
	}

	public void PopOut()
	{
		spriteTransform.GetComponent<SpriteRenderer>().enabled = false;
		appearParticles.Play();
	}
}
