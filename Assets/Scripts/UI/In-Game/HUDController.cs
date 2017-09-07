using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Text dispHP;

    void Start()
    {
        HUDTracker();
    }

	void Awake()
	{
		score = 0;
	}

    // Update is called once per frame
    void Update () {
        HUDTracker();
    }

    void HUDTracker()
    {
        bool debugged = false;
        try
        {
            debugged = true;
            var hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            dispHP.text = hp.health.ToString();

			dispScore.text = score.ToString();
        }
        catch(NullReferenceException nre)
        {
            dispHP.text = "0";
			dispScore.text = "0";
            Debug.Log("[HUDController] Finding Player: "+nre);
        }
    }

	//Lines of Codes beyond this point is contributed by Lance
	public static int score;

	public Text dispScore;

}
