using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float Health = 10;
	Animator anim;

	private bool Killed;
	public GameObject blood;
	private bool Used;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInParent <Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Health <= 0) 
		{
			Killed = true;
			gameObject.tag = ("Killed");
		}

		if (Killed == true && Used == false)
		{
			anim.SetTrigger ("Killed");
			Used = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == ("Bullet"))
		{
			Debug.Log ("HIT");
			Destroy (other.gameObject);
			Health -= 3;
			Instantiate (blood, gameObject.transform.position, blood.transform.rotation);
		}
	}
}
