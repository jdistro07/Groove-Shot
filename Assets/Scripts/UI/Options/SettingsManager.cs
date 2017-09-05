﻿using System.Collections;
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

    public PostProcessingProfile post_inGame;
    public PostProcessingProfile post_ui;

    private void Awake()
    {
        gamesettings = new GameSettingsHandler();
        Load_Settings();
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
        //In Game
        post_inGame.ambientOcclusion.enabled = ambient_toggle.isOn = gamesettings.ambientOcclusion;
        post_inGame.motionBlur.enabled = motionBlur_toggle.isOn = gamesettings.motionBlur;
        post_inGame.bloom.enabled = bloom_toggle.isOn = gamesettings.bloom;

        //UI
        post_ui.ambientOcclusion.enabled = ambient_toggle.isOn = gamesettings.ambientOcclusion;
        post_ui.motionBlur.enabled = motionBlur_toggle.isOn = gamesettings.motionBlur;
        post_ui.bloom.enabled = bloom_toggle.isOn = gamesettings.bloom;
    }

}
