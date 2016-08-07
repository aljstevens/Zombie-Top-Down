using UnityEngine;
using System.Collections;

public class InRange : MonoBehaviour {

	public bool InRangeCheck;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public Texture2D cursorTexture;

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
			InRangeCheck = true;
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player")) 
		{
			InRangeCheck = false;
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
		}

	}
}
