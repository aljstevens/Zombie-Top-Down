using UnityEngine;
using System.Collections;

public class Distance1 : MonoBehaviour {

	public bool TooClose;
	public GameObject TooCloseTarget;
	private PickingTarget2 picktarget;
	public WayTooClose1 waytooclose;

	// Use this for initialization
	void Start () 
	{
		picktarget = GetComponentInParent <PickingTarget2>();
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
