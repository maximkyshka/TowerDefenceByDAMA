using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System;

    public class UIAudioControler : MonoBehaviour
    {
        const int MAX_VOLUME = 20;
        const int MIN_VOLUME = -80;
        
        [SerializeField] private Slider SliderMaster;
        [SerializeField] private Slider SliderSFX;
        [SerializeField] private Slider SliderMusic;
        [SerializeField] private Slider SliderMenu;

        [SerializeField] private AudioMixer _mixer;

        private VolumeData _volume;
        
        private void Awake()
        {
            LoadData();
            
            
            SliderMaster.minValue = MIN_VOLUME;
            SliderMaster.maxValue = MAX_VOLUME;
            
            SliderSFX.minValue = MIN_VOLUME;
            SliderSFX.maxValue = MAX_VOLUME;
            
            SliderMusic.minValue = MIN_VOLUME;
            SliderMusic.maxValue = MAX_VOLUME;
            
            SliderMenu.minValue = MIN_VOLUME;
            SliderMenu.maxValue = MAX_VOLUME;
            
            
            SliderMaster.value = _volume.Master;
            SliderSFX.value = _volume.SFX;
            SliderMusic.value = _volume.Music;
            SliderMenu.value = _volume.Menu;
            
            SliderMaster.onValueChanged.AddListener(ChangeVolumeMaster);
            SliderSFX.onValueChanged.AddListener(ChangeVolumeSFX);
            SliderMusic.onValueChanged.AddListener(ChangeVolumeMusic);
            SliderMenu.onValueChanged.AddListener(ChangeVolumeMenu);
        }

        public void ReLoadAudio()
        {
            _volume.Master = SliderMaster.value;
            _volume.SFX = SliderSFX.value;
            _volume.Music = SliderMusic.value;
            _volume.Menu = SliderMenu.value;

            _mixer.SetFloat("MasterVolume", _volume.Master);
            _mixer.SetFloat("SFXVolume", _volume.SFX);
            _mixer.SetFloat("MusicVolume", _volume.Music);
            _mixer.SetFloat("MenuVolume", _volume.Menu);

            SaveData();
        }

        public void ChangeVolumeMaster(float value)
        {
            _volume.Master = value;
            
            _mixer.SetFloat("MasterVolume", _volume.Master);
            
            SaveData();
        }
        
        public void ChangeVolumeSFX(float value)
        {
            _volume.SFX = value;
            
            _mixer.SetFloat("SFXVolume", _volume.SFX);
            
            SaveData();
        }
        public void ChangeVolumeMusic(float value)
        {
            _volume.Music = value;
            
            _mixer.SetFloat("MusicVolume", _volume.Music);
            
            SaveData();
        }
        
        
        public void ChangeVolumeMenu(float value)
        {
            _volume.Menu = value;
            
            _mixer.SetFloat("MenuVolume", _volume.Menu);
            
            SaveData();
        }
        

        public void SaveData()
        {
            string json = JsonUtility.ToJson(_volume);
            Debug.Log(json);

            using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveVolumeData.json"))
            {
                writer.Write(json);
            }
        }

        public void LoadData()
        {
            string json = string.Empty;

            using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveVolumeData.json"))
            {
                json = reader.ReadToEnd();
            }

            VolumeData data = JsonUtility.FromJson<VolumeData>(json);
            _volume = data;
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
