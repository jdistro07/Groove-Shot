using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AISpawner : MonoBehaviour {
    public string[] ai;

    int index;

    private void Awake()
    {
        ai[0] = ("HGLS (AI)");

        for (int x = 0; !(x == 5); x++)
        {
            if (x == ai.Length)
            {
                index = UnityEngine.Random.Range(0, ai.Length);
                Debug.Log(ai.ToString());
            }
        }

        var res = Resources.Load<GameObject>("ai/");
        
    }
}
