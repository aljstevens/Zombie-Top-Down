using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public GameObject Target;
	public bool AttackAnim;
	public bool Walk;
	public GameObject OtherZombie;
	public GameObject ZombieTemp;
	public GameObject Rally;

	private EnemyHealth enemyhealth;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		agent = GetComponent <NavMeshAgent> ();
		enemyhealth = GetComponentInChildren <EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (enemyhealth.Health <= 0) 
		{
			agent.enabled = false;
		}

		if (enemyhealth.Health >= 0)
		{
			if (Target != null) 
			{
				transform.LookAt (Target.transform);
			}

			if (Target != null && Target.tag == ("Killed")) 
			{
				Target = null;
				agent.enabled = true;
			}

			if (Target != null && agent.enabled == true) 
			{
				agent.SetDestination (Target.transform.position);
			}

			if (Target == null && agent.enabled == true && OtherZombie != null) 
			{
				agent.SetDestination (OtherZombie.transform.position);
			}

			if (AttackAnim == true) 
			{
				anim.SetTrigger ("Attack");
				AttackAnim = false;
			}


			if (Walk == true) 
			{
				anim.SetTrigger ("Walk");
				Walk = false;
			}	

			if (enemyhealth.Health <= 0) 
			{
				agent.enabled = false;
			}
		}
	}

	void FixedUpdate ()
	{
		if (Target != null)
		{
			agent.speed += .1f * Time.deltaTime;
		}

		if (agent.speed >= 6)
		{
			agent.speed = 6;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (enemyhealth.Health >= 0)
		{
			if (Target == null && other.gameObject.tag == ("Player") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false))
		{
			Target = other.gameObject;
			Walk = true;
			Rally.SetActive (true);
		}
			if (OtherZombie == null && other.gameObject.tag == ("Rally"))
			{
				ZombieTemp = other.gameObject;
				OtherZombie = ZombieTemp.transform.parent.gameObject;

			}
		}

		if (enemyhealth.Health >= 0)
		{
			if (Target == null && other.gameObject.tag == ("Soldier") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false))
			{
				Target = other.gameObject;
				Walk = true;
				Rally.SetActive (true);
			}
			if (OtherZombie == null && other.gameObject.tag == ("Rally"))
			{
				ZombieTemp = other.gameObject;
				OtherZombie = ZombieTemp.transform.parent.gameObject;

			}
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (enemyhealth.Health >= 0)
		{
			if (Target == null && other.gameObject.tag == ("Player") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false))
			{
				Target = other.gameObject;
				Walk = true;
			}

		}

		if (enemyhealth.Health >= 0)
		{
			if (Target == null && other.gameObject.tag == ("Soldier") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false))
			{
				Target = other.gameObject;
				Walk = true;
			}

		}
	}
		

}
