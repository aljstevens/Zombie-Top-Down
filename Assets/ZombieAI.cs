using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public GameObject Target;
	public GameObject WayPoint;
	public bool AttackAnim;
	public bool Walk;
	public GameObject OtherZombie;
	public GameObject ZombieTemp;
	public GameObject Rally;
	public bool Idle;
	public GameObject CurrentHolder;

	private GameObject CombatHolder;
	private bool PlayerTargeted;
	private bool WalkUsed;
	private EnemyHealth enemyhealth;
	private bool NoParent;

	// Use this for initialization
	void Awake () 
	{
		CombatHolder = GameObject.FindWithTag ("CombatWithPlayer");
		anim = GetComponent<Animator>();
		agent = GetComponent <NavMeshAgent> ();
		enemyhealth = GetComponentInChildren <EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (CurrentHolder == null && NoParent == false)
		{
			CurrentHolder = transform.parent.gameObject;
		}

		if (enemyhealth.Health <= 0) 
		{
			agent.enabled = false;
			Target = null;
		}

		if (enemyhealth.Health >= 0)
		{
			if (Target != null && Target.tag == ("Player") && PlayerTargeted == false) 
			{
				gameObject.transform.parent = CombatHolder.transform;
				PlayerTargeted = true;
			}

			if (Target == null && PlayerTargeted == true) 
			{
				gameObject.transform.parent = CurrentHolder.transform;
				PlayerTargeted = false;
			}

			if (OtherZombie != null && Target != null) 
			{
				OtherZombie = null;
			}

			if (Target == null && WayPoint !=null && agent.enabled == true) 
			{
				agent.SetDestination (WayPoint.transform.position);

				if (WalkUsed == false) 
				{
					Walk = true;
					WalkUsed = true;
				}	
			}

			if (WayPoint != null && agent.enabled == false && Target == null)
			{
				agent.enabled = true;
				WalkUsed = false;
			}


			if (Target != null) 
			{
				//transform.LookAt (Target.transform);
				transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
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

			if (Idle == true) 
			{
				anim.SetTrigger ("Idle");
				Idle = false;
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
			agent.speed += .5f * Time.deltaTime;
		}

		if (agent.speed >= 9)
		{
			agent.speed = 9;
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
			agent.enabled = true;
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
				agent.enabled = true;
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
				agent.enabled = true;
			}

		}

		if (enemyhealth.Health >= 0)
		{
			if (Target == null && other.gameObject.tag == ("Soldier") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false))
			{
				Target = other.gameObject;
				Walk = true;
				agent.enabled = true;
			}

		}
	}
		

}
