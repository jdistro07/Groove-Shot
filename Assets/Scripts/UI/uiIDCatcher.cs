using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uiIDCatcher : MonoBehaviour {

    public string mapID;
    public string shipID;

	// Use this for initialization
	void Start ()
	{
		mapID = string.Empty;
		shipID = string.Empty;
    }

    /*
		When a map is clicked, return the value to the catcher
	*/
    public void onMapClick()
    {
		mapID = EventSystem.current.currentSelectedGameObject.name;
		print (mapID);
    }

    public void CleanUpMapValue()
    {
        mapID = string.Empty;
    }

    public void CleanUpShipValue()
    {
        shipID = string.Empty;
    }
}