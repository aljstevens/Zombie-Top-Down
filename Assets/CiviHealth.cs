using UnityEngine;
using System.Collections;

public class CiviHealth : MonoBehaviour {

	public float SoldierHP=100f;
	public bool Fallen;
	public bool Killed;

	Animator anim;
	NavMeshAgent agent;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponentInParent <Animator> ();
		agent = GetComponentInParent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SoldierHP <= 0 && Fallen == false)
		{
			Debug.Log ("Down");
			agent.enabled = false;
			Killed = true;
			Fallen = true;
			gameObject.tag = ("Killed");
		}

		if (Killed == true) 
		{
			anim.SetTrigger ("Killed");
			Killed = false;
		}
	}


}