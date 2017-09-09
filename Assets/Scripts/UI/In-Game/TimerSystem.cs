using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

    float time = 0f;
    float seconds = 0f;
    float minutes = 0f;

    public float DesiredMinutes;

    public Text uiTxt;
    public GameObject scorePanel;

    private void Awake()
    {
        scorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;

        if (minutes < DesiredMinutes)
        {
            seconds = (int)Mathf.FloorToInt(time % 60);
            minutes = (int)Mathf.FloorToInt(time / 60) % 60;
        }
        else if (minutes == DesiredMinutes)
        {
            scorePanel.SetActive(true);

            seconds = 0;
            minutes = DesiredMinutes;
        }

        string format = string.Format("{0:00}:{1:00}",minutes,seconds);
        uiTxt.text = format;
	}
}
