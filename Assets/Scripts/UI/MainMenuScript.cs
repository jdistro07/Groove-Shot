﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    //cursor
    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    //Scripts
    private uiIDCatcher id;

    //UI controls/GameObjects
    public GameObject quitMenu;
    public GameObject mainButtons;
    public GameObject mapSelect;
    public GameObject shipSelection;
    public GameObject panelOptions;
    public GameObject profile_Create;
    public GameObject profile_List;

    //Buttons
    public Button btnConfirm; //This control can be found on the MapSelection Panel


    //Audio
    public AudioClip clickConfirm;
    public AudioClip clickSpecial;
    public AudioClip clickCancel;
    public AudioClip clickSelection;

    public AudioSource audioSource;

    private void Awake()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    void Start () {
        id = GetComponent<uiIDCatcher>();
        
        //Referrences
        quitMenu.GetComponent<GameObject>();
        mainButtons.GetComponent<GameObject>();
        mapSelect.GetComponent<GameObject>();
        shipSelection.GetComponent<GameObject>();

        //Audio
        try
        {
            audioSource = GetComponent<AudioSource>();
        }
        catch
        {
            Debug.Log("[MainMenuScript.cs] Audio Source not found!");
        }
       

        //On start States
        quitMenu.SetActive(false);
        panelOptions.SetActive(false);

        //Button default states

        if(id.mapID.Length == 0)    //for button confirm (Select Map Panel) DISABLE
        {
            btnConfirm.interactable=false;
        }
	}

    //Frame by frame monitoring
    private void Update()
    {
        if (!(id.mapID.Length == 0))    //for button confirm (Select Map Panel) ENABLE
        {
            btnConfirm.interactable = true;
        }
        else
        {
            btnConfirm.interactable = false;
        }
    }

    public void OnClick_ProfileCreate()
    {
        profile_Create.SetActive(true);
    }

    public void OnClick_ProfileList()
    {
        profile_List.SetActive(true);
    }

    //Options
    public void ClickOptions()
    {
        panelOptions.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void ClickCloseOptions()
    {
        panelOptions.SetActive(false);
        mainButtons.SetActive(true);
    }

    //Sound Efects
    public void clkSelection()
    {
        audioSource.PlayOneShot(clickSelection);
    }

    public void ClkSpecial()
    {
        audioSource.PlayOneShot(clickSpecial);
    }

    public void ClkConfirm()
    {
        audioSource.PlayOneShot(clickConfirm);
    }

    public void ClkCancel()
    {
        audioSource.PlayOneShot(clickCancel);
    }

    //Single Player
    public void ClickSinglePlayer()
    {
        mapSelect.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void CloseMapSelect()
    {
        mapSelect.SetActive(false);
        mainButtons.SetActive(true);
    }

    //Map Selection
    public void confirmMapPress()
    {
        mapSelect.SetActive(false);
        shipSelection.SetActive(true);
    }

    //Exit Button
    public void onPressExit()
    {
        quitMenu.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void onClickCancel()
    {
        quitMenu.SetActive(false);
        mainButtons.SetActive(true);
    }

    //UI Functions
    public void ConfirmQuit()
    {
        Application.Quit();
    }

    //Ship Select
    public void quitShipSelection ()
    {
        shipSelection.SetActive(false);
        mapSelect.SetActive(true);
    }

    public void ClickPlay()
    {
        StartCoroutine(ClickPlayDelay());
    }

    //Coroutine for Play button
    private IEnumerator ClickPlayDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("LoadingScreen");
    }
}
