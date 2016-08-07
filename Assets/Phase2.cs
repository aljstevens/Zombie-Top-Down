using UnityEngine;
using System.Collections;

public class Phase2 : MonoBehaviour {

	public GameObject Beam1;
	public GameObject Beam2;
	public GameObject Beam3;
	public GameObject Beam4;

	public GameObject Wood;
	public float ObjectX;
	public float ObjectY;
	public float ObjectZ;

	// Use this for initialization
	void Awake ()
	{
//		ObjectX = 130.4f;
//		ObjectZ = 6.78f;
//		ObjectY = 210.44f;
		ObjectX = Wood.transform.position.x;
		ObjectZ = Wood.transform.position.z;
		ObjectY = Wood.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Beam1 == null && Beam2 == null && Beam3 == null && Beam4 == null && Wood != null)
		{
			Wood.transform.localPosition = new Vector3(ObjectX, ObjectY -=0.3f, ObjectZ);
		}
	}
}
