using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverControlsLance : MonoBehaviour
{
	//hover properties
	public float hoverForce;
	public float counterHover;
	public float hoverHeight;


	//Forward and Speed Properties for vehicles
	public float forwardSpeed;
	public float backwardSpeed;
	public float turnSpeed;


	//input
	public float powerInput;
	public float turnInput;

	//others
	int layerMask;
	public bool player = true;

	Rigidbody shipBody;
	public GameObject[] hoverPointsGameObject;

	void Start()
	{
		layerMask = 1 << LayerMask.NameToLayer ("Ship");
		layerMask = ~layerMask;
	}

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
		if (player == true) {
			RaycastHit hit;
			for (int i = 0; i < hoverPointsGameObject.Length; i++) {
				var hoverPoint = hoverPointsGameObject [i];

				if (Physics.Raycast (hoverPoint.transform.position, Vector3.down, out hit, hoverHeight, layerMask)) {
					shipBody.AddForceAtPosition (Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);

					if (powerInput < 0)
						shipBody.AddRelativeForce (0f, 0f, powerInput * backwardSpeed);

					shipBody.AddRelativeTorque (0f, turnInput * turnSpeed, 0f);
				}
				else
				{
					if (transform.position.y > hoverPoint.transform.position.y)
						shipBody.AddForceAtPosition (hoverPoint.transform.up * hoverForce, hoverPoint.transform.position);

					shipBody.AddForceAtPosition (Vector3.up * -counterHover, hoverPoint.transform.position);
				}
			}

			if (powerInput > 0)
				shipBody.AddRelativeForce (0f, 0f, powerInput * forwardSpeed);
		}
		else
		{
			RaycastHit hit;
			for (int i = 0; i < hoverPointsGameObject.Length; i++)
			{
				var hoverPoint = hoverPointsGameObject [i];

				if (Physics.Raycast (hoverPoint.transform.position, Vector3.down, out hit, hoverHeight, layerMask))
				{
					shipBody.AddForceAtPosition (Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);
				}
				else
				{
					if (transform.position.y > hoverPoint.transform.position.y)
						shipBody.AddForceAtPosition (hoverPoint.transform.up * hoverForce, hoverPoint.transform.position);

					shipBody.AddForceAtPosition (Vector3.up * -counterHover, hoverPoint.transform.position);
				}
			}
		}
	}
}