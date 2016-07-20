using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

	public bool TooClose;
	public GameObject TooCloseTarget;
	private PickingTarget picktarget;
	public WayTooClose waytooclose;

	// Use this for initialization
	void Start () 
	{
		picktarget = GetComponentInParent <PickingTarget>();
		//waytooclose = GetComponentInChildren <WayTooClose>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == picktarget.FocusedTarget && waytooclose.Prioritybool == false)
		{
			TooClose = true;
			TooCloseTarget = picktarget.FocusedTarget;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == TooCloseTarget && waytooclose.Prioritybool == false)
		{
			TooClose = false;
			TooCloseTarget = null;
		}
	}
}
