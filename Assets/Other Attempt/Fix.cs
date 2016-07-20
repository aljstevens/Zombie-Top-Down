using UnityEngine;
using System.Collections;

public class Fix : MonoBehaviour {

	public GameObject prefab;
	public GameObject Bullet;
	public GameObject Player;
	
	void Update()
	{
		Vector3 mousePosTest = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		Ray ray = Camera.main.ScreenPointToRay(mousePosTest);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (Input.GetButtonDown("Fire1"))
			{
				Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
				GameObject obj = Instantiate(prefab, hitPoint, Quaternion.identity) as GameObject;
			}
		}
	}
}
