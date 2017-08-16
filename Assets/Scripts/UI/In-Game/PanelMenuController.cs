using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenuController : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject hud;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(false);
            hud.SetActive(true);
        }
    }

    //When resume is clicked
    public void onClickResume()
    {
        pausePanel.SetActive(false);
        hud.SetActive(true);
    }
}
