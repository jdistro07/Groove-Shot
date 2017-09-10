using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummaryController : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject pausePanel_Menu;
    public GameObject hud;
    public GameObject[] ai;
    public GameObject[] aiTurret;

    private void OnEnable()
    {
        //AI Components
        ai = GameObject.FindGameObjectsWithTag("AI"); // store every ai found with tag 'AI'
        aiTurret = GameObject.FindGameObjectsWithTag("AITurret"); // store every ai found with tag ''


        foreach (GameObject turret in aiTurret) //get components for each AI found
        {
            //refs
            var aiShoot = turret.GetComponent<AIShoot>();

            // disable scripts
            aiShoot.enabled = false;
        }

        foreach (GameObject _ai in ai) //get components for each AI found
        {
            //refs
            var aiChase = _ai.GetComponent<AIChase>();

            // disable scripts
            aiChase.enabled = false;
        }

        //Enable external panels
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
