using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScorePanelController : MonoBehaviour {

    //public GameObject window;

    [Header("SCORE COMPONENTS")]
    public GameObject panelScore;
    public Text playerID,playerName,score,rankNumber;

    [Header("DB")]
    public string url;
    public string[] records;

    public void OnEnable()
    {
        loader();
    }

    private IEnumerator loader()
    {
        WWW link = new WWW(url); // url for the database
        yield return link; // wait for link to be downloaded

        // place records to string and store it on the array splitted on ';'
        string data = link.text;
        records = data.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
    }

    public void OnClickRankings()
    {
        gameObject.SetActive(true);
    }

    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }
}
