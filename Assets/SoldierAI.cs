using UnityEngine;
using System.Collections;

public class SoldierAI : MonoBehaviour {

	public GameObject Target;
	public GameObject ShootingImpact;
	public GameObject Flash;
	public GameObject Barrel;
	public float Ammo;

	private Vector3 localOffset;
	private float ShootTime=1f;
	private SoldierHealth soldierhealth;

	// Use this for initialization
	void Awake () 
	{
		soldierhealth = GetComponentInChildren <SoldierHealth> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (soldierhealth.SoldierHP >= 0) {
			if (Target != null) {
				transform.LookAt (Target.transform);
				ShootTime -= Time.deltaTime;
			}

			if (Target != null && ShootTime <= 0) {
				localOffset = new Vector3 (Random.Range (-1, 1), 0, 0);
				Instantiate (Flash, Barrel.transform.position, Barrel.transform.rotation);
				Instantiate (ShootingImpact, Target.transform.position + localOffset, Target.transform.rotation);
				ShootTime = Random.Range (1, 3);
			}

			if (Target != null && Target.tag == ("Killed")) {
				Target = null;
				ShootTime = Random.Range (1, 3);
			}
			
		}
	}

//	if (enemyhealth.Health >= 0)
//	{
	void OnTriggerEnter (Collider other)
	{
		if (soldierhealth.SoldierHP >= 0) 
		{
			if (Target == null && other.gameObject.tag == ("Zombie") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false)) {
				Target = other.gameObject;
			}
		}

	}

	void OnTriggerStay (Collider other)
	{
		if (soldierhealth.SoldierHP >= 0) 
		{
			if (Target == null && other.gameObject.tag == ("Zombie") && (Physics.Linecast (transform.position, other.gameObject.transform.position) == false)) 
			{
				Target = other.gameObject;
			}
		}

	}
}
