using UnityEngine;
using System.Collections;

public class LowerY : MonoBehaviour {

	private float ObjectX;
	private float ObjectZ;
	
	void Update () 
	{
		
		ObjectX = transform.position.x;
		ObjectZ = transform.position.z;
		transform.localPosition = new Vector3(ObjectX, 0f, ObjectZ);
		
	}
}
