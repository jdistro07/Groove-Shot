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

    //index variables
    public int indexAA;
    public int indexRes;
    public Resolution[] resolutions;
    public Screen screen;

    private void Awake()
    {
        gameSettings = new GameSettingsHandler();
        if (!File.Exists(Application.persistentDataPath + "/config.json"))
        {
            File.Create(Application.persistentDataPath + "/config.json");
        }
    }

    private void Start()
    {
        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            dropDown_resolution.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void ResolutionChange(int index)
    {
        indexRes = index;
        gameSettings.resolution_index = indexRes;
    }

    //Config controls
    public void OnToggleMotionBlur(bool enabled)
    {
        gameSettings.motionBlur = enabled;
    }

    public void alias(int index)
    {
        indexAA = index;
        gameSettings.antiAlias_index = indexAA;
        Debug.Log(gameSettings.antiAlias_index);
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

        if (!File.Exists(Application.persistentDataPath + "/config.json"))
        {
            File.Create(Application.persistentDataPath + "/config.json");
            File.WriteAllText(Application.persistentDataPath + "/config.json", jsonData);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + "/config.json", jsonData);
        }

        Settings();
    }

    void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettingsHandler>(File.ReadAllText(Application.persistentDataPath + "/config.json"));
        Settings();
    }

    void Settings()
    {
        //global
        dropDown_resolution.value = indexRes = gameSettings.resolution_index;
        Screen.SetResolution(resolutions[indexRes].width,resolutions[indexRes].height,true,60);

        //AA
        indexAA = dropDown_antiAlias.value = gameSettings.antiAlias_index;
        AntiAliasLevel(indexAA);

        //ui
        ui.motionBlur.enabled = toggle_motionBlur.isOn = gameSettings.motionBlur;
        ui.bloom.enabled = toggle_bloom.isOn = gameSettings.bloom;
        ui.ambientOcclusion.enabled = toggle_ambOcclusion.isOn = gameSettings.ambientOcclusion;
        
        //ingame
        InGame.motionBlur.enabled = toggle_motionBlur.isOn = gameSettings.motionBlur;
        InGame.bloom.enabled = toggle_bloom.isOn = gameSettings.bloom;
        InGame.ambientOcclusion.enabled = toggle_ambOcclusion.isOn = gameSettings.ambientOcclusion;
    }

    void AntiAliasLevel(int index)
    {
        var uiAA = ui.antialiasing.settings;
        var InGameAA = InGame.antialiasing.settings.method;
        var fxaa = AntialiasingModel.Method.Fxaa;
        var taa = AntialiasingModel.Method.Taa;

        switch (index)
        {
            case 0:
                InGame.antialiasing.enabled = false;
                ui.antialiasing.enabled = false;
                break;
            case 1:
                InGame.antialiasing.enabled = true;
                ui.antialiasing.enabled = true;

                uiAA.method = taa;
                break;
        }
    }
}
