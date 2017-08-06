using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverControls : MonoBehaviour
{
    //hover properties
    public float hoverForce = 100f;
	public float counterHover = 50f;
    public float hoverHeight = 2f;


    //Forward and Speed Properties for vehicles
    public float forwardSpeed = 50f;
    public float turnSpeed = 5f;


    //input
    private float powerInput;
    private float turnInput;

    Rigidbody shipBody;
	public GameObject[] hoverPointsGameObject;

    void Awake()
    {
        shipBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
	}

	void FixedUpdate()
	{
		RaycastHit hit;
		for (int i = 0; i < hoverPointsGameObject.Length; i++)
		{
			var hoverPoint = hoverPointsGameObject [i];

			if (Physics.Raycast (hoverPoint.transform.position, -Vector3.up, out hit, hoverHeight)) {
				shipBody.AddForceAtPosition (Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);

				shipBody.AddRelativeTorque (0f,turnInput*turnSpeed,0f);
			} 
			else
			{
				shipBody.AddForceAtPosition (Vector3.up * -counterHover, hoverPoint.transform.position);
			}
		}

		//Ray ray = new Ray (transform.position, -transform.up);

		/*if(Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proprotionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * hoverForce * proprotionalHeight;

			shipBody.AddForce (appliedHoverForce, ForceMode.Acceleration);
		}*/

		shipBody.AddRelativeForce (0f,0f,powerInput*forwardSpeed);
		//shipBody.AddRelativeTorque (0f,turnInput*turnSpeed,0f);

	}
}
