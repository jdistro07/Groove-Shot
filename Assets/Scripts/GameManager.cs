/*
 This is a dynamic script to generally initialize the ff:
 *Players
 * Spawn Points
 
 This where all information is compiled and processed upon spawning players and AI's.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //scripts
    private uiIDCatcher id;

    //Spawn array
    public GameObject[] spawnPoints;

    //spawn index for storing numbers
    public int spawnIndex;

    public string shipID;
    public GameObject playerCharacter;

    private void Awake()
    {
        shipID = id.shipID;
        Debug.Log(shipID);
    }

    void Start()
    {
        playerCharacter = Resources.Load(shipID) as GameObject;
        spawnPlayer();
    }

    // Update is called once per frame
    void Update () {
        
	}

    void spawnPlayer()
    {
        /*
         This function will choose a random index from the GameObject array "spawnpoints"(variable)
         for random Empty Game Objects
         for spawning players
         */
        spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = spawnPoints[spawnIndex].transform.position;
        Debug.Log(spawnIndex);

        Instantiate(playerCharacter, spawnLocation, transform.rotation);
    }
}
