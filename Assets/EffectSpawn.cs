using UnityEngine;
using System.Collections;

public class EffectSpawn : MonoBehaviour {

	public float ImpactTime;
	public GameObject SpawnInEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		ImpactTime -= Time.deltaTime;

		if (ImpactTime <= 0) 
		{
			Instantiate (SpawnInEffect, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}
}
