using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuOverlayController : MonoBehaviour {

    //cursor
    public Texture2D combatCursor;

    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    //for pause
    public GameObject pausePanel;
    public GameObject hud;

    // Use this for initialization
    void Start () {
        pausePanel.SetActive(false);
        hud.SetActive(true);

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


    private void OnEnables()
    {
        var movement = GameObject.Find("Player").GetComponent<HoverControls>();
        Debug.Log("Enabled");
        movement.enabled = false;
    }

    private void OnDisables()
    {
        var movement = GameObject.Find("Player").GetComponent<HoverControls>();

        movement.enabled = true;
    }
}
