using UnityEngine;
using System.Collections;

public class Area1Clear : MonoBehaviour {

	public float EnemyCount;
	public float VictoryPoints;
	public GameObject Spawners;
	public GameObject APC;
	public GameObject WayPoint;
	public GameObject FrontLinesSoldiers;

	private NavMeshAgent agent;
	private SoldierAI soldierai;
	public bool Completed;
	private bool Used;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (APC == null)
		{
			Destroy (Spawners);
		}

		if (VictoryPoints >= 150 && APC !=null && Used == false) 
		{
			Destroy (Spawners);
			Completed = true;
			agent=APC.GetComponent <NavMeshAgent> ();
			agent.enabled = true;
			soldierai=APC.GetComponent <SoldierAI> ();
			soldierai.WayPoint = WayPoint;
			FrontLinesSoldiers.SetActive (true);
			Used = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Count")
		{
			EnemyCount += 1;
			Destroy (other.gameObject);
		}
	}
}
