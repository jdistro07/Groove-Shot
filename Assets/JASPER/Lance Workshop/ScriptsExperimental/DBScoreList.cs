using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBScoreList : MonoBehaviour
{
	public string[] scorelist;

	IEnumerator Start()
	{
		WWW scores = new WWW ("http://localhost/GrooveShotDB/scorelist.php");
		yield return scores;
		string score = scores.text;
		scorelist = score.Split (';');

		print (scorelist[0]);
	}
}
