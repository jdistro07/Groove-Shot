using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonAim : MonoBehaviour
{
	//private Vector3 mousePos;
	//private float lastAngle;
	
	// Update is called once per frame
	void Update ()
	{
        //mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.z, Camera.main.transform.position.y - transform.position.y));
        //transform.LookAt (mousePos);

		Vector3 v3T = Input.mousePosition;
		v3T.z = Mathf.Abs (Camera.main.transform.position.y - transform.position.y);
        v3T = Camera.main.ScreenToWorldPoint (v3T);

        transform.LookAt(v3T);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        
	}
}
