using UnityEngine;
using System.Collections;

public class StartRestart : MonoBehaviour {

	public bool InRange;
	private bool Used;

	public GameObject OfflineTurrets;
	public GameObject OnlineTurrets;
	public GameObject ZombieSpawn;
	public GameObject Spawner;
	public GameObject Spawner2;
	public GameObject Engineer;
	public float Timer =120f;
	public GameObject RestartComputer;
	public GameObject TimerImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKey (KeyCode.E) && InRange == true && Used == false) 
		{
			Used = true;
			Spawner.SetActive (true);
		}

		if (Used == true)
		{
			Timer -= Time.deltaTime;
		}

		if (Timer <= 70 && Spawner2.activeInHierarchy == false)
		{
			Spawner2.SetActive (true);
		}

		if (Timer <= 0)
		{
			Destroy (Spawner);
			Destroy (Spawner2);
			OfflineTurrets.SetActive (false);
			OnlineTurrets.SetActive (true);
			Destroy (ZombieSpawn);
			Destroy (gameObject);
		}

		if (Engineer == null)
		{
			Destroy (Spawner);
			Destroy (Spawner2);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = true;
			RestartComputer.SetActive (true);
			TimerImage.SetActive (true);
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = false;
			RestartComputer.SetActive (false);
			TimerImage.SetActive (false);
		}

	}
}
