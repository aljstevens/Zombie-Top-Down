using UnityEngine;
using System.Collections;

public class NeedHelp : MonoBehaviour {

	public GameObject HelpMessage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player") && HelpMessage !=null) 
		{
			HelpMessage.SetActive (true);

		}

	}
}
