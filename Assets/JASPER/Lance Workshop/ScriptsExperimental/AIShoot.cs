using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
	private float turretDistance;

	public float targetRange;
	public float aimDistance;
	public float rotationSpeed;

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
		layerMask = (1 << LayerMask.NameToLayer ("Ship"));
	}

	void FixedUpdate ()
	{
		if (FindClosestEnemy ())
		{
			turretDistance = Vector3.Distance (FindClosestEnemy().transform.position, transform.position);

			if (turretDistance < targetRange)
			{
				AimAndShoot ();
			}
		}
	}

	void AimAndShoot()
	{
		var shoot = GetComponent<Shoot> ();

		Quaternion rotation = Quaternion.LookRotation (FindClosestEnemy().transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotationSpeed * Time.deltaTime);

		RaycastHit hit;

		Ray aim = new Ray (gameObject.transform.position, transform.forward);
		if (Physics.Raycast (aim, out hit, aimDistance, layerMask))
		{
			if (shoot.singleBarrel == true)
			{
				shoot.SingleBarrel ();
			}
			else
			{
				shoot.TwinBarrel ();
			}
		}
	}
}