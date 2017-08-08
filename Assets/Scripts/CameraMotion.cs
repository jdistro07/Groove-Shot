using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {

    public Transform target;
    public float yOffset = 0f;
    public float zOffset = 0f;

	void LateUpdate() {
		transform.position = new Vector3 (target.position.x,target.position.y+yOffset,target.position.z+zOffset);
	}
}
