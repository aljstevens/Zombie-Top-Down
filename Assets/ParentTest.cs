using UnityEngine;
using System.Collections;

public class ParentTest : MonoBehaviour {

	public GameObject CurrentHolder;

	// Use this for initialization
	void Awake ()
	{
		CurrentHolder = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
