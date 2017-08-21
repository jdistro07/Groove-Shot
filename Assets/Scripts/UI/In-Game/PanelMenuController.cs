using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenuController : MonoBehaviour {

    //cursor
    public Texture2D combatCursor;

    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    public GameObject pausePanel;
    public GameObject hud;

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
