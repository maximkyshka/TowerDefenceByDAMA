using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIAudioControler : MonoBehaviour
{
    [SerializeField] private Slider SliderMaster;
    [SerializeField] private Slider SliderSFX;
    [SerializeField] private Slider SliderMusic;
    [SerializeField] private Slider SliderMenu;
    
    [SerializeField] private AudioMixer _mixer;
    
    void Update()
    {
        _mixer.SetFloat("MasterVolume", SliderMaster.value);
        _mixer.SetFloat("SFXVolume", SliderSFX.value);
        _mixer.SetFloat("MusicVolume", SliderMusic.value);
        _mixer.SetFloat("MenuVolume", SliderMenu.value);
    }
}
