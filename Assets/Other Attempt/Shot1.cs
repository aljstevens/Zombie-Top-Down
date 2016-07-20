using UnityEngine;
using System.Collections;

public class Shot1 : MonoBehaviour {

	public float speed;
	public GameObject Tip;
	public float Life =3f;
//	public Renderer rend;

//	private float AppearTime=0.2f;

	void Awake ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
//		rend = GetComponent<Renderer>();
		transform.LookAt (Tip.transform);
	}
	
	void FixedUpdate ()
	{
		
		transform.LookAt (Tip.transform);
		Life -= Time.deltaTime;
//		AppearTime -= Time.deltaTime;

//		if (AppearTime <= 0) 
//		{
//			rend.enabled = true;
//		}

		if (Life <= 0)
		{
			Destroy(gameObject);
		}
	}
}
