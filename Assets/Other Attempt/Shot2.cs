using UnityEngine;
using System.Collections;

public class Shot2 : MonoBehaviour {

	public float speed;
	public GameObject Tip;
	public float Life =3f;
	public Renderer rend;
	public GameObject BulletHole;
	public GameObject ShotFired;

	private float AppearTime=0.2f;

	void Awake ()
	{
		
	}
	
	void FixedUpdate ()
	{
		
		transform.LookAt (Tip.transform);
		Life -= Time.deltaTime;
		AppearTime -= Time.deltaTime;


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
