using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppableGroup : MonoBehaviour
{
	[SerializeField] private float speed = 0.1f;

	public void PopIn()
	{
		var delay = 0f;
		foreach (Transform child in transform)
		{
			var poppable = child.GetComponent<Poppable>();
			StartCoroutine(PopInDelayed(delay, poppable));
			delay += speed;
		}
	}

	public void PopOut()
	{
		var delay = 0f;
		foreach (Transform child in transform)
		{
			var poppable = child.GetComponent<Poppable>();
			StartCoroutine(PopOutDelayed(delay, poppable));
			delay += speed;
		}
	}

	private IEnumerator PopInDelayed(float delay, Poppable poppable)
	{
		yield return new WaitForSeconds(delay);
		poppable.PopIn();
	}

	private IEnumerator PopOutDelayed(float delay, Poppable poppable)
	{
		yield return new WaitForSeconds(delay);
		poppable.PopOut();
	}
}
