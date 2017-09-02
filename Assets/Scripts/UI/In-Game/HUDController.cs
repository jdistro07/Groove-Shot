using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Text dispHP;

    void Start()
    {
        HUDTracker();
    }

    // Update is called once per frame
    void Update () {
        HUDTracker();
    }

    void HUDTracker()
    {
        try
        {
            var hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            dispHP.text = hp.health.ToString();
        }
        catch(NullReferenceException nre)
        {
            dispHP.text = "0";
            Debug.Log("[HUDController] Finding Player: "+nre);
        }
    }
}
