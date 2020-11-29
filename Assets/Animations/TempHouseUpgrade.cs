using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHouseUpgrade : MonoBehaviour
{
	private float initialPosition;
	private float velocity;

	public void Awake()
	{
		initialPosition = transform.position.y;
	}

	public void Update()
	{
		// Kill velocity if it's small
		if (Mathf.Abs(velocity) <= 0.001) velocity = 0f;

		// Gravity
		velocity += Physics2D.gravity.y * Time.deltaTime;

		// Movement
		transform.position += Vector3.up * velocity * Time.deltaTime;

		// Bounce
		if (transform.position.y <= initialPosition)
		{
			velocity *= -0.5f;
			transform.position = new Vector3(transform.position.x, initialPosition, transform.position.z);
		}
	}

	public void Upgrade()
	{
		velocity = 3f;
	}
}
