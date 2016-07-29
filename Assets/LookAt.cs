using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public GameObject LookAhead;
	public GameObject LookPoint2;
	public GameObject APC;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	if (LookAhead) 
		{
		APC.transform.LookAt (new Vector3 (LookAhead.transform.position.x, transform.position.y, LookAhead.transform.position.z));
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("LookPoint1")) 
		{
			LookAhead = LookPoint2;
		}

	}
}
