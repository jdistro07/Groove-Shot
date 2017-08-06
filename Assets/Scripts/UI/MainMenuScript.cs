using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public GameObject quitMenu;
    public GameObject mainButtons;
    public GameObject mapSelect;

    void Start () {
        quitMenu.GetComponent<GameObject>();
        mainButtons.GetComponent<GameObject>();
        mapSelect.GetComponent<GameObject>();

        //Default States
        quitMenu.SetActive(false);
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

    //Functions
    public void ConfirmQuit()
    {
        Application.Quit();
    }
}
