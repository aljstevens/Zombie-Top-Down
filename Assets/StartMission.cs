using UnityEngine;
using System.Collections;

public class StartMission : MonoBehaviour {

	public GameObject Spawner;
	public GameObject Message;
	public GameObject VictoryPoints;

	private bool Used;
	private float Timer =10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Used == true)
		{
			Timer -= Time.deltaTime;
		}

		if (Timer <= 0) 
		{
			Spawner.SetActive (true);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player") && Used == false) 
		{
			Message.SetActive (true);
			VictoryPoints.SetActive (true);
			Used = true;

		}

	}
}
