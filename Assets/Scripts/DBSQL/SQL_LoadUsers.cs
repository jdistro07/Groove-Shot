using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SQL_LoadUsers : MonoBehaviour {

    [Header("DATABASE COMPONENTS")]
    public string url = "http://localhost/GrooveShotDB/getusers.php"; // default link
    public string[] users;
    public int record_count;

    public GameObject button;
    public RectTransform panel;
    public Text buttonText;

    private void OnEnable()
    {
        StartCoroutine(LoadUsers());
    }

    private void OnDisable()
    {
        record_count = users.Length;
    }

    private IEnumerator LoadUsers()
    {
        WWW link = new WWW(url); // url for the database
        yield return link; // wait for link to be downloaded

        // place records to string and store it on the array splitted on ';'
        string data = link.text;
        users = data.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

        while (record_count != users.Length)
        {
            try
            {
                record_count++;
                GameObject go_button = (GameObject)Instantiate(button);
                buttonText.text = users[record_count];

                go_button.transform.SetParent(panel, false);
            }
            catch
            {
                Debug.Log("[SQL_LoadUser] Record loop stopped successfully!");
                break;
            }
            yield return record_count;
        }
    }
}