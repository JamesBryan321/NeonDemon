using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsValues : MonoBehaviour
{
    public float sensitivity;

    public Slider sensitivitySlider;
    
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider soundFXVolumeSlider;
    public Slider dialogueVolumeSlider;
    
    public AudioMixer masterMixer;
    public AudioMixer musicMixer;
    public AudioMixer soundFXMixer;
    public AudioMixer dialogueMixer;
    
    void Start()
    {
        sensitivity = sensitivitySlider.value * 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSensitivityData()
    {
        PlayerPrefs.SetFloat("aimSensitivity", sensitivity);
    }
    
    public void ChangeSensitivity()
    {
        sensitivity = sensitivitySlider.value * 20;
        SaveSensitivityData();
    }

    public void ChangeMasterVolume()
    {
        masterMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
    }
    
    public void ChangeMusicVolume()
    {
        musicMixer.SetFloat("MusicVolume", musicVolumeSlider.value);
    }
    
    public void ChangeSoundFXVolume()
    {
        soundFXMixer.SetFloat("SoundFXVolume", soundFXVolumeSlider.value);
    }
    
    public void ChangeDialogueVolume()
    {
        dialogueMixer.SetFloat("DialogueVolume", dialogueVolumeSlider.value);
    }
}
