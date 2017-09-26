using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileWidgetController : MonoBehaviour {

    public Text name;

    private void OnEnable()
    {
        var main_uiIDCatcher = GameObject.Find("MainCanvas").GetComponent<uiIDCatcher>();
        name.text = main_uiIDCatcher.player_id;
    }

}
