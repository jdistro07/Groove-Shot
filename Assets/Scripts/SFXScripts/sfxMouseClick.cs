using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxMouseClick : MonoBehaviour {

    public AudioClip cannon;
	
	// Update is called once per frame
	void Update () {
        //For cannon fire
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(cannon);
        }
    }
}
