using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanelController : MonoBehaviour {
    public AudioSource audio_source;

    public AudioClip select;
    public AudioClip special;
    public AudioClip confirm;
    public AudioClip cancel;

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void sfxCancel()
    {
        audio_source.PlayOneShot(cancel);
    }

    public void sfxConfirm()
    {
        audio_source.PlayOneShot(confirm);
    }

    public void sfxSelect()
    {
        audio_source.PlayOneShot(select);
    }
    public void sfxSpecial()
    {
        audio_source.PlayOneShot(special);
    }

}
