using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

/*
This class is for managing the game settings on startup.
It is in charge of initializing game setting values for the
whole game not making a reusable configuration file.
*/

public class InGameSettingsManager : MonoBehaviour {

    //Scripts
    private GameSettings gameSettings;

    //Option controls
    //Audio panel controls
    public Slider slider_music;
    public Slider slider_sfx;

    //Visual panel controls
    public Dropdown dropDown_resolution;
    public Dropdown dropDown_antiAlias;
    public Toggle toggle_bloom;
    public Toggle toggle_motionBlur;
    public Toggle toggle_vsync;

    //PostProcessing Stack Profile
    public PostProcessingProfile InGame;

    void OnEnable()
    {

    }
}
