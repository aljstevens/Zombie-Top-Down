using UnityEngine;
using System.Collections;

public class SoldierHealth : MonoBehaviour {

	public float SoldierHP=100f;
	public bool Fallen;
	public bool StayFallen;
	public GameObject Zombie;

	private GameObject TransformedSoldier;
	public GameObject TransformedSoldierHolder;

	public float DecayTime =3f;

	NavMeshAgent agent;
	private SoldierAI soldierai;

	// Use this for initialization
	void Awake () 
	{
		soldierai = GetComponentInParent <SoldierAI> ();
		agent = GetComponentInParent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Fallen == true && StayFallen == false) 
		{
			DecayTime -= Time.deltaTime;
		}

		if (DecayTime <= 0) 
		{
			Destroy(transform.parent.gameObject); 
		}

		if (SoldierHP <= 0 && Fallen == false)
		{
			Debug.Log ("Down");
			GetComponentInParent<Animation>().Play("soldierDieBack");
			Fallen = true;
			gameObject.tag = ("Killed");
		}
	}

	void OnTriggerEnter (Collider other)
	{
//		if (other.gameObject.tag == ("AttackRange"))
//		{
//			SoldierHP -= 5f;
//		}

		if (other.gameObject == soldierai.WayPoint && SoldierHP >= 0)
			{
				GetComponentInParent<Animation>().Play("soldierIdle");
				soldierai.WayPoint = null;
				agent.enabled = false;
			}


			if (other.gameObject.tag == ("Plauge"))
			{
			TransformedSoldier = Instantiate (Zombie, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			TransformedSoldier.transform.parent = TransformedSoldierHolder.transform;
			Destroy(transform.parent.gameObject); 
			}
	}
}