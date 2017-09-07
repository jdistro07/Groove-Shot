using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AISpawner : MonoBehaviour {
    public List<GameObject> ai;
    public GameObject[] spawn;

    int indexAI;
    int indexSpawn;

    private void Start()
    {
        var res = Resources.LoadAll<GameObject>("ai/");

        foreach (GameObject obj in res)
        {
            ai.Add(obj);
        }


        for (int x=0; x<5; x++)
        {
            indexAI = UnityEngine.Random.Range(0,ai.Count);
            indexSpawn = UnityEngine.Random.Range(0, spawn.Length);

            string name = ai[indexAI].name;
            Debug.Log(name);
        }
    }
}
