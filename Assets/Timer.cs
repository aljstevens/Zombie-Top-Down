using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public float Mins;
	public float Seconds;

	public float secondstext;
	public float minstext;

	public Text TimerNumber;
	public Text TimerNumber2;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Mins <= 0 && Seconds <= 0) 
		{
			Destroy (gameObject);
		}

		if (secondstext >= 59.50) 
		{
			secondstext -= 60f;
			minstext += 1;
		}

		if (secondstext <=9.50 && TimerNumber != null)
		{
			TimerNumber.text = "0" + Seconds.ToString ();
		}

		if (secondstext >=9.50 && TimerNumber != null)
		{
			TimerNumber.text = "" + Seconds.ToString ();
		}


		if (secondstext <= 0 && minstext >=1) 
		{
			secondstext = 59.50f;
			minstext -= 1;
		}
			
		{
			secondstext -= Time.deltaTime;
			Seconds = Mathf.Round (secondstext);
			Mins = Mathf.Round (minstext);
			TimerNumber2.text = "" + minstext.ToString ();
		}
	}
}
