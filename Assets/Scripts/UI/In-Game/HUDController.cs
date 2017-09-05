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
        bool debugged = false;
        try
        {
            debugged = true;
            var hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            dispHP.text = hp.health.ToString();
        }
        catch
        {
            dispHP.text = "0";
        }
    }
}
