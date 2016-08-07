using UnityEngine;
using System.Collections;

public class KaBoom : MonoBehaviour {

	public GameObject Plauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("PlaugeHit")) 
			{
			Instantiate (Plauge, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			}
	}
}