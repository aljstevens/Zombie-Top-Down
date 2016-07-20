using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed;
	public GameObject Tip;
	public float Life =3f;
	public Renderer rend;
	public GameObject BulletHole;
	public GameObject ShotFired;
	private GameObject Player;

	private float AppearTime=0.2f;

	void Awake ()
	{
//		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Player = GameObject.FindGameObjectWithTag("GunBarrel");
		rend = GetComponent<Renderer>();
		transform.LookAt (Tip.transform);
	}
	
	void FixedUpdate ()
	{
		
		transform.LookAt (Tip.transform);
		Life -= Time.deltaTime;
		AppearTime -= Time.deltaTime;

		if (AppearTime <= 0) 
		{
			rend.enabled = true;
		}

		if (Life <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("WorldObject")) 
		{
			Debug.Log ("HIT THAT BOX");
			Instantiate (ShotFired, gameObject.transform.position, ShotFired.transform.rotation);
			Destroy (gameObject);
		}

		if (other.gameObject.tag == ("Zombie")) 
		{
			Instantiate (ShotFired, gameObject.transform.position, ShotFired.transform.rotation);
			Destroy (gameObject);
		}

	}
}
