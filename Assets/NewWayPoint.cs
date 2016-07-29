using UnityEngine;
using System.Collections;

public class NewWayPoint : MonoBehaviour {

	public GameObject Soldier;
	public GameObject WayPoint;
	public GameObject PlayerEnterObject;
	public bool Ready;

	private PlayerEnter playerenter;
	private SoldierAI soldierai;

	// Use this for initialization
	void Awake ()
	{
		playerenter = PlayerEnterObject.GetComponent <PlayerEnter> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Ready == true && playerenter.Waiting == true) 
		{
			soldierai.WayPoint = WayPoint;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == Soldier) 
		{
			Ready = true;
			soldierai = Soldier.GetComponent<SoldierAI> ();
		}

	}
}
