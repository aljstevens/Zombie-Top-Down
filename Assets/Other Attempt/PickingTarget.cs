using UnityEngine;
using System.Collections;

public class PickingTarget : MonoBehaviour {

	public GameObject Target;
	public GameObject FocusedTarget;
	public GameObject Bullets;
	public float ShootNumber;
	public Transform Destination;
	public Transform TargetTransform;
	public GameObject GunBarrel;

	public float UnitType; //1 is attacker and 0 is defender
	NavMeshAgent agent;
	public GameObject ShotBullet;
	private float ShootTime=0.5f;
	private Distance distance;
	private RedHealth redhealth;
	private bool HasFallen;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		distance = GetComponentInChildren <Distance>();
		redhealth = GetComponentInChildren <RedHealth>();
	}


	
	GameObject FindClosestEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("GoldTeam");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

//	public void ResetPath();
//
//	{
//		NavMeshAgent.ResetPath;
//	}
	
	void Update ()
	{
		if (redhealth.IsAlive == true)
		{
			if (FocusedTarget != null && FocusedTarget.tag == "Killed")
			{
				FocusedTarget = null;
			}

			if (UnitType == 1 && FocusedTarget != null) {
				Debug.Log ("Yes2");
				agent.Stop (true);
				//GetComponent<Animation>().Play("soldierIdle");
			}

			if (UnitType == 1 && FocusedTarget == null) {
				Debug.Log ("Yes");
				agent.SetDestination (Destination.position);
				agent.Resume ();
				GetComponent<Animation> ().Play ("soldierRun");
			}

			if (FocusedTarget != null && distance.TooClose == false) {
				agent.ResetPath ();
				agent.SetDestination (TargetTransform.position);
				GetComponent<Animation> ().Play ("soldierRun");
			}

			if (FocusedTarget != null && distance.TooClose == true) {
				agent.Stop (true);
				GetComponent<Animation> ().Play ("soldierIdle");
			}

			Target = FindClosestEnemy ();
		
//		if (FocusedTarget == null) 
//		{
//			FocusedTarget = Target;
//		}

			if (FocusedTarget != null) {
				transform.LookAt (FocusedTarget.transform);
				ShootTime -= Time.deltaTime;
			}
		
			if (ShootTime < 0) {
				Instantiate (Bullets, GunBarrel.transform.position, GunBarrel.transform.rotation);
				ShootTime = 0.5f;
			}
		}

		if (redhealth.IsAlive == false && HasFallen == false)
		{
			GetComponent<Animation> ().Play ("soldierDieBack");
			HasFallen = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == Target && FocusedTarget == null)
		{
			FocusedTarget = Target;
			TargetTransform = FocusedTarget.transform;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == Target && FocusedTarget == null)
		{
			FocusedTarget = Target;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == FocusedTarget && FocusedTarget != null)
		{
			FocusedTarget = null;
		}
	}
}
