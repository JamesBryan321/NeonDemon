﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuCamera : MonoBehaviour
{
    public List<Transform> CameraPositions;

    private Transform Temp;
   public int CurrentCamera;
    
    public GameObject mainMenuFirstButton, settingsFirstButton, creditsFirstButton, settingsFirstB;
    public GameObject sensitivityPanel, audioPanel, audioFirstButton, sensitivityFirstButton;
    
    // Start is called before the first frame update
    void Start()
    {
        Temp = this.transform;
      
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CameraPositions[CurrentCamera].position, 4.0f * Time.deltaTime);
        //transform.rotation = CameraPositions[CurrentCamera].rotation;
        transform.rotation = Quaternion.RotateTowards(Temp.rotation, CameraPositions[CurrentCamera].rotation, 80f * Time.deltaTime);
    }

    public void Move0()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 0;
        SelectMainMenu();
    }


    public void Move1()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 1;
        SelectSettingsMenu();
    }

    public void Move2()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 2;
        SelectCreditsMenu();
    }
    public void Move3()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 3;
        SelectGameSettingsMenu();
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/NeonDemonGame");
    }

    public void SelectMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }
    
    public void SelectSettingsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }
    
    public void SelectCreditsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }

    public void SelectGameSettingsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstB);
    }
    public void camerachangeUp()
    {
        CurrentCamera = CurrentCamera + 1;
    }
    public void camerachangeDown()
    {
        CurrentCamera = CurrentCamera - 1;

    }

    public void EditAudioSettings()
    {
        audioPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioFirstButton);
    }

    public void EditSensitivitySettings()
    {
        sensitivityPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(sensitivityFirstButton);
    }

    public void CloseAudioSettings()
    {
        audioPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstB);
    }

    public void CloseSensitivitySettings()
    {
        sensitivityPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstB);
    }
}