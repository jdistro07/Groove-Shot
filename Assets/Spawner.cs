using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] spawnPoints;
    public int index;

    public string playerShip;

	// Use this for initialization
	void Start () {
        playerShip = GameManager.ship;

        Spawn_Player();
    }

    void Spawn_Player()
    {
        var res = Resources.Load("playerShips/" + playerShip);
        index = Random.Range(0,spawnPoints.Length);

        Debug.Log(index);
        Instantiate(res,spawnPoints[index].transform.position,spawnPoints[index].transform.rotation);
    }
}
