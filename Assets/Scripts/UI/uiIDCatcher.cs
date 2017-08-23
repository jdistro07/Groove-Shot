using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class uiIDCatcher : MonoBehaviour {

    //UIElements
    public Text dispMapName;

    //IDs
    public string mapID;
    public string shipID;

    private void Awake()
    {
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

        dispMapName.text = mapID;

        //print(mapID);
    }



    public void CleanUpMapValue() //Cleanup values upon exit Map Selection
    {
        mapID = string.Empty;
        dispMapName.text = "[Map Name]";
    }



    public void CleanUpShipValue() //Cleanup values upon exit Ship Selection
    {
        shipID = string.Empty;
    }

    //For ship preview
    public void OnClickCatcher()
    {
        shipID = string.Empty;
        var id = GameObject.FindGameObjectWithTag("Preview").GetComponent<ShipInfo>();
        shipID = id.id;
    }
}