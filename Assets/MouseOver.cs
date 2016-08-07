using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public Texture2D cursorTexture;
	public Texture2D cursorTexture2;

	private InRange inrange;
	public GameObject BrokenBox;

	// Use this for initialization
	void Start () 
	{
		inrange = GetComponentInChildren <InRange> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseEnter()
	{
		if (inrange.InRangeCheck == true)
		{
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
		}
	}

	void OnMouseOver()
	{
		if (inrange.InRangeCheck == true)
		{
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
		}
	}

	void OnMouseExit()
	{
		if (inrange.InRangeCheck == true) 
		{
			Cursor.SetCursor (cursorTexture2, hotSpot, cursorMode);
		}
	}

	void OnMouseDown ()
	{
		if (inrange.InRangeCheck == true) 
		{
			BrokenBox.SetActive (true);
			inrange.InRangeCheck = false;
			Cursor.SetCursor (cursorTexture2, hotSpot, cursorMode);
			Destroy (gameObject);
		}
	}
}
