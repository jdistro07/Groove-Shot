using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    //scripts
    private uiIDCatcher id;

	public string shipID;
    public string mapID;

    public void OnClickPlay()
    {
        shipID = id.shipID;
        mapID = id.mapID;
    }
}
