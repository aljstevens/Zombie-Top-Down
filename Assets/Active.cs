using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Active : MonoBehaviour {

	public float PowerUp;
	public GameObject GM;
	public GameObject Objective;
	public GameObject Turret;
	public GameObject SetupImage;
	public Slider Building;
	public GameObject BuildingTurret;

	private bool InRange;
	private Area1Clear area1clear;
	private bool Charging;

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
		if (Charging == true)
		{
			PowerUp += Time.deltaTime;
		}

	}

	void Update ()
	{
//		if (InRange == true) 
//		{
//			Building.value = PowerUp;
//		}

		if (Input.GetKey(KeyCode.E) && InRange == true) 
		{
//			PowerUp += Time.deltaTime;
			BuildingTurret.SetActive (true);
			Building.value = PowerUp;
			Charging = true;
			GM.SetActive (false);
		}

		if (Input.GetKeyUp(KeyCode.E) && InRange == true) 
		{
			BuildingTurret.SetActive (false);
			GM.SetActive (true);
			Charging = false;
			PowerUp = 0;
			Building.value = 0f;
		}


		if (PowerUp >= 8)
		{
			PowerUp = 0;
			InRange = false;
			Debug.Log ("Active");
			area1clear.VictoryPoints += 5;
			GM.SetActive (true);
			Instantiate (Turret, gameObject.transform.position, gameObject.transform.rotation);
			SetupImage.SetActive (false);
			Building.value = 0f;
			BuildingTurret.SetActive (false);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = true;
			SetupImage.SetActive (true);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRange = false;
			GM.SetActive (true);
			SetupImage.SetActive (false);
		}
	}
}
