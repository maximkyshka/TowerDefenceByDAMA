using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;

public class UIAudioControler : MonoBehaviour
{
    [SerializeField] private Slider SliderMaster;
    [SerializeField] private Slider SliderSFX;
    [SerializeField] private Slider SliderMusic;
    [SerializeField] private Slider SliderMenu;
    
    [SerializeField] private AudioMixer _mixer;

    private float[] _volume;

    private void Awake()
    {
        LoadData();
        
        SliderMaster.value = _volume[0];
        SliderSFX.value = _volume[1];
        SliderMusic.value = _volume[2];
        SliderMenu.value = _volume[3];
        
        InvokeRepeating(nameof(ReLoadAudio), 0, 0.2f);
    }

    void ReLoadAudio()
    {
        _volume[0] = SliderMaster.value;
        _volume[1] = SliderSFX.value;
        _volume[2] = SliderMusic.value;
        _volume[3] = SliderMenu.value;
        
        _mixer.SetFloat("MasterVolume", _volume[0]);
        _mixer.SetFloat("SFXVolume", _volume[1]);
        _mixer.SetFloat("MusicVolume", _volume[2]);
        _mixer.SetFloat("MenuVolume", _volume[3]);
        
        SaveData();
    }
    
    public void SaveData()
    {
        string json = JsonUtility.ToJson(_volume);
        Debug.Log(json);

        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveVolumeData.json"))
        {
            writer.Write(json);
        }
    }

    public void LoadData()
    {
        string json = string.Empty;

        using(StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveVolumeData.json"))
        {
            json = reader.ReadToEnd();
        }

        float[] data = JsonUtility.FromJson<float[]>(json);
        _volume = data;
    }
}
