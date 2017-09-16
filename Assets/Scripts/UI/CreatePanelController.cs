using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePanelController : MonoBehaviour {

    public GameObject MainButtons;
    public GameObject profile_panel;

    private void OnEnable()
    {
        MainButtons.SetActive(false);
        profile_panel.SetActive(false);
    }

    private void OnDisable()
    {
        MainButtons.SetActive(true);
        profile_panel.SetActive(true);
    }

    public void OnClick_Close()
    {
        this.gameObject.SetActive(false);
    }
}
