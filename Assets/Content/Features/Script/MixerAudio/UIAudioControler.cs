using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System;

public class UIAudioControler : MonoBehaviour
{
    private const int MAX_VOLUME = 20;
    private const int MIN_VOLUME = -80;
    private const string SAVE_FILE_NAME = "VolumeData.json";
    
    private static readonly System.Collections.Generic.Dictionary<string, string> VolumeParameters = new System.Collections.Generic.Dictionary<string, string>
    {
        { "Master", "MasterVolume" },
        { "SFX", "SFXVolume" },
        { "Music", "MusicVolume" },
        { "Menu", "MenuVolume" }
    };

    [SerializeField] private Slider SliderMaster;
    [SerializeField] private Slider SliderSFX;
    [SerializeField] private Slider SliderMusic;
    [SerializeField] private Slider SliderMenu;

    [SerializeField] private AudioMixer _mixer;

    private VolumeData _volume;
    private string _savePath;

    private void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
        
        LoadData();
        ApplyVolumeToMixer();
        SetupSliders();
        AddSliderListeners();
    }

    private void SetupSliders()
    {
        SetupSlider(SliderMaster, _volume.Master);
        SetupSlider(SliderSFX, _volume.SFX);
        SetupSlider(SliderMusic, _volume.Music);
        SetupSlider(SliderMenu, _volume.Menu);
    }
    
    private void SetupSlider(Slider slider, float value)
    {
        slider.minValue = MIN_VOLUME;
        slider.maxValue = MAX_VOLUME;
        slider.value = value;
    }

    private void AddSliderListeners()
    {
        SliderMaster.onValueChanged.AddListener(value => ChangeVolume("Master", value));
        SliderSFX.onValueChanged.AddListener(value => ChangeVolume("SFX", value));
        SliderMusic.onValueChanged.AddListener(value => ChangeVolume("Music", value));
        SliderMenu.onValueChanged.AddListener(value => ChangeVolume("Menu", value));
    }
    
    private void ApplyVolumeToMixer()
    {
        _mixer.SetFloat(VolumeParameters["Master"], _volume.Master);
        _mixer.SetFloat(VolumeParameters["SFX"], _volume.SFX);
        _mixer.SetFloat(VolumeParameters["Music"], _volume.Music);
        _mixer.SetFloat(VolumeParameters["Menu"], _volume.Menu);
    }

    public void ChangeVolume(string type, float value)
    {
        if (!VolumeParameters.ContainsKey(type)) return;

        _mixer.SetFloat(VolumeParameters[type], value);

        switch (type)
        {
            case "Master": _volume.Master = value; break;
            case "SFX": _volume.SFX = value; break;
            case "Music": _volume.Music = value; break;
            case "Menu": _volume.Menu = value; break;
        }

        SaveData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_volume, true);
        File.WriteAllText(_savePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            _volume = JsonUtility.FromJson<VolumeData>(json);
            
            if (_volume == null)
            {
                CreateDefaultVolumeData();
            }
        }
        else
        {
            CreateDefaultVolumeData();
        }
    }

    private void CreateDefaultVolumeData()
    {
        _volume = new VolumeData
        {
            Master = MAX_VOLUME,
            SFX = MAX_VOLUME,
            Music = MAX_VOLUME,
            Menu = MAX_VOLUME
        };
    }
}

[Serializable]
public class VolumeData
{
    public float Master;
    public float SFX;
    public float Music;
    public float Menu;
}