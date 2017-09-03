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
    //public GameObject panel_Options;

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
    public Toggle toggle_ambOcclusion;

    //PostProcessing Stack Profile
    public PostProcessingProfile InGame;
    public PostProcessingProfile ui;

    private void Awake()
    {
        gameSettings = new GameSettingsHandler();

        LoadSettings(); 
    }

    //Config controls
    public void OnToggleMotionBlur(bool enabled)
    {
        gameSettings.motionBlur = enabled;
    }

    public void OnToggleBloom(bool enabled)
    {
        gameSettings.bloom = enabled;
    }

    public void OnToggleAmbientOcclussion(bool enabled)
    {
        gameSettings.ambientOcclusion = enabled;
    }

    public void OnClickApply()
    {
        string jsonData = JsonUtility.ToJson(gameSettings,true);
        File.WriteAllText(Application.persistentDataPath + "/config.json",jsonData);

        Settings();
    }

    void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettingsHandler>(File.ReadAllText(Application.persistentDataPath + "/config.json"));

        Settings();
    }

    void Settings()
    {
        //ui
        ui.motionBlur.enabled = toggle_motionBlur.isOn = gameSettings.motionBlur;
        ui.bloom.enabled = toggle_bloom.isOn = gameSettings.bloom;
        ui.ambientOcclusion.enabled = toggle_ambOcclusion.isOn = gameSettings.ambientOcclusion;

        //ingame
        InGame.motionBlur.enabled = toggle_motionBlur.isOn = gameSettings.motionBlur;
        InGame.bloom.enabled = toggle_bloom.isOn = gameSettings.bloom;
        InGame.ambientOcclusion.enabled = toggle_ambOcclusion.isOn = gameSettings.ambientOcclusion;
    }
}
