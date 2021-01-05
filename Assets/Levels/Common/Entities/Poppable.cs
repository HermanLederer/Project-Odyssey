using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poppable : MonoBehaviour
{
	[SerializeField] protected ParticleSystem appearParticles = null;
	[SerializeField] protected Transform spriteTransform = null;

	public virtual void PopIn()
	{
		spriteTransform.gameObject.SetActive(true);
		appearParticles.Play();
	}

	public virtual void PopOut()
	{
		spriteTransform.gameObject.SetActive(false);
		appearParticles.Play();
	}
}
