using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
	private float playerDistance;
	public float chaseStart;
	public float maxFollowOffset;
	public float collisionAvoidance;
	private Rigidbody ship;

	int layerMask;

	public GameObject FindClosestEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Player");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	void Start()
	{
		layerMask = 1 << LayerMask.NameToLayer ("Ship");
		layerMask = ~layerMask;
	}

	void Awake()
	{
		ship = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		playerDistance = Vector3.Distance (FindClosestEnemy().transform.position, transform.position);

		if(FindClosestEnemy())
		{
			if(playerDistance < chaseStart)
			{
				if (playerDistance > maxFollowOffset)
				{
					RaycastHit hit;

					Ray left = new Ray (gameObject.transform.position, transform.forward + -(transform.right));
					if (Physics.Raycast (left, out hit, collisionAvoidance, layerMask))
					{
						Debug.DrawLine (left.origin, hit.point);
						turnright ();
					}

					Ray right = new Ray (gameObject.transform.position, transform.forward + transform.right);
					if (Physics.Raycast (right, out hit, collisionAvoidance, layerMask))
					{
						Debug.DrawLine (right.origin, hit.point);
						turnleft ();
					}

					Ray front = new Ray (gameObject.transform.position, transform.forward);
					if (Physics.Raycast (front, out hit, collisionAvoidance, layerMask))
					{
						var hovercontrol = GetComponent<HoverControlsLance> ();
						Debug.DrawLine (front.origin, hit.point);

						if (Physics.Raycast (front, out hit, (collisionAvoidance / 2), layerMask))
						{
							reverse ();
						}

						chase ();
					}
					else
					{
						lookAtPlayer ();
						chase ();
					}
				}

				if ((playerDistance + 2) < maxFollowOffset)
				{
					lookAtPlayer ();
					reverse ();
				}
			}
		}
	}

	void lookAtPlayer()
	{
		var hovercontrol = GetComponent<HoverControlsLance> ();
		Quaternion rotation = Quaternion.LookRotation (FindClosestEnemy().transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * hovercontrol.turnSpeed);
	}

	void turnleft()
	{
		var hovercontrol = GetComponent<HoverControlsLance> ();
		ship.AddRelativeTorque (0f, -100000 * hovercontrol.turnSpeed, 0f);
	}

	void turnright()
	{
		var hovercontrol = GetComponent<HoverControlsLance> ();
		ship.AddRelativeTorque (0f, 100000 * hovercontrol.turnSpeed, 0f);
	}

	void chase()
	{
		var hovercontrol = GetComponent<HoverControlsLance> ();
		transform.Translate (Vector3.forward * hovercontrol.forwardSpeed * Time.deltaTime);
	}

	void reverse()
	{
		var hovercontrol = GetComponent<HoverControlsLance> ();
		transform.Translate (Vector3.back * hovercontrol.backwardSpeed * Time.deltaTime);
	}
}