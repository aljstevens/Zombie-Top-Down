using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {

	public GameObject Target;

	// Use this for initialization
	void Start () 
	{
		Target = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float y = Target.transform.position.y;
		float z = Target.transform.position.z;
		transform.rotation = Quaternion.Euler(90, y, z);
		//transform.LookAt (Target.transform);
	}
}
