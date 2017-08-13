using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectID : MonoBehaviour
{
    public string InputIDMap;
    public string InputIDShip;

	private string IDMap;
    private string IDShip;

	void Awake()
	{
		IDMap = InputIDMap;
		IDShip = InputIDShip;
	}

}
