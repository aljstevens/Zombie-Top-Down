using UnityEngine;
using System.Collections;

public class SoldierHealth : MonoBehaviour {

	public float SoldierHP=100f;
	public bool Fallen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SoldierHP <= 0 && Fallen == false)
		{
			Debug.Log ("Down");
			GetComponentInParent<Animation>().Play("soldierDieBack");
			Fallen = true;
			gameObject.tag = ("Killed");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("AttackRange"))
		{
			SoldierHP -= 5f;
		}
	}
}