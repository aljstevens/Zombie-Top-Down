using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	Rigidbody rigidBody;
	public GameObject GM;
	public float speed = 4;
	public bool WPress;
	public bool SPress;
	public bool APress;
	public bool DPress;

	public PlayerHealth playerhealth;

	Vector3 lookPos;

	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		playerhealth = GetComponentInChildren<PlayerHealth> ();
	}

	void Update ()
	{
		if (playerhealth.PlayerHP  >= 1)
		{

		if (Input.GetKeyUp (KeyCode.W))
		{
			WPress = false;
		}

		if (Input.GetKeyDown (KeyCode.W))
		{
			WPress = true;
		}

		if (Input.GetKeyUp (KeyCode.D))
		{
			DPress = false;
		}
		
		if (Input.GetKeyDown (KeyCode.D))
		{
			DPress = true;
		}

		if (Input.GetKeyUp (KeyCode.A))
		{
			APress = false;
		}
		
		if (Input.GetKeyDown (KeyCode.A))
		{
			APress = true;
		}

		if (Input.GetKeyUp (KeyCode.S))
		{
			SPress = false;
		}
		
		if (Input.GetKeyDown (KeyCode.S))
		{
			SPress = true;
		}

		if (SPress == true || APress == true && WPress == false || DPress == true && WPress == false || WPress == true && SPress == false)
		{
			GetComponent<Animation>().Play("soldierRun");
			speed = 4f;
		//	GM.SetActive (false);
		}


		if (WPress == true && APress == true || WPress == true && DPress == true || SPress == true && APress == true || SPress == true && DPress == true)
		{
			GetComponent<Animation>().Play("soldierRun");
			speed = 3f;
			GM.SetActive (false);
		}


		if (SPress == false && APress == false && DPress == false && WPress == false)
		{
			speed = 0f;
			GetComponent<Animation>().Play("soldierIdle");
			GM.SetActive (true);
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100))
		{
			lookPos = hit.point;
		}

		Vector3 lookDir = lookPos - transform.position;
		lookDir.y = 0;

		transform.LookAt (transform.position + lookDir, Vector3.up);
	}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//if 
		if (playerhealth.PlayerHP >= 1) 
		{
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (horizontal, 0, vertical);
			GetComponent<Rigidbody> ().velocity = movement * speed;
		}

		//rigidBody.AddForce (movement * speed /Time.deltaTime);
	}

}
