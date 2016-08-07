using UnityEngine;
using System.Collections;

public class OrderTroops : MonoBehaviour {

	private bool InRange;
	private bool Used;

	public GameObject WaitingTeam;
	public GameObject OrderedTeam;
	public GameObject OrderImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.E) && InRange == true && Used == false) 
		{
			WaitingTeam.SetActive (false);
			OrderedTeam.SetActive (true);
			Used = true;
			Destroy (OrderImage);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = true;
			OrderImage.SetActive (true);
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = false;
			OrderImage.SetActive (false);
		}

	}
}
