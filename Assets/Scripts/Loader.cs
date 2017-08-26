using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    // Use this for initialization
    void Start () {
        var gm = GameObject.FindGameObjectWithTag("Loader").GetComponent<GameManager>();

        StartCoroutine(gm.Load());
	}
}
