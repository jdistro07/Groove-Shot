using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQL_LoadUsers : MonoBehaviour {

    [Header("DATABASE COMPONENTS")]
    public string url = "http://localhost/GrooveShotDB/getusers.php"; // default link
    public string[] users;
    public bool called = false;

    public GameObject button;
    public RectTransform panel;
    public Text buttonText;

    private void OnEnable()
    {
        StartCoroutine(LoadUsers());
    }

    private void OnDisable()
    {
        users = new string[0];
    }

    private IEnumerator LoadUsers()
    {
        WWW link = new WWW(url); // url for the database
        yield return link; // wait for link to be downloaded

        // place records to string and store it on the array splitted on ';'
        string data = link.text;
        users = data.Split(';');

        if (!called)
        {
            called = true;
            for (int count = 0; count < users.Length; count++)
            {
                GameObject go_button = (GameObject)Instantiate(button);
                buttonText.text = users[count];

                go_button.transform.SetParent(panel, false);
                yield return count;
            }
        }
        else
        {
            Debug.Log("[SQL_LoadUsers.cs]Database users already loaded...");
        } 
    }
}
