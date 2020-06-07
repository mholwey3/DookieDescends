using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PoopMeter : MonoBehaviour
{
	[SerializeField]
	private Image image_Meter;

	[SerializeField]
    private Color defaultColor;

	[SerializeField]
	private Bird bird;

	[SerializeField]
	private float fMeterRefillRate;

	void Start () 
	{
		image_Meter = GetComponent<Image>();
        image_Meter.color = defaultColor;
	}
	
	void Update () 
	{
		if ( image_Meter.fillAmount >= 1 && !bird.pMeterFull)
		{
			image_Meter.fillAmount = 1;
			image_Meter.color = Color.red;
			bird.pMeterFull = true;
		}
		else
		{
			image_Meter.fillAmount += fMeterRefillRate;
		}
	}

	public void ResetBar()
	{
		image_Meter.fillAmount = 0;
		image_Meter.color = defaultColor;
	}
}
