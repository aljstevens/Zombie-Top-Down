using UnityEngine;
using System.Collections;

public class DropWeapon : MonoBehaviour {

	public float Drop;
	public GameObject Medic;
	public GameObject Shotgun;
	public GameObject Machinegun;

	private bool Dropped;
	private float DecayTime=2f;

	// Use this for initialization
	void Awake () 
	{
		Drop = Random.Range (2, 6);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Drop == 3 && Dropped == false)
		{
			Instantiate (Medic, gameObject.transform.position, gameObject.transform.rotation);
			Dropped = true;
		}

		if (Drop == 4 && Dropped == false)
		{
			Instantiate (Shotgun, gameObject.transform.position, gameObject.transform.rotation);
			Dropped = true;
		}

		if (Drop == 5 && Dropped == false)
		{
			Instantiate (Machinegun, gameObject.transform.position, gameObject.transform.rotation);
			Dropped = true;
		}

		if (Drop == 6 && Dropped == false)
		{
			Instantiate (Medic, gameObject.transform.position, gameObject.transform.rotation);
			Dropped = true;
		}

	}

	void FixedUpdate ()
	{
		DecayTime -= Time.deltaTime;

		if (DecayTime <= 0)
		{
			Destroy (gameObject);
		}
	}
}
