using UnityEngine;
using System.Collections;

public class CloseTest : MonoBehaviour {

	public GameObject Target;
	public GameObject FocusedTarget;
	// Find the name of the closest enemy
	
	GameObject FindClosestEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	void Update ()
	{
		Target = FindClosestEnemy ();

		if (FocusedTarget == null) 
		{
			FocusedTarget = Target;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == FocusedTarget)
		{
			Debug.Log ("Fcoused");
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == FocusedTarget)
		{
			FocusedTarget = null;
		}
	}

}

