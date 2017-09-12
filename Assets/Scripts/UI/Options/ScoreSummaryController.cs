using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummaryController : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject pausePanel_Menu;
    public GameObject hud;

    private void OnEnable()
    {
        pausePanel.SetActive(true); //Enable pause BG
        if (pausePanel_Menu.activeInHierarchy) // If pause menu is active on the scene, disable it.
        {
            /*
             other redundant controls for display must
             be disabled here.
             */

            hud.SetActive(false); //HUD
            pausePanel_Menu.SetActive(false); // pause menu
        }
    }

}
