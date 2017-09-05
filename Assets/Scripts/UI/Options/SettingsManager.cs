using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class SettingsManager : MonoBehaviour {

    private GameSettingsHandler gamesettings;

    public Toggle ambient_toggle;
    public Toggle motionBlur_toggle;
    public Toggle bloom_toggle;

    public Dropdown dropdown_shadowQuality;
    public Dropdown dropdown_Resolution;

    public PostProcessingProfile post_inGame;
    public PostProcessingProfile post_ui;


    //vars
    public int index_resolution;

    //properties
    Resolution[] resolutions;

    private void Awake()
    {
        gamesettings = new GameSettingsHandler();

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            dropdown_Resolution.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        //Load the settings
        Load_Settings();
    }

    public void OnToggle_Resolution(int index)
    {
        index_resolution = index;
        gamesettings.resolution_index = index_resolution;
    }

    public void OnToggle_ShadowQuality(int quality)
    {
        gamesettings.shadow_quality = quality;
    }

    public void OnToggle_AmbientOclussion(bool enabled)
    {
        gamesettings.ambientOcclusion = enabled;
    }

    public void OnToggle_MotionBlur(bool enabled)
    {
        gamesettings.motionBlur = enabled;
    }

    public void OnToggle_Bloom(bool enabled)
    {
        gamesettings.bloom = enabled;
    }

    public void OnClick_Apply()
    {
        string apply_config = JsonUtility.ToJson(gamesettings,true);
        File.WriteAllText(Application.persistentDataPath + "/config.json",apply_config);

        SettingsPreset();
    }

    public void Load_Settings()
    {
        gamesettings = JsonUtility.FromJson<GameSettingsHandler>(File.ReadAllText(Application.persistentDataPath + "/config.json"));
        SettingsPreset();
    }

    void SettingsPreset()
    {
        var shadowlevel = gamesettings.shadow_quality;
        dropdown_shadowQuality.value = shadowlevel;

        dropdown_Resolution.value =  index_resolution = gamesettings.resolution_index;
        Screen.SetResolution(resolutions[index_resolution].width,resolutions[index_resolution].height,true,60);

        //Global
        ShadowLevel(shadowlevel);

        //In Game
        post_inGame.ambientOcclusion.enabled = ambient_toggle.isOn = gamesettings.ambientOcclusion;
        post_inGame.motionBlur.enabled = motionBlur_toggle.isOn = gamesettings.motionBlur;
        post_inGame.bloom.enabled = bloom_toggle.isOn = gamesettings.bloom;

        //UI
        post_ui.ambientOcclusion.enabled = ambient_toggle.isOn = gamesettings.ambientOcclusion;
        post_ui.motionBlur.enabled = motionBlur_toggle.isOn = gamesettings.motionBlur;
        post_ui.bloom.enabled = bloom_toggle.isOn = gamesettings.bloom;
    }

    void ShadowLevel(int quality)
    {
        switch (quality)
        {
            case 0:
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
        }
    }

}