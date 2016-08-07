using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float SpawnTimer;
	public GameObject SpawningZombie;
	public GameObject Waypoint;
	public bool Limit;
	public GameObject Zombie1;
	public GameObject Zombie2;
	public GameObject Zombie3;

	private float SpawnTimerCurrent;
	private GameObject OrderingUnit;
	private ZombieAI zombieail;
	private bool Placed;

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
			OrderingUnit.transform.parent = gameObject.transform;

			if (Limit == true)
			{
				if (Zombie1 == null)
				{
					Zombie1 = OrderingUnit;
				}

				if (Zombie2 == null && Zombie1 != OrderingUnit)
				{
					Zombie2 = OrderingUnit;
				}

//				if (Zombie3 == null  && Zombie1 != OrderingUnit && Zombie2 != OrderingUnit)
//				{
//					Zombie3 = OrderingUnit;
//				}

				if (Zombie1 != null && Zombie2 != null && Zombie2 !=OrderingUnit) 
				{
					Destroy (OrderingUnit);
				}
			}
		}
	}
		
}
