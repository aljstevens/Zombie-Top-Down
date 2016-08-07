using UnityEngine;
using System.Collections;

public class ArmBomb : MonoBehaviour {

	public bool InRange;
	public GameObject BossHealth;
	public GameObject Boom;
	public float PowerUp;

	private GameObject GM;
	private bool Armed;
	private float BoomTime=3f;
	private EnemyHealth health;

	// Use this for initialization
	void Awake ()
	{
		GM = GameObject.FindWithTag ("GM");
		health = BossHealth.GetComponent <EnemyHealth> ();
	}
	
	void FixedUpdate ()
	{
		if (Input.GetKey(KeyCode.E) && InRange == true) 
		{
			PowerUp += Time.deltaTime;
			GM.SetActive (false);
		}

		if (Input.GetKeyUp(KeyCode.E) && InRange == true) 
		{
			GM.SetActive (true);
		}


		if (PowerUp >= 20)
		{
			GM.SetActive (true);
			Armed = true;
		}

		if (Armed == true)
		{
			BoomTime -= Time.deltaTime;
		}

		if (BoomTime <= 0)
		{
			Instantiate (Boom, gameObject.transform.position, gameObject.transform.rotation);
			health.Health = 0;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = false;
			GM.SetActive (true);
		}
	}
}
