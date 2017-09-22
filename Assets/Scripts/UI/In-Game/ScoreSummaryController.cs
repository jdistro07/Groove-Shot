using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummaryController : MonoBehaviour {

    [Header("UI OBJECTS")]
    public Text txt_score;

    public GameObject pausePanel;
    public GameObject pausePanel_Menu;
    public GameObject hud;

    [Header("AI")]
    public GameObject[] ai;
    public GameObject[] ai_turret;
    public GameObject[] ai_destroyed;

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

        try
        {
            //Disable AI if found
            ai = GameObject.FindGameObjectsWithTag("AI");
            ai_turret = GameObject.FindGameObjectsWithTag("AITurret");

            foreach (GameObject aiChase in ai)
            {
                var chase = aiChase.GetComponent<AIChase>();
                chase.enabled = false;
            }

            foreach (GameObject turret in ai_turret)
            {
                var shoot = turret.GetComponent<AIShoot>();
                shoot.enabled = false;
            }
        }
        catch
        {
            Debug.Log("[ScoreSummary] No AI Found!");
        }

        //GUI component controls
        txt_score.text = HUDController.score.ToString();
    }

    private void Update()
    {
        try
        {
            ai_destroyed = GameObject.FindGameObjectsWithTag("AIDestroyed");

            foreach (GameObject _ai_destroyed in ai_destroyed)
            {
                var destroyed_obj = _ai_destroyed.GetComponent<destroyed>();
                destroyed_obj.enabled = false;
            }
        }
        catch
        {
            Debug.Log("[ScoreSummary] No AIDestroyed Found!");
        }
    }

}
