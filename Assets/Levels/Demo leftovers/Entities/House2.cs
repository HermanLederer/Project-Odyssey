using UnityEngine;

namespace Odyssey
{
	public class House2 : MonoBehaviour
	{
		// Editor components
		[SerializeField] private ParticleSystem explodeParticles;

		public void Explode()
		{
			explodeParticles.Play();
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
