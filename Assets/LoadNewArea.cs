using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

	public GameObject LoadedArea;
	public GameObject NextArea;
	public GameObject TeamAhead;

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
			if (LoadedArea != null && NextArea != null)
			{
				LoadedArea.SetActive (false);
				NextArea.SetActive (true);
			}
		}

		if (other.gameObject.tag == ("Player") && TeamAhead != null) 
		{
			TeamAhead.SetActive (true);
			TeamAhead = null;
		}

	}
}
