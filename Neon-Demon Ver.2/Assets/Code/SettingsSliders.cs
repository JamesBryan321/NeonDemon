using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRuby.SimpleLUT;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSliders : MonoBehaviour
{
    public Slider brightnessSlider;
    public SimpleLUT brightnessScript;

    public float defaultBrightnessValue = 1;
    void Start()
    {
        brightnessSlider.value = defaultBrightnessValue;
    }

    private void OnGUI()
    {
        //defaultBrightnessValue = brightnessSlider();
        
    }

    // Update is called once per frame
    void Update()
    {
        brightnessScript.Brightness = brightnessSlider.value;
    }
}
