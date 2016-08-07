using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float PlayerHP=100f;
	public bool Fallen;
	public GameObject GM;
	public Image Health;
	public float Width;

	// Use this for initialization
	void Awake () 
	{
		Width = Health.rectTransform.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (PlayerHP <= 0 && Fallen == false)
		{
			Debug.Log ("Down");
			GM.SetActive (false);
			GetComponentInParent<Animation>().Play("soldierDieBack");
			Fallen = true;
		}
	}

	void FixedUpdate ()
	{
		Width = PlayerHP;
		Health.rectTransform.sizeDelta = new Vector2 (Width, 20);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("AttackRange"))
		{
//			PlayerHP -= 5f;
//			Debug.Log ("Ouchy");
		}

		if (other.gameObject.tag == ("Charge"))
		{
			PlayerHP -= 10f;
		}

		if (other.gameObject.tag == ("FinalPlauge"))
		{
			PlayerHP -= 40f;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == ("Plauge"))
		{
			PlayerHP -= 3f * Time.deltaTime;;

		}
	}
}