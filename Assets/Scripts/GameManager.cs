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
using System;


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
        Debug.Log("[Game Manger] Map: " + lvl);
        Debug.Log("[Game Manager] Ship: " + ship);
    }

    public void uiIDClassFetcher()
    {
        var uiID = GameObject.FindGameObjectWithTag("Main UI Interface").GetComponent<uiIDCatcher>();
        lvl = uiID.mapID;
        ship = uiID.shipID;

        //Debug.Log(lvl+" "+ship);
    }

    public void OnLeaveGameConfirm(){
        lvl = "MainUI";
        SceneManager.LoadScene("LoadingScreen");
    }

    public IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync(lvl);

        while (!async.isDone)
        {
            float p = Mathf.Clamp01(async.progress/.9f);
            Debug.Log(p);
            yield return null;
        }

        if (lvl == "MainUI")
        {
            lvl = string.Empty;
            ship = string.Empty;

            Debug.Log("[GameManager] lvl = "+lvl);
            Debug.Log("[GameManager] ship = "+ship);
        }
    }
}