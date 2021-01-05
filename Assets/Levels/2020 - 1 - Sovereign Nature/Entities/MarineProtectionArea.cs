using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineProtectionArea : MonoBehaviour
{
	public void Start()
	{
	}

	public void Open()
	{
		var delay = 0f;
		foreach (Transform child in transform)
		{
			var buoy = child.GetComponent<Buoy>();
			StartCoroutine(PopBuoyInDelayed(delay, buoy));
			delay += 0.1f;
		}
	}

	private IEnumerator PopBuoyInDelayed(float delay, Buoy buoy)
	{
		yield return new WaitForSeconds(delay);
		buoy.PopIn();
	}
}
