using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FactoryWorker : MonoBehaviour
{
	public float mass = 2f;
	public float jumpVelocity = 2f;

	private float velocity = 0f;
	private float timeTillJump = 0f;
	private bool isProtesting = false;
	private bool isVisible = false;

	private float groundPosY;

	new private SpriteRenderer renderer;

	public ParticleSystem appearParticles;
	public ParticleSystem protestParticles;

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

		if (isProtesting && timeTillJump <= Time.time)
		{
			protestParticles.Play();
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
		StopProtesting();
		isVisible = false;
		renderer.enabled = false;
		appearParticles.Play();
		//Jump(); 
	}

	public void StartProtesting()
	{
		if (!isVisible) Appear();

		isProtesting = true;
		timeTillJump = Time.time + 2f;

		//protestParticles.Play();
	}

	public void StopProtesting()
	{
		isProtesting = false;
		protestParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
