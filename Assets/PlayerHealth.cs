using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float PlayerHP=100f;
	public bool Fallen;
	public GameObject GM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerHP <= 0 && Fallen == false)
		{
			Debug.Log ("Down");
			GM.SetActive (false);
			GetComponentInParent<Animation>().Play("soldierDieBack");
			Fallen = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("AttackRange"))
		{
//			PlayerHP -= 5f;
//			Debug.Log ("Ouchy");
		}
	}
}