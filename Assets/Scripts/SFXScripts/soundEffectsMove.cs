using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffectsMove : MonoBehaviour {

    /*
     * SFX for Ships while moving.
     *
     */

    void Update () {

        //For thruster sound effect
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<AudioSource>().Play();
        }else if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<AudioSource>().Stop();
        }

       

	}
}