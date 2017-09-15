using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBNewUser : MonoBehaviour
{
	string addUsersLink = "http://localhost/GrooveShotDB/addusers.php";

	public Button createButton;
	public InputField usernameInput;

	void Start()
	{
		Button btn = createButton.GetComponent<Button> ();
		InputField inp = usernameInput.GetComponent<InputField> ();
		btn.onClick.AddListener (CreateUser);
	}

	void TaskOnClick()
	{
		CreateUser ();
	}

	public void CreateUser()
	{
		string username = usernameInput.text;

		if (usernameInput.text != "")
		{
			WWWForm form = new WWWForm ();
			form.AddField ("usernamePost", username);

			WWW www = new WWW (addUsersLink, form);
		}
		else
		{
			usernameInput.text = "";
			usernameInput.placeholder.GetComponent<Text> ().text = "No null usernames";
		}
	}
}
