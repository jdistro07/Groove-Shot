using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePanelController : MonoBehaviour {

    public GameObject Main_Buttons;
    public GameObject ProfilePanel;

    private void OnEnable()
    {
        Main_Buttons.SetActive(false);
        ProfilePanel.SetActive(false);
    }

    private void OnDisable()
    {
        Main_Buttons.SetActive(true);
        ProfilePanel.SetActive(true);
    }

    void OnClick_Close()
    {
        this.gameObject.SetActive(false);
    }
}