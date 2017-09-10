using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenuController : MonoBehaviour {

    //cursor
    public Texture2D combatCursor;

    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    //ui Game Objects
    public GameObject pausePanel;
    public GameObject hud;
    public GameObject confirmation;
    public GameObject pausePanelMenu;
    public GameObject options;

    void OnEnable()
    {
        Cursor.SetCursor(null,hotSpot,cursorMode);
    }

    void OnDisable()
    {
        Cursor.SetCursor(combatCursor, hotSpot, cursorMode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!options.activeInHierarchy)
            {
                pausePanel.SetActive(false);
                hud.SetActive(true);
            }
            else if (options.activeInHierarchy)
            {
                options.SetActive(false);
                pausePanelMenu.SetActive(true);
            }
        }
    }

    //When resume is clicked
    public void onClickResume()
    {
        pausePanel.SetActive(false);
        hud.SetActive(true);
    }

    public void OnClickLeaveGame()
    {
        confirmation.SetActive(true);
        pausePanelMenu.SetActive(false);
    }

    public void OnClickCancel()
    {
        confirmation.SetActive(false);
        pausePanelMenu.SetActive(true);
    }

    public void OnClickOptions()
    {
        options.SetActive(true);
        pausePanelMenu.SetActive(false);
    }

    public void OnCloseOptions()
    {
        options.SetActive(false);
        pausePanelMenu.SetActive(true);
    }
}
