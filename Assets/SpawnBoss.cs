using UnityEngine;
using System.Collections;

public class SpawnBoss : MonoBehaviour {

	public GameObject Boss;
	public float Timer=4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Timer -= Time.deltaTime;

		if (Timer <= 0 && Boss.activeInHierarchy == false)
		{
			Boss.SetActive (true);
		}
	}
}
