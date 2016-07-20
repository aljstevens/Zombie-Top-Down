using UnityEngine;
using System.Collections;

public class BulletImpact: MonoBehaviour {
	
	public GameObject Bullet;
	private GameObject Player;
	private Transform target;
	private float Life =3f;
	private bool Used;

	public GameObject HitObject;
	private GameObject SpawnBullet;
	private Renderer rend;
	
	// Use this for initialization
	void Awake () 
	{
		GameObject projectile;
		Player = GameObject.FindGameObjectWithTag("GunBarrel");
		target = gameObject.transform;
		projectile = Instantiate(Bullet, Player.transform.position, Player.transform.rotation)as GameObject;
		SpawnBullet = projectile;
		rend = SpawnBullet.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		if (SpawnBullet == null)
		{
			Destroy (gameObject);
		}
		if (SpawnBullet != null) 
		{
			float step = 20 * Time.deltaTime;
			SpawnBullet.transform.position = Vector3.MoveTowards (SpawnBullet.transform.position, target.position, step);
		}
//
//		if (Hit == true) 
//		{
//			Life -= Time.deltaTime;
//			
//			if (Life <= 0) 
//			{
//				Destroy (SpawnBullet);
//				Destroy (gameObject);
//			}
//		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == SpawnBullet && Used == false)
		{
			//Instantiate (HitObject, gameObject.transform.position, gameObject.transform.rotation);
			Instantiate (HitObject, gameObject.transform.position, HitObject.transform.rotation);
			Used = true;
		}
	}
}
