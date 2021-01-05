using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy : Poppable
{
	// Editor fields
	[SerializeField] private float sinSpeed = 0f;
	[SerializeField] private float flaotAmopunt = 0.1f;

	private float sinValue = 0f;

	private void Awake()
	{
		spriteTransform.gameObject.SetActive(false);
		sinValue = Random.Range(0f, 1f);
	}

	private void Update()
	{
		sinValue += sinSpeed * Time.deltaTime;
		spriteTransform.localPosition = Vector3.up * Mathf.Sin(sinValue) * flaotAmopunt;
	}

}
