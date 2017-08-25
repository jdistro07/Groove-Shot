/*
 This is a dynamic script to generally initialize the ff:
 *Players
 * Spawn Points
 
 This where all information is compiled and processed upon spawning players and AI's.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //scripts
    private uiIDCatcher id;

    public static string lvl;
    public static string ship;


    //loaders
    AsyncOperation async;

    private void Awake()
    {
        Debug.Log("[Game Manger] Map: "+lvl);
        Debug.Log("[Game Manager] Ship: "+ship);
    }

    private void Start()
    {
        StartCoroutine(Load());
    }

    public void uiIDClassFetcher()
    {
        var uiID = GameObject.FindGameObjectWithTag("Main UI Interface").GetComponent<uiIDCatcher>();
        lvl = uiID.mapID;
        ship = uiID.shipID;

        //Debug.Log(lvl+" "+ship);
    }

    private IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync(lvl);


        while (!async.isDone == false)
        {
            if (async.progress == 0.9f)
            {
                Mathf.Clamp01(async.progress/0.9f);
                async.allowSceneActivation = true;
            }

            yield return null;
        }

        Debug.Log(async.progress);
    }
}