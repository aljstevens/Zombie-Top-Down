using UnityEngine;
using System.Collections;

public class SoldierHealth : MonoBehaviour {

	public float SoldierHP=100f;
	public bool Fallen;

	NavMeshAgent agent;
	private SoldierAI soldierai;

	// Use this for initialization
	void Awake () 
	{
		soldierai = GetComponentInParent <SoldierAI> ();
		agent = GetComponentInParent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
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
		if (other.gameObject.tag == ("AttackRange"))
		{
			SoldierHP -= 5f;
		}

		if (other.gameObject == soldierai.WayPoint && SoldierHP >= 0)
			{
				GetComponentInParent<Animation>().Play("soldierIdle");
				soldierai.WayPoint = null;
				agent.enabled = false;
			}
	}
}