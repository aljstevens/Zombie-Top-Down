using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public GameObject AttackTarget;
	public bool InCombat;
	public float AttackTime=1.5f;
	public GameObject AttackRange;


	public EnemyHealth enemyhealth;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInParent<Animator>();
		agent = GetComponentInParent <NavMeshAgent> ();
		//enemyhealth = GetComponentInChildren <EnemyHealth> ();
	}
		
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyhealth.Health >= 0) {
			if (AttackTime <= 0) {
				AttackRange.SetActive (false);
			}

			if (InCombat == true) {
				AttackTime += Time.deltaTime;
			}

			if (InCombat == true && AttackTime >= 1.5)
			{
				anim.SetTrigger ("Attack");
				AttackTime = 0f;
				AttackRange.SetActive (true);
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (enemyhealth.Health >= 0)
		{
			if (other.gameObject.tag == ("Player"))
			{
			InCombat = true;
			agent.enabled = false;
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player"))
		{
			agent.enabled = true;
		}
	}

}
