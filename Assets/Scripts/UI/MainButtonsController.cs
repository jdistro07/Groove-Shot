using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonsController : MonoBehaviour {

    public GameObject profile_panel;

    private void OnEnable()
    {
        profile_panel.SetActive(true);
    }

    private void OnDisable()
    {
        profile_panel.SetActive(false);
    }
}
