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


        for (int x=0; x<spawn.Length; x++)
        {
            indexAI = UnityEngine.Random.Range(0,ai.Count);
            indexSpawn = UnityEngine.Random.Range(0, spawn.Length);

            if (x == 5)
            {
                break;
            }
            else
            {
                Instantiate(ai[indexAI], spawn[indexSpawn].transform.position, spawn[indexSpawn].transform.rotation);
            }
        }
    }

    public void Respawn(GameObject obj)
    {
        indexSpawn = UnityEngine.Random.Range(0, spawn.Length);
        Destroy(gameObject);
        Instantiate(obj, spawn[indexSpawn].transform.position, spawn[indexSpawn].transform.rotation);
    }
}
