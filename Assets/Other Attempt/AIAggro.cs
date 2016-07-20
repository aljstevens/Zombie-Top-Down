using UnityEngine;
using System.Collections;

public class AIAggro : MonoBehaviour {


	public GameObject Target;
	public GameObject Bullets;
	public float ShootNumber;

	public bool Test;
	public GameObject ShotBullet;
	private float ShootTime=0.5f;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () 
	{
		if (Target != null)
		{
			transform.parent.LookAt (Target.transform);
			ShootTime -=Time.deltaTime;
		}

		if (ShootTime <0 ) 
		{
			Instantiate(Bullets, gameObject.transform.position, gameObject.transform.rotation);
			ShootTime =0.5f;
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("GoldTeam"))
		{
			Target = other.gameObject;
		}
	}

}