using UnityEngine;
using System.Collections;

public class WayTooClose1: MonoBehaviour {
	
	public GameObject PriorityTarget;
	public bool Prioritybool =false;
	private PickingTarget2 picktarget;

	// Use this for initialization
	void Start () 
	{
		picktarget = GetComponentInParent <PickingTarget2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("RedTeam") && PriorityTarget ==null)
		{
			PriorityTarget = other.gameObject;
			Prioritybool = true;
			picktarget.FocusedTarget = other.gameObject;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == PriorityTarget)
		{
			picktarget.FocusedTarget = null;
			Prioritybool = false;
			PriorityTarget = null;
		}
	}
}
