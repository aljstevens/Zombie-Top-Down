using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public GameObject prefab;
	public GameObject Bullet;
	public GameObject Player;
	private GameObject PlayerBarrel;
	public GameObject ShotFired;

	private GameObject ShotBullet;

	void Awake ()
	{
		PlayerBarrel = GameObject.FindGameObjectWithTag("GunBarrel");
	}

	void Update () 
	{

		
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(ray,out hit))
		{

				if(Input.GetButtonDown ("Fire1"))
			{
				GameObject obj=Instantiate(prefab,new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity) as GameObject;
				Instantiate (ShotFired, PlayerBarrel.transform.position, PlayerBarrel.transform.rotation);
			}
		}
	}
	
}
