using UnityEngine;
using System.Collections;

public class CiviAI : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;

	public bool InRange;
	public bool IdleAnim;
	public bool RunAnim;
	public GameObject Health;

	private bool Used;
	private GameObject WayPoint;

	// Use this for initialization
	void Awake () 
	{
		WayPoint = GameObject.FindWithTag ("EscapePoint");
		anim = GetComponent <Animator> ();
		agent = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (agent.enabled == true && Used == true)
		{
			agent.SetDestination (WayPoint.transform.position);
		}

		if (Input.GetKey(KeyCode.E) && InRange == true && Used == false) 
		{
			RunAnim = true;
			Health.SetActive (true);
			Used = true;
		}

		if (IdleAnim == true) 
		{
			anim.SetTrigger ("Idle");
			IdleAnim = false;
		}

		if (RunAnim == true) 
		{
			anim.SetTrigger ("Run");
			RunAnim = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = true;
		}

	}
}
