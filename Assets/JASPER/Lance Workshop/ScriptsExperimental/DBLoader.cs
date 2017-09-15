using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBLoader : MonoBehaviour
{
	public string[] users;

	IEnumerator Start()
	{
		WWW username = new WWW ("http://localhost/GrooveShotDB/getusers.php");
		yield return username;
		string userData = username.text;
		users = userData.Split(';');
		print (GetUsername(users[0], "Username: "));
	}

	string GetUsername(string name, string index)
	{
		string username = name.Substring(name.IndexOf(index)+index.Length);
		return username;
	}
}
