using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public GameObject AttackTarget;
	public bool InCombat;
	public float AttackTime;
//	public GameObject AttackRange;
	public GameObject Target;

	private bool WalkedUsed;
	public PlayerHealth playerhealth;
	private SoldierHealth soldierhealth;
	private CiviHealth civihealth;

	public EnemyHealth enemyhealth;
	private ZombieAI zombieai;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponentInParent<Animator>();
		agent = GetComponentInParent <NavMeshAgent> ();
		zombieai = GetComponentInParent <ZombieAI> ();
		//enemyhealth = GetComponentInChildren <EnemyHealth> ();
	}
		
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (enemyhealth.Health >= 0) {
//			if (AttackTime <= 0)
//			{
//				AttackRange.SetActive (false);
//				Debug.Log ("OFF");
//			}

			if (Target != null && Target.tag == ("Killed")) 
			{
				InCombat = false;
				Target = null;

				if (civihealth != null) 
				{
					civihealth = null;
				}

				if (zombieai.WayPoint != null && WalkedUsed == false) 
				{
					zombieai.Walk = true;
					WalkedUsed = true;
				}
			}

//			if (InCombat == true && Target == null) 
//			{
//				InCombat = false;
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
					playerhealth.PlayerHP -= 4;
					Debug.Log ("GOT YOU Player");
				}

				if (Target != null && Target.tag == ("Soldier") && soldierhealth != null )
				{
					soldierhealth.SoldierHP -= 4;
					Debug.Log ("GOT YOU");
				}

				if (Target != null && Target.tag == ("Soldier") && civihealth != null)
				{
					civihealth.SoldierHP -= 4;
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
				WalkedUsed = false;
				agent.enabled = false;
				Target = other.gameObject;
				soldierhealth = Target.GetComponent<SoldierHealth> ();
				if (soldierhealth == null) 
				{
					civihealth = Target.GetComponent<CiviHealth> ();
				}
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
