using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxClicks : MonoBehaviour {
    public AudioClip clickSpecial;
    public AudioClip clickCancel;
    public AudioClip clickConfirm;
    public AudioClip clickSelect;

    public AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void SpecialClick()
    {
        source.PlayOneShot(clickSpecial);
    }

    public void CancelClick()
    {
        source.PlayOneShot(clickCancel);
    }

    public void ConfirmClick()
    {
        source.PlayOneShot(clickConfirm);
    }

    public void ClickSelect()
    {
        source.PlayOneShot(clickSelect);
    }
}
