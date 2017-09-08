using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
	private float playerDistance;
	private Rigidbody ship;
	private GameObject waypoint;
	private int wayindex;
	private int lastindex;

	public float chaseStart;
	public float maxFollowOffset;
	public float collisionAvoidance;

	int obstacle;
	int target;
	GameObject[] waypoints;

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
		obstacle = (1 << LayerMask.NameToLayer ("Ship") | 1 << LayerMask.NameToLayer ("Waypoints"));
		obstacle = ~obstacle;

		target = (1 << LayerMask.NameToLayer ("Ship") | 1 << LayerMask.NameToLayer ("Waypoints"));
	}

	void Awake()
	{
		ship = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		waypoints = GameObject.FindGameObjectsWithTag ("Waypoint");

		if (wayindex == lastindex)
		{
			wayindex = Random.Range (0, waypoints.Length);
		}

		waypoint = waypoints[wayindex];
	}

	void FixedUpdate ()
	{
		if (FindClosestEnemy ())
		{
			playerDistance = Vector3.Distance (FindClosestEnemy().transform.position, transform.position);

			if (playerDistance < chaseStart)
			{
				intercept ();
			}
			else
			{
				patrol ();
			}
		}
		else
		{
			patrol ();
		}
	}

	void OnTriggerEnter()
	{
        try
        {
            if (gameObject.tag == "AI")
            {
                lastindex = wayindex;
                wayindex = Random.Range(0, waypoints.Length);
                waypoint = waypoints[wayindex];
            }
        }
        catch
        {

        }
		
	}

	void intercept()
	{

		if (playerDistance > maxFollowOffset)
		{
			RaycastHit hit;

			Ray left = new Ray (gameObject.transform.position, transform.forward + -(transform.right));
			if (Physics.Raycast (left, out hit, collisionAvoidance, obstacle))
			{
				Debug.DrawLine (left.origin, hit.point);
				turnright ();
			}

			Ray right = new Ray (gameObject.transform.position, transform.forward + transform.right);
			if (Physics.Raycast (right, out hit, collisionAvoidance, obstacle))
			{
				Debug.DrawLine (right.origin, hit.point);
				turnleft ();
			}

			Ray front = new Ray (gameObject.transform.position, transform.forward);
			if (Physics.Raycast (front, out hit, collisionAvoidance, obstacle))
			{
				var hovercontrol = GetComponent<HoverControlsLance> ();
				Debug.DrawLine (front.origin, hit.point);

				if (Physics.Raycast (front, out hit, (collisionAvoidance / 2), obstacle))
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

	void patrol()
	{
		RaycastHit hit;

		Ray northwest = new Ray (gameObject.transform.position, transform.forward + -(transform.right));
		if (Physics.Raycast (northwest, out hit, collisionAvoidance, obstacle))
		{
			Debug.DrawLine (northwest.origin, hit.point);
			turnright ();
		}

		Ray northeast = new Ray (gameObject.transform.position, transform.forward + transform.right);
		if (Physics.Raycast (northeast, out hit, collisionAvoidance, obstacle))
		{
			Debug.DrawLine (northeast.origin, hit.point);
			turnleft ();
		}

		Ray north = new Ray (gameObject.transform.position, transform.forward);
		if (Physics.Raycast (north, out hit, collisionAvoidance, obstacle))
		{
			var hovercontrol = GetComponent<HoverControlsLance> ();
			Debug.DrawLine (north.origin, hit.point);

			if (Physics.Raycast (north, out hit, (collisionAvoidance / 2), obstacle))
			{
				reverse ();
			}

			chase ();
		}
		else
		{
			FindWayPoint ();
			chase ();
		}
	}

	void FindWayPoint()
	{
		try
		{
			var hovercontrol = GetComponent<HoverControlsLance> ();
			Quaternion rotation = Quaternion.LookRotation (waypoint.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * hovercontrol.turnSpeed);
		}
		catch
		{
			
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