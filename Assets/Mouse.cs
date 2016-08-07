using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public Texture2D cursorTexture;


	// Use this for initialization
	void Start ()
	{
		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
