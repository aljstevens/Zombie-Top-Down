using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flash : MonoBehaviour {

	public Color FlashingColour;
	public Color NormalColour;

	private float FlashTime=1;
	Renderer rend;
	private bool IsFlashing;

	// Use this for initialization
	void Awake ()
	{
		rend = GetComponent<Renderer>();
		rend.material.color = FlashingColour;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		FlashTime -= Time.deltaTime;
		
		if (FlashTime <= 0 && IsFlashing == true) 
		{
			rend.material.color = FlashingColour;
			FlashTime = 1f;
			IsFlashing = false;
		}

		if (FlashTime <= 0 && IsFlashing == false) 
		{
			rend.material.color = NormalColour;
			FlashTime = 1f;
			IsFlashing = true;
		}
	}
}
