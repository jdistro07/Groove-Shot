using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using System.IO;

/*
This class is for managing the game settings on startup.
It is in charge of initializing game setting values for the
whole game not making a reusable configuration file.
*/

public class OptionsManager : MonoBehaviour {

    //Panel Controls
    public GameObject panel_Options;

    //Scripts
    private GameSettingsHandler gameSettings;

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

    private void Awake()
    {
        gameSettings = new GameSettingsHandler();

        LoadSettings(); 
    }

    public void OnToggleMotionBlur(bool enabled)
    {
        gameSettings.motionBlur = enabled;
    }

    public void OnClickApply()
    {
        string jsonData = JsonUtility.ToJson(gameSettings,true);
        File.WriteAllText(Application.persistentDataPath + "/config.json",jsonData);
    }

    void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettingsHandler>(File.ReadAllText(Application.persistentDataPath + "/config.json"));

        toggle_motionBlur.isOn = gameSettings.motionBlur;
    }
}
