using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

	public GameObject LoadedArea;
	public GameObject NextArea;

	private GameObject TempArea;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			LoadedArea.SetActive (false);
			NextArea.SetActive (true);
			//TempArea = LoadedArea;
			//LoadedArea = NextArea;
			//NextArea = TempArea;
			//TempArea = null;

		}

	}
}
