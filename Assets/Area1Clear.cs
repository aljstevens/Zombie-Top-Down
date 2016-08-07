using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Area1Clear : MonoBehaviour {

	public float EnemyCount;
	public float VictoryPoints;
	public GameObject Spawners;
	public GameObject APC;
	public GameObject WayPoint;
	public GameObject FrontLinesSoldiers;
	public Image VictoryImage;
	public Text VictoryText;
	public GameObject WinMessage;
	public GameObject LostMessage;
	public GameObject VictoryObject;

	private NavMeshAgent agent;
	private SoldierAI soldierai;
	public bool Completed;
	private bool Used;

	public bool VPUnderOne = true;
	public bool VPUnderTen;
	public bool VPUnderHundred;


	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
			
			if (VPUnderOne == true) {
				VictoryText.text = ("    ") + VictoryPoints.ToString ();
				VictoryImage.rectTransform.sizeDelta = new Vector2 (VictoryPoints, 20);
			}

			if (VPUnderTen == true) {
				VictoryText.text = ("  ") + VictoryPoints.ToString ();
				VictoryImage.rectTransform.sizeDelta = new Vector2 (VictoryPoints, 20);
			}

			if (VPUnderHundred == true) {
				VictoryText.text = VictoryPoints.ToString ();
				VictoryImage.rectTransform.sizeDelta = new Vector2 (VictoryPoints, 20);
			}

			if (VictoryPoints <= 9.99f) {
				VPUnderOne = true;
			}

			if (VictoryPoints >= 9.99f && VPUnderOne == true && VPUnderTen == false) {
				VPUnderTen = true;
				VPUnderOne = false;
			}

			if (VictoryPoints >= 99.99f && VPUnderTen == true && VPUnderHundred == false) {
				VPUnderHundred = true;
				VPUnderTen = false;
			}

			if (APC == null) 
			{
				Destroy (Spawners);
				Destroy (VictoryObject);
				LostMessage.SetActive (true);
			}

			if (VictoryPoints >= 150 && APC != null && Used == false) {
				Destroy (Spawners);
				Destroy (VictoryObject);
				WinMessage.SetActive (true);
				Completed = true;
				agent = APC.GetComponent <NavMeshAgent> ();
				agent.enabled = true;
				soldierai = APC.GetComponent <SoldierAI> ();
				soldierai.WayPoint = WayPoint;
				FrontLinesSoldiers.SetActive (true);
				Used = true;
			}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Count")
		{
			EnemyCount += 1;
			Destroy (other.gameObject);
		}
	}
}
