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
    public AudioMixerGroup musicMixer;
    public AudioMixerGroup soundFXMixer;
    public AudioMixerGroup dialogueMixer;

    public float currentVolume, currentMusicVol, currentFXVol, currentDialogueVol, currentSensitivity;
    
    
    
    void Start()
    {
        GetSettingsInfo();
        masterVolumeSlider.value = currentVolume / 5;
        musicVolumeSlider.value = currentMusicVol / 5;
        soundFXVolumeSlider.value = currentFXVol / 5;
        dialogueVolumeSlider.value = currentDialogueVol / 5;
        sensitivitySlider.value = currentSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSettingsInfo()
    {
        currentVolume = PlayerPrefs.GetFloat("masterVolume");
        currentMusicVol = PlayerPrefs.GetFloat("musicVolume");
        currentFXVol = PlayerPrefs.GetFloat("soundFXVolume");
        currentDialogueVol = PlayerPrefs.GetFloat("dialogueVolume");
        currentSensitivity = PlayerPrefs.GetFloat("aimSensitivity");
    }

    public void SaveSensitivityData()
    {
        PlayerPrefs.SetFloat("aimSensitivity", currentSensitivity);
    }

    public void SaveVolumeData()
    {
        PlayerPrefs.SetFloat("masterVolume", masterVolumeSlider.value * 5);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value * 5);
        PlayerPrefs.SetFloat("soundFXVolume", soundFXVolumeSlider.value * 5);
        PlayerPrefs.SetFloat("dialogueVolume", dialogueVolumeSlider.value * 5);
        //Debug.Log("Master Volume:" + masterVolumeSlider.value);
        Debug.Log("Master Volume:" + masterVolumeSlider.value  * 5 + " Music Volume:" + musicVolumeSlider.value  * 5
                            + " SoundFX Volume:" + soundFXVolumeSlider.value  * 5 + " Dialogue Volume:" + dialogueVolumeSlider.value  * 5);
    }
    
    public void ChangeSensitivity()
    {
        currentSensitivity = sensitivitySlider.value * 20;
        SaveSensitivityData();
    }

    public void ChangeVolume()
    {
        masterMixer.SetFloat("MasterVolume", masterVolumeSlider.value * 5);
        musicMixer.audioMixer.SetFloat("MusicVolume", musicVolumeSlider.value * 5);
        soundFXMixer.audioMixer.SetFloat("SoundFXVolume", soundFXVolumeSlider.value * 5);
        dialogueMixer.audioMixer.SetFloat("DialogueVolume", dialogueVolumeSlider.value * 5);
        SaveVolumeData();
    }
    
    public void ChangeMusicVolume()
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", musicVolumeSlider.value * 5);
        
    }
    
    public void ChangeSoundFXVolume()
    {
        soundFXMixer.audioMixer.SetFloat("SoundFXVolume", soundFXVolumeSlider.value * 5);
    }
    
    public void ChangeDialogueVolume()
    {
        dialogueMixer.audioMixer.SetFloat("DialogueVolume", dialogueVolumeSlider.value * 5);
    }
}
