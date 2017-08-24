using System;
using System.Collections;
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
        //playerObject = GameObject.FindGameObjectWithTag("Player");
        tracker();
    }

    void Update()
    {
        if (playerObject == null)
        {
            Debug.Log("Camera Status: Finding player");

            try
            {
                tracker();
            }
            catch (NullReferenceException ex)
            {
                Debug.Log(ex);
            }
        }
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

    public void tracker()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
}
