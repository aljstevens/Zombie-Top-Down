using UnityEngine;
using System.Collections;

public class Active : MonoBehaviour {

	public float PowerUp;
	public GameObject GM;
	public GameObject Objective;
	public GameObject Turret;

	private bool InRange;
	private Area1Clear area1clear;

	// Use this for initialization
	void Awake () 
	{
		Objective = GameObject.FindWithTag ("Bonus1");
		GM = GameObject.FindWithTag ("GM");
		area1clear = Objective.GetComponent <Area1Clear> ();
	}
	
	// Update is called once per frame
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
			PowerUp = 0;
		}


		if (PowerUp >= 8)
		{
			PowerUp = 0;
			Debug.Log ("Active");
			area1clear.VictoryPoints += 5;
			GM.SetActive (true);
			Instantiate (Turret, gameObject.transform.position, gameObject.transform.rotation);
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
