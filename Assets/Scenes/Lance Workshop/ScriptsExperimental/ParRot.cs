using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParRot : MonoBehaviour
{
	void FixedUpdate ()
	{
		transform.rotation = transform.parent.Find ("GameObject").rotation;
	}
}
