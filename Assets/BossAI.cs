using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	public bool ThrowPlauge;
	public bool Charging;
	public float AmountOfPlauge;
	public float CoolDown =2f;

	public GameObject Plauge;
	public GameObject Target;
	public GameObject Player;
	public GameObject ChargeTarget;
	public  GameObject ChargeZone;

	public  GameObject Throwing;
	public  GameObject LandingZone;
	public GameObject ChargeObject;
	public GameObject ThrowArea;
	public GameObject FinalBoom;

	private bool PlaugeThrowing;
	private bool SpellInUse;
	private bool Moving;
	public bool RestartBool;
	public float RestartTime =5f;

	public EnemyHealth enemyhealth;
	public GameObject DamageBeams;
	public GameObject SafeBeams;
	public GameObject ZombieSpawn1;
	public GameObject ZombieSpawn2;
	public GameObject Bomb;
	public GameObject FinalPhase;

	public bool Phase1 = true;
	public bool Phase2;
	public bool Phase3;
	public bool PlaugeBoom;
	public float TimeToBoom=8;

	private bool Used;
	private bool Used2;
	private bool Spawn;
	private float AttackTime=5f;


	// Use this for initialization
	void Awake ()
	{
		anim = GetComponentInParent <Animator>();
		agent = GetComponentInParent <NavMeshAgent> ();
		anim.SetTrigger ("Spawn");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Spawn == false)
		{
			AttackTime -= Time.deltaTime;
		}

		if (Spawn == false && AttackTime <= 0)
		{
			Charging = true;
			Spawn = true;
		}

		if (enemyhealth.Health == 2)
		{
			Phase1 = false;
			Phase2 = true;
		}

		if (enemyhealth.Health == 1)
		{
			Phase2 = false;
			Phase3 = true;
		}

		if (Phase1 == true) {
			if (ChargeZone == null) 
			{
				gameObject.transform.parent.LookAt (new Vector3 (Player.transform.position.x, gameObject.transform.parent.position.y, Player.transform.position.z));
			}

			if (ChargeZone != null) {
				gameObject.transform.parent.LookAt (new Vector3 (ChargeZone.transform.position.x, gameObject.transform.parent.position.y, ChargeZone.transform.position.z));
			}
		

			if (LandingZone != null && Throwing != null) {
				Throwing.transform.position = Vector3.MoveTowards (Throwing.transform.position, LandingZone.transform.position, 15 * Time.deltaTime);
			}

			if (ThrowPlauge == true)
			{
				CoolDown -= Time.deltaTime;
			}

			if (AmountOfPlauge <= 0) {
				RestartBool = true;
			}

			if (RestartTime <= 0 && ChargeZone == null) {
				Debug.Log ("YAY");
				Charging = true;
				RestartBool = false;
				RestartTime = 5f;
			}

			if (RestartBool == true && ChargeZone == null) {
				RestartTime -= Time.deltaTime;
			}

			if (CoolDown <= 0 && ThrowPlauge == true && AmountOfPlauge >= 1 && Throwing == null)
			{
				LandingZone = Instantiate (Target, Player.transform.position, Player.transform.rotation) as GameObject;
				Throwing = Instantiate (Plauge, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				CoolDown = 2;
				AmountOfPlauge -= 1;
				PlaugeThrowing = true;
				SpellInUse = false;
			}

			if (PlaugeThrowing == true && SpellInUse == false) {
				anim.SetTrigger ("ThrowPlauge");
				SpellInUse = true;
			}

			if (Charging == true && ChargeZone == null) {
				ChargeZone = Instantiate (ChargeTarget, Player.transform.position, Player.transform.rotation) as GameObject;
				anim.SetTrigger ("Move");
				ChargeObject.SetActive (true);
			}

			if (ChargeZone != null) {
				agent.enabled = true;
				agent.SetDestination (ChargeZone.transform.position);
				Charging = false;
			}
		}

		if (Phase2 == true) 
		{
			if (ThrowArea != null && Used == false) 
			{
				if (ZombieSpawn1 != null)
				{
					ZombieSpawn1.SetActive (true);
				}

				if (ZombieSpawn2 != null)
				{
					ZombieSpawn2.SetActive (true);
				}
				SafeBeams.SetActive (false);
				DamageBeams.SetActive (true);
				Used = true;
				anim.SetTrigger ("Move");
				agent.enabled = true;
				agent.SetDestination (ThrowArea.transform.position);
				gameObject.transform.parent.LookAt (new Vector3 (ThrowArea.transform.position.x, gameObject.transform.parent.position.y, ThrowArea.transform.position.z));
			}

			if (ThrowArea == null) 
			{
				gameObject.transform.parent.LookAt (new Vector3 (Player.transform.position.x, gameObject.transform.parent.position.y, Player.transform.position.z));

				if (CoolDown <= 0 && ThrowPlauge == true && AmountOfPlauge >= 1 && Throwing == null)
				{
					LandingZone = Instantiate (Target, Player.transform.position, Player.transform.rotation) as GameObject;
					Throwing = Instantiate (Plauge, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
					CoolDown = 3;
					PlaugeThrowing = true;
					SpellInUse = false;
				}

				if (PlaugeThrowing == true && SpellInUse == false) 
				{
					anim.SetTrigger ("ThrowPlauge");
					SpellInUse = true;
				}

				if (ThrowPlauge == true)
				{
					CoolDown -= Time.deltaTime;
				}

				if (LandingZone != null && Throwing != null)
				{
					Throwing.transform.position = Vector3.MoveTowards (Throwing.transform.position, LandingZone.transform.position, 15 * Time.deltaTime);
				}
			}
		}

		if (Phase3 == true) 
		{

			if (Phase3 == true && Used2 == false)
			{
				Bomb.SetActive (true);
				Used2 = true;
				agent.enabled = true;
				agent.SetDestination (FinalPhase.transform.position);
				gameObject.transform.parent.LookAt (new Vector3 (FinalPhase.transform.position.x, gameObject.transform.parent.position.y, FinalPhase.transform.position.z));
			}

			if (PlaugeBoom == true)
			{
				gameObject.transform.parent.LookAt (new Vector3 (Player.transform.position.x, gameObject.transform.parent.position.y, Player.transform.position.z));
				TimeToBoom -= Time.deltaTime;

				if (TimeToBoom <= 0) 
				{
					Instantiate (FinalBoom, gameObject.transform.position, gameObject.transform.rotation);
					TimeToBoom = 8f;
				}
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("ChargePoint") && Phase1 == true) 
		{
			agent.enabled = false;
			Destroy (other.gameObject);
			ChargeZone = null;
			anim.SetTrigger ("Idle");
			ChargeObject.SetActive (false);
			ThrowPlauge = true;
			AmountOfPlauge = 3f;
			RestartBool = false;
		}

		if (other.gameObject.tag == ("ThrowArea") && Phase2 == true)
		{
			agent.enabled = false;
			Destroy (ThrowArea);
			ThrowArea = null;
			AmountOfPlauge = 10f;
			ThrowPlauge = true;
			CoolDown = 2f;
		}

		if (other.gameObject.tag == ("FinalPhase") && Phase3 == true)
		{
			PlaugeBoom = true;
			agent.enabled = false;
			Destroy (FinalPhase);
			FinalPhase = null;
		}

	}
}
