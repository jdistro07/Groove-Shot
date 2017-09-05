using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    private GameSettingsHandler gamesettings;

    public Toggle ambient_toggle;

    private void Awake()
    {
        gamesettings = new GameSettingsHandler();
        Load_Settings();
    }

    public void OnToggle_AmbientOclussion(bool enabled)
    {
        gamesettings.ambientOcclusion = enabled;
        Debug.Log("Ambient Occlusion: " + enabled);
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
        ambient_toggle.isOn = gamesettings.ambientOcclusion;
    }

}
