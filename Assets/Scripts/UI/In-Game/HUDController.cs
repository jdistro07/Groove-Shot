﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Text dispHP;
	
	// Update is called once per frame
	void Update () {
        var hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        dispHP.text = hp.health.ToString();
    }
}