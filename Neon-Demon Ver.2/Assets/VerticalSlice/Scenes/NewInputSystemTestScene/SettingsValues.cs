using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsValues : MonoBehaviour
{
    public float sensitivity;

    public Slider sensitivitySlider;
    void Start()
    {
        sensitivity = sensitivitySlider.value * 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("aimSensitivity", sensitivity);
    }
    
    public void ChangeSensitivity()
    {
        sensitivity = sensitivitySlider.value * 20;
        SaveData();
    }
}
