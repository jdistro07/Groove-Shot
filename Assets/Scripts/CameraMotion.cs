using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {

    public Transform target;

	void LateUpdate() {
		transform.position = new Vector3 (target.position.x,51f,target.position.z);
	}
}
