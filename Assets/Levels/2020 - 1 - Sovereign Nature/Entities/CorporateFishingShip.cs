using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorporateFishingShip : Poppable
{
	// Editor fields
	[SerializeField] private float sinSpeed = 0f;
	[SerializeField] private float flaotAmopunt = 0.1f;
	[SerializeField] private float tiltAmopunt = 0.1f;
	[SerializeField] private ParticleSystem incomeParticlesParticles = null;

	private float sinValue = 0f;

	private void Awake()
	{
		sinValue = Random.Range(0f, 1f);
	}

	private void Update()
	{
		sinValue += sinSpeed * Time.deltaTime;
		spriteTransform.localPosition = Vector3.up * Mathf.Sin(sinValue) * flaotAmopunt;
		spriteTransform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(sinValue + Mathf.PI / 2) * tiltAmopunt);
	}

	public override void PopIn()
	{
		base.PopIn();
		incomeParticlesParticles.Play();
	}

	public override void PopOut()
	{
		base.PopOut();
		incomeParticlesParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
