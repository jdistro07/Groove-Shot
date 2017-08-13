using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class uiIDCatcher : MonoBehaviour {

    //Script Referrence
    private objDetails details;

    //info section
    public string MapName;

    //UIElements
    public Text dispMapName;

    //IDs
    public string mapID;
    public string shipID;

    private void Awake()
    {
        //script components
        details = GetComponent<objDetails>();

        //Initialize empty IDs upon awake
        mapID = string.Empty;
        shipID = string.Empty;
    }



    /*
		When a map is clicked, return the value to the catcher
	*/
    public void onMapClick()
    {
        mapID = string.Empty;

        //Get map ID based  on GameObject name
		mapID = EventSystem.current.currentSelectedGameObject.name;
        MapName = details.displayName;

        dispMapName.text = MapName;

        //print(mapID);
    }



    public void CleanUpMapValue() //Cleanup values upon exit Map Selection
    {
        mapID = string.Empty;
    }



    public void CleanUpShipValue() //Cleanup values upon exit Ship Selection
    {
        shipID = string.Empty;
    }
}