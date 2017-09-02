using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuOverlayController : MonoBehaviour {

    //cursor
    public Texture2D combatCursor;

    private Vector2 hotSpot;
    private CursorMode cursorMode = CursorMode.Auto;

    //for pause
    public GameObject pausePanel;
    public GameObject hud;

    // Use this for initialization
    void Start () {
        pausePanel.SetActive(false);
        hud.SetActive(true);

        hotSpot = new Vector2(combatCursor.width/2,combatCursor.height/2);

        //cursor
        Cursor.SetCursor(combatCursor,hotSpot,cursorMode);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            hud.SetActive(false);
        }
    }
}
