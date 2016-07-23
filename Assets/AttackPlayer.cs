using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public GameObject AttackTarget;
	public bool InCombat;
	public float AttackTime=1.5f;
//	public GameObject AttackRange;
	public GameObject Target;

	public PlayerHealth playerhealth;
	private SoldierHealth soldierhealth;


	public EnemyHealth enemyhealth;
	private ZombieAI zombieai;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInParent<Animator>();
		agent = GetComponentInParent <NavMeshAgent> ();
		zombieai = GetComponentInParent <ZombieAI> ();
		//enemyhealth = GetComponentInChildren <EnemyHealth> ();
	}
		
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyhealth.Health >= 0) {
//			if (AttackTime <= 0)
//			{
//				AttackRange.SetActive (false);
//				Debug.Log ("OFF");
//			}

			if (InCombat == true && Target != null) 
			{
				AttackTime += Time.deltaTime;
			}

			if (InCombat == true && AttackTime >= 1.5 && Target != null)
			{
				Debug.Log ("HitHIM");
				anim.SetTrigger ("Attack");
				AttackTime = 0f;

				if (Target != null && Target.tag == ("Player"))
				{
					playerhealth.PlayerHP -= 5;
				}

				if (Target != null && Target.tag == ("Soldier"))
				{
					soldierhealth.SoldierHP -= 5;
				}

			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (enemyhealth.Health >= 0)
		{
			if (other.gameObject.tag == ("Player") && other.gameObject == zombieai.Target)
			{
			InCombat = true;
			agent.enabled = false;
			Target = other.gameObject;
			playerhealth = Target.GetComponent<PlayerHealth> ();
			}
		}

		if (enemyhealth.Health >= 0)
		{
			if (other.gameObject.tag == ("Soldier") && other.gameObject == zombieai.Target)
			{
				InCombat = true;
				agent.enabled = false;
				Target = other.gameObject;
				soldierhealth = Target.GetComponent<SoldierHealth> ();
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player") && other.gameObject == zombieai.Target)
		{
			agent.enabled = true;
			Target = null;
			anim.SetTrigger ("Walk");
		}

		if (other.gameObject.tag == ("Soldier") && other.gameObject == zombieai.Target)
		{
			agent.enabled = true;
			Target = null;
			anim.SetTrigger ("Walk");
		}
	}

}
