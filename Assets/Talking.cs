using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Talking : MonoBehaviour {

	public float Timer;
	public float SecondTimer;
	public Text Message1;
	public Text Message2;

	// Use this for initialization
	void Start ()
	{
		if (Message2 != null) 
		{
			Message2.enabled = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Message2 != null && Message2.enabled == true) 
		{
			SecondTimer -= Time.deltaTime;
		}

		if (Message1.enabled == true) 
		{
			Timer -= Time.deltaTime;
		}

		if (Timer <= 0) 
		{
			Message1.enabled = false;

			if (Message2 == null) 
			{
				Destroy (gameObject);
			}

			if (Message2 != null)
			{
				Message2.enabled = true;
			}
		}

		if (SecondTimer <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
