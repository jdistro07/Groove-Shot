using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQL_LoadUsers : MonoBehaviour {

    [Header("DATABASE COMPONENTS")]
    public string url = "http://localhost/GrooveShotDB/getusers.php"; // default link
    public string[] users;

    public GameObject button;
    public RectTransform panel;

    private void OnEnable()
    {
        StartCoroutine(LoadUsers());
    }

    private IEnumerator LoadUsers()
    {
        WWW link = new WWW(url); // url for the database
        yield return link; // wait for link to be downloaded

        // place records to string and store it on the array splitted on ';'
        string data = link.text;
        users = data.Split(';');

        for (int count=0; count<users.Length; count++)
        {
            GameObject go_button = (GameObject)Instantiate(button);
            go_button.transform.SetParent(panel,false);
        }
    }
}
