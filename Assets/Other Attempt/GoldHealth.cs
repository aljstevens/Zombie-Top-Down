﻿using UnityEngine;
using System.Collections;

public class GoldHealth : MonoBehaviour {

	public float Health = 100f; 
	public bool IsAlive =true;

	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("RedMachineGun")) 
		{
			Health -= 2;
			Destroy (other.gameObject);
		}
	}

	void Update ()
	{
		if (Health <= 0)
		{
			IsAlive = false;
			gameObject.tag = "Killed";
		}
	}
}
