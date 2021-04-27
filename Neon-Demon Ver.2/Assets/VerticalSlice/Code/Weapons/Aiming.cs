using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour
{
    public Transform playerBody;
    [SerializeField] private float sensitivity = 100f;
    public float xRot = 0f;
    public float yRot = 0f;

    private float cameraRotation;
    private float cameraTilt;

    public InputController inputScript;
    public float controllerSensitivity;
    public float mouseSensitivity;

    public Slider sensitivitySlider;

    public bool useController, useKeyboard;
    public bool lockPlayerRotation;

    public SettingsValues settingsValueScript;

    //public SettingsValues settingsScript;
    
    void Start()
    {
        Cursor.visible = false;
        if (useController)
        {
            //sensitivity = controllerSensitivity;
            sensitivity = settingsValueScript.currentSensitivity;
            /*
            sensitivitySlider.value = controllerSensitivity / 20;
            sensitivitySlider.maxValue = 20;
            sensitivitySlider.minValue = 1;
            */
        }

        if (useKeyboard)
        {
            //sensitivity = mouseSensitivity;
            sensitivity = settingsValueScript.currentSensitivity;
            /*
            sensitivitySlider.value = mouseSensitivity / 20;
            sensitivitySlider.maxValue = 0.5f;
            sensitivitySlider.minValue = .05f;
            */
        }
        //Debug.Log("Camera sensitivity is set to: " + sensitivity);
    }

    public void OnRotateInput(float cameraRotation, float cameraTilt)
    {
        this.cameraRotation = cameraRotation;
        this.cameraTilt = cameraTilt;
        //Debug.Log($"Player Controller: Right Stick Input: {vertical}, {horizontal}");
    }

    void Update()
    {
        xRot -= cameraTilt * sensitivity * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        yRot += cameraRotation * sensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * cameraRotation);
        if (lockPlayerRotation == false)
        {
            playerBody.localRotation = Quaternion.Euler(0f, yRot, 0f);
        }
    }

    public void ChangeSensitivity()
    {
        sensitivity = settingsValueScript.currentSensitivity;
    }
    
    

}
