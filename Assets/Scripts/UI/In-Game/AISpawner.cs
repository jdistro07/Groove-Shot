using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AISpawner : MonoBehaviour {

    public GameObject[] spawnPoints;

    public void RespawnAI(string aiID)
    {
        int index;
        var res = Resources.Load("ai/" + aiID);
        index = UnityEngine.Random.Range(0, spawnPoints.Length);

        try
        {
            Debug.Log(index);
            Instantiate(res, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);
        }
        catch (ArgumentException ae)
        {
            Debug.Log("[Spawner] Cannot Spawn Ship: " + ae);
        }
    }
}
