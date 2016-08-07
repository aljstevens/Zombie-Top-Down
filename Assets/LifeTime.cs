using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

	public float Timer=12f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Timer -= Time.deltaTime;

		if (Timer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
