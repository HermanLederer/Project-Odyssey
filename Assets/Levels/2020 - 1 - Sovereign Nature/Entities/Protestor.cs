using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protestor : Poppable
{
	public float mass = 2f;
	public float jumpVelocity = 2f;

	private float velocity = 0f;
	private float timeTillJump = 0f;

	private bool isVisible;

	public ParticleSystem protestParticles;

	private void Start()
	{
		spriteTransform.gameObject.SetActive(false);
		isVisible = false;
	}

	private void Update()
	{
		// Gravity
		velocity += Physics2D.gravity.y * mass * Time.deltaTime;

		// Movement
		spriteTransform.localPosition += Vector3.up * velocity * Time.deltaTime;

		if (spriteTransform.localPosition.y <= 0f)
		{
			spriteTransform.localPosition = new Vector3(spriteTransform.localPosition.x, 0f, spriteTransform.localPosition.z);
			velocity = 0f;
		}

		if (isVisible && timeTillJump <= Time.time)
		{
			protestParticles.Play();
			Jump();
			timeTillJump = Time.time + Random.Range(3f, 7f);
		}
	}

	public void Jump()
	{
		velocity = jumpVelocity;
	}

	public override void PopIn()
	{
		base.PopIn();
		timeTillJump = Time.time + Random.Range(2f, 4f);
		isVisible = true;
	}

	public override void PopOut()
	{
		base.PopOut();
		protestParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		isVisible = false;
	}
}
