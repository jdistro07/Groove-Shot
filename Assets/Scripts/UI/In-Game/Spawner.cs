using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour {

    public GameObject[] spawnPoints;
    //public int index;

    public string playerShip;

	// Use this for initialization
	void Start () {
        playerShip = GameManager.ship;

        Spawn_Player();
    }

    public void Spawn_Player()
    {
        int index;
        var res = Resources.Load("playerShips/" + playerShip);
        index = UnityEngine.Random.Range(0, spawnPoints.Length);

        try
        {
            Debug.Log(index);
            Instantiate(res, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);
        }
        catch(ArgumentException ae){
            Debug.Log("[Spawner] Cannot Spawn Ship: " + ae);
        }
    }
}
