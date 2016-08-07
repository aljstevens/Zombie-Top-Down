using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float Health = 10;
	Animator anim;
	NavMeshAgent agent;
	public bool CountedZombies;
	public bool Boss;
	private GameObject CounterObject;

	private float DecayTime=2;
	private Area1Clear area1clear;
	private bool Killed;
	public GameObject blood;
	private bool Used;
	private bool CountedUsed;
	private ZombieAI zombieai;

	public GameObject Boom;
	BoxCollider boxcollider;

	// Use this for initialization
	void Awake () 
	{
		CounterObject = GameObject.FindWithTag ("Bonus1");
		anim = GetComponentInParent <Animator>();
		agent = GetComponentInParent <NavMeshAgent>();
		zombieai = GetComponentInParent <ZombieAI> ();
		boxcollider = GetComponent <BoxCollider> ();



		if (CountedZombies == true)
		{
			area1clear = CounterObject.GetComponent <Area1Clear>();
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Health <= 0) 
		{
			Killed = true;
			gameObject.tag = ("Killed");
			boxcollider.enabled = false;
		}

		if (Health <= 0 && CountedZombies == true && CountedUsed == false) 
		{
			area1clear.EnemyCount -= 1;
			area1clear.VictoryPoints += 1;
			CountedUsed = true;
		}

		if (Killed == true && Used == false)
		{
			anim.SetTrigger ("Killed");
			Used = true;
		}
	}

	void FixedUpdate ()
	{
		if (Health <= 0) 
		{
			DecayTime -= Time.deltaTime;
		}

		if (DecayTime <= 0) 
		{
			Destroy(transform.parent.gameObject); 
		}
	}

	void OnTriggerEnter (Collider other)
	{
		{
			if (other.gameObject.tag == ("Bullet") && Boss == false) 
			{
				Debug.Log ("HIT");
				Destroy (other.gameObject);
				Health -= 3;
				Instantiate (blood, gameObject.transform.position, blood.transform.rotation);
			}

			if (other.gameObject.tag == ("Barrel") && Boss == true) 
			{
				Instantiate (Boom, other.gameObject.transform.position, other.gameObject.transform.rotation);
				Debug.Log ("HIT");
				Destroy (other.gameObject);
				Health -= 1;
				anim.SetTrigger ("GetHit");
				Instantiate (blood, gameObject.transform.position, blood.transform.rotation);
			}

			if (other.gameObject.tag == ("Falling") && Boss == true) 
			{
				Instantiate (Boom, other.gameObject.transform.position, other.gameObject.transform.rotation);
				Debug.Log ("HIT");
				Destroy (other.gameObject);
				Health -= 1;
				anim.SetTrigger ("GetHit");
				Instantiate (blood, gameObject.transform.position, blood.transform.rotation);
			}

			if (Boss == false && other.gameObject == zombieai.WayPoint && Health >= 0) 
			{
				zombieai.Idle = true;
				zombieai.WayPoint = null;
				agent.enabled = false;
			}
		}
	}
}
