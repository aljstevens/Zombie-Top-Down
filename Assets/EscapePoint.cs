using UnityEngine;
using System.Collections;

public class EscapePoint : MonoBehaviour {

	public GameObject BonusObjective;

	private Area1Clear areaclear;

	// Use this for initialization
	void Awake () 
	{
		areaclear = BonusObjective.GetComponent <Area1Clear> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Civi")) 
		{
			Destroy (other.gameObject);
			areaclear.VictoryPoints += 3;
		}

	}
			
}
