using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBInsertScore : MonoBehaviour
{
	string insertScoreLink = "http://localhost/GrooveShotDB/score.php";

	public Button backButton;
	public Text scoreText;

	void Start()
	{
		Button btn = backButton.GetComponent<Button> ();
		Text scoretxt = scoreText.GetComponent<Text> ();
		btn.onClick.AddListener (scoreInsert);
	}

	public void scoreInsert()
	{
		string username = "dummy";
		string score = scoreText.text;

		WWWForm form = new WWWForm ();
		form.AddField ("usernameHere", username);
		form.AddField ("scoreHere", score);

		WWW www = new WWW (insertScoreLink, form);
	}
}
