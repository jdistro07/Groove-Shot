using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileListController : MonoBehaviour {

    public GameObject mainButtons;

    private void OnEnable()
    {
        mainButtons.SetActive(false);
    }

    private void OnDisable()
    {
        mainButtons.SetActive(true);
    }

    public void OnClick_Close()
    {
        this.gameObject.SetActive(false);
    }

}
