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
	public float backwardSpeed = 25f;
	public float turnSpeed = 5f;


	//input
	private float powerInput;
	private float turnInput;

	//others
	int layerMask;

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
		RaycastHit hit;
		for (int i = 0; i < hoverPointsGameObject.Length; i++)
		{
			var hoverPoint = hoverPointsGameObject [i];

			if (Physics.Raycast (hoverPoint.transform.position, Vector3.down, out hit, hoverHeight, layerMask))
			{
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

		if(powerInput > 0)
			shipBody.AddRelativeForce (0f, 0f, powerInput * forwardSpeed);
	}
}
