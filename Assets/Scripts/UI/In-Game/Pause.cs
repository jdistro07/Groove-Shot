using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause : MonoBehaviour {

    private bool isPaused;

    private void OnEnable()
    {
        pause();
    }

    private void OnDisable()
    {
        resume();
    }

    private void pause()
    {
        try
        {
            var hover = GameObject.FindGameObjectWithTag("Player").GetComponent<HoverControlsLance>();
            //var fireExp = GameObject.FindGameObjectWithTag("Turret").GetComponentInChildren<ShootingExperimental>(); //Experimental script
            var fire = GameObject.FindGameObjectWithTag("Turret").GetComponentInChildren<Shooting>();

            //fireExp.enabled = false;
            fire.enabled = false;
        }
        catch (NullReferenceException nre)
        {
            Debug.Log("[Pause] Player not present");
        }

    }

    private void resume()
    {
        try
        {
            var hover = GameObject.FindGameObjectWithTag("Player").GetComponent<HoverControlsLance>();
            //var fireExp = GameObject.FindGameObjectWithTag("Turret").GetComponentInChildren<ShootingExperimental>(); //Experimental script
            var fire = GameObject.FindGameObjectWithTag("Turret").GetComponentInChildren<Shooting>();

            //fireExp.enabled = true;
            fire.enabled = true;
        }
        catch (NullReferenceException nre)
        {
            Debug.Log("[Pause] Player not present");
        }
    }
}
