using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : MonoBehaviour
{
	public float mass = 2f;
	public float jumpVelocity = 2f;

	private float velocity = 0f;
	private float timeTillJump = 0f;
	private bool isFishing = false;
	private bool isVisible = false;

	private float groundPosY;

	new private SpriteRenderer renderer;

	public ParticleSystem appearParticles;
	public ParticleSystem incomeParticles;

	private void Awake()
	{
		renderer = GetComponent<SpriteRenderer>();

		renderer.enabled = false;
	}

	private void Start()
	{
		groundPosY = transform.position.y;
	}

	private void Update()
	{
		// Gravity
		velocity += Physics2D.gravity.y * mass * Time.deltaTime;

		// Movement
		transform.position += Vector3.up * velocity * Time.deltaTime;

		if (transform.position.y <= groundPosY)
		{
			transform.position = new Vector3(transform.position.x, groundPosY, transform.position.z);
			velocity = 0f;
		}

		if (isFishing && timeTillJump <= Time.time)
		{
			Jump();
			timeTillJump = Time.time + Random.Range(3f, 7f);
		}
	}

	public void Jump()
	{
		if (velocity <= 0) groundPosY = transform.position.y;
		velocity = jumpVelocity;
	}

	public void Appear()
	{
		isVisible = true;
		renderer.enabled = true;
		appearParticles.Play();
		Jump();
	}

	public void Disappear()
	{
		StopFishing();
		isVisible = false;
		renderer.enabled = false;
		appearParticles.Play();
	}

	public void StartFishing()
	{
		if (!isVisible) Appear();

		isFishing = true;
		timeTillJump = Time.time + 2f;

		incomeParticles.Play();
	}

	public void StopFishing()
	{
		isFishing = false;
		incomeParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
