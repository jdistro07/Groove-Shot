using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuOverlayController : MonoBehaviour {

    //for pause
    public GameObject pausePanel;

    // Use this for initialization
    void Start () {
        pausePanel.SetActive(false);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
        }
    }
}
