using UnityEngine;
using System.Collections;

public class APCOrders : MonoBehaviour {

	public GameObject APC;
	public GameObject Waypoint;

	private SoldierAI soldierai;

	// Use this for initialization
	void Awake () 
	{
		soldierai = APC.GetComponent<SoldierAI> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == APC)
		{
			soldierai.WayPoint = Waypoint;
			Destroy (gameObject);
		}
	}

}
