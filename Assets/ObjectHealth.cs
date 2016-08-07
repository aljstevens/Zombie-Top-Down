using UnityEngine;
using System.Collections;

public class ObjectHealth : MonoBehaviour {

	public float Health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Health <= 0) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
			if (other.gameObject.tag == ("Bullet")) 
			{
				Destroy (other.gameObject);
				Health -= 1;
			}
	}
	
}
