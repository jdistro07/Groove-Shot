﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalControlEffect : MonoBehaviour {

    public ParticleSystem thruster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            //generate thrust forward
            thruster.Emit(1);
        }
  	}
}
