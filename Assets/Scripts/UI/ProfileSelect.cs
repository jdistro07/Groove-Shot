using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSelect : MonoBehaviour {

    public Text obj_Text;

    public void OnClick()
    {
        var main_ui_uiIDCatcher = GameObject.Find("MainCanvas").GetComponent<uiIDCatcher>();
        main_ui_uiIDCatcher.player_id = obj_Text.text;

        Debug.Log("Profile Selected: "+obj_Text.text);
    }
}
