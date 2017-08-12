using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {


    //UI controls/GameObjects
    public GameObject quitMenu;
    public GameObject mainButtons;
    public GameObject mapSelect;
    public GameObject shipSelection;


    //Audio
    public AudioClip clickConfirm;
    public AudioClip clickSpecial;
    public AudioClip clickCancel;
    public AudioClip clickSelection;

    public AudioSource audioSource;

    void Start () {

        //Refferences
        quitMenu.GetComponent<GameObject>();
        mainButtons.GetComponent<GameObject>();
        mapSelect.GetComponent<GameObject>();
        shipSelection.GetComponent<GameObject>();

        //Audio
        audioSource = GetComponent<AudioSource>();

        //Default States
        quitMenu.SetActive(false);
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
}
