using UnityEngine;
using System.Collections;

public class SoldierAI : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject Target;
	public GameObject ShootingImpact;
	public GameObject Flash;
	public GameObject Barrel;
	public float Ammo;
	public GameObject WayPoint;
	public float AmmoAmount =8;
	public float ReloadAmountTime =2;
	public float ShootTimeMin =1;
	public float ShootTimeMax =3;
	public GameObject LookAhead;

	private float ReloadTime;
	private Vector3 localOffset;
	private float ShootTime=1f;
	private SoldierHealth soldierhealth;

	// Use this for initialization
	void Awake () 
	{
		soldierhealth = GetComponentInChildren <SoldierHealth> ();
		agent = GetComponent <NavMeshAgent> ();
		ReloadTime = ReloadAmountTime;
		Ammo = AmmoAmount;

		if (agent == null) 
		{
			agent = null;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (soldierhealth.Fallen == false)
		{
//			if (LookAhead != null && Target == null) 
//			{
//				transform.LookAt (new Vector3 (LookAhead.transform.position.x, transform.position.y, LookAhead.transform.position.z));
//			}

			if (Ammo <=0 && ReloadTime <= 0)
			{
				ReloadTime = ReloadAmountTime;
				Ammo = AmmoAmount;
			}

			if (Target != null && agent !=null && agent.enabled == true)
			{
				GetComponent<Animation>().Play("soldierIdle");
				agent.enabled = false;
			}

			if (WayPoint != null  && agent !=null &&  agent.enabled == false)
			{
				agent.enabled = true;
			}

			if (Target == null  && agent !=null &&  agent.enabled == false)
			{
				agent.enabled = true;
			}
				

			if (Target == null && agent !=null && agent.enabled == true && WayPoint !=null) 
			{
				GetComponent<Animation>().Play("soldierRun");
				agent.SetDestination (WayPoint.transform.position);
			}

			if (Target != null && ShootTime <= 0  && (Physics.Linecast (transform.position, Target.gameObject.transform.position) == false)) 
			{
				Ammo -= 1;
				localOffset = new Vector3 (Random.Range (-0.5f, 0.5f), 0, Random.Range (-0.5f, 0.5f));
				Instantiate (Flash, Barrel.transform.position, Barrel.transform.rotation);
				Instantiate (ShootingImpact, Target.transform.position + localOffset, Target.transform.rotation);
				ShootTime = Random.Range (ShootTimeMin, ShootTimeMax);
			}

			if (Target != null && Target.tag == ("Killed"))
			{
				Target = null;
				ShootTime = Random.Range (1, 3);
			}
			
		}
	}

	void FixedUpdate ()
	{
		if (soldierhealth.Fallen == false) 
		{

			if (Target != null && Ammo <= 0) 
			{
				ReloadTime -= Time.deltaTime;
			}

			if (Target != null && Ammo >= 1) 
			{
				transform.LookAt (new Vector3 (Target.transform.position.x, transform.position.y, Target.transform.position.z));
				ShootTime -= Time.deltaTime;
			}

		}
	}

//	if (enemyhealth.Health >= 0)
//	{
	void OnTriggerEnter (Collider other)
	{
		if (soldierhealth.Fallen == false) 
		{
			if (Target == null && other.gameObject.tag == ("Zombie") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false))
			{
				Target = other.gameObject;
			}
		}

//		if (soldierhealth.SoldierHP >= 0) 
//		{
//			if (other.gameObject == WayPoint)
//			{
//				GetComponent<Animation>().Play("soldierIdle");
//				WayPoint = null;
//				agent.enabled = false;
//			}
//		}

	}

	void OnTriggerStay (Collider other)
	{
		if (soldierhealth.Fallen == false) 
		{
			if (Target == null && other.gameObject.tag == ("Zombie") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false)) 
			{
				Target = other.gameObject;
			}
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (soldierhealth.Fallen == false) 
		{
			if (Target != null && other.gameObject.tag == ("Zombie")) 
			{
				Target = null;
			}
		}

	}
}
