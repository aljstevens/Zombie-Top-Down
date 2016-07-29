using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float SpawnTimer;
	public GameObject SpawningZombie;
	public GameObject Waypoint;

	private float SpawnTimerCurrent;
	private GameObject OrderingUnit;
	private ZombieAI zombieail;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		SpawnTimerCurrent -= Time.deltaTime;

		if (SpawnTimerCurrent <= 0) 
		{
			OrderingUnit = Instantiate (SpawningZombie, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			zombieail = OrderingUnit.GetComponent <ZombieAI> ();
			zombieail.WayPoint = Waypoint;
			SpawnTimerCurrent = SpawnTimer;
		}
	}
		
}
