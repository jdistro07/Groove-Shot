using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiIDCatcher : MonoBehaviour {

    //Refference ObjectIDTEMP.cs
    private ObjectID objectID;

    public string mapID;
    public string shipID;

	// Use this for initialization
	void Start () {
        objectID = GetComponent<ObjectID>();

        //Clear string values at startup
        mapID = string.Empty;
        shipID = string.Empty;

        print("Map ID = "+mapID);
        print("Ship ID = "+shipID);
    }

    //control functions
    public void onClickMap()
    {
        mapID = string.Empty;
        mapID = objectID.ObjectIDMap;

        //Debug output
        print("Current Value = " + mapID);
    }




}
