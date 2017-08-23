﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {

    public GameObject playerObject;
    public float yOffset = 0f;
    public float zOffset = 0f;

    public Vector3 offset;

    public bool enableSmooth;
    public float smoothSpeed = .125f;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate() {

        Vector3 desiredPosition = new Vector3();
        desiredPosition = playerObject.transform.position+offset;

        if (enableSmooth)
        {
            transform.position = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        }
        else
        {
            transform.position = new Vector3(playerObject.transform.position.x, 
             playerObject.transform.position.y + yOffset, 
             playerObject.transform.position.z + zOffset);
        }
    }
}
