using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Background : MonoBehaviour
{
	// Editor components
	[SerializeField] private Sprite spriteNormal;
	[SerializeField] private Sprite spriteContaminated;
	[SerializeField] private Light2D sun;
	[SerializeField] private Color sunColorNormal;
	[SerializeField] private Color sunColorContaminated;

	private float airContamination = 0f;
	private float targetAirContamination = 0f;

	public void Start()
	{
		Naturalize();
	}

	public void Update()
	{
		sun.color = Color.Lerp(sunColorNormal, sunColorContaminated, airContamination);

		if (airContamination < targetAirContamination)
		{
			airContamination += 0.5f * Time.deltaTime;
			if (airContamination > targetAirContamination)
				airContamination = targetAirContamination;
		}
		else if (airContamination > targetAirContamination)
		{
			airContamination -= 1.5f * Time.deltaTime;
			if (airContamination < targetAirContamination)
				airContamination = targetAirContamination;
		}
	}

	public void Naturalize()
	{
		//GetComponent<SpriteRenderer>().sprite = spriteNormal;
		targetAirContamination = 0f;
	}

	public void Contaminate()
	{
		//GetComponent<SpriteRenderer>().sprite = spriteContaminated;
		targetAirContamination = 1f;
	}
}
