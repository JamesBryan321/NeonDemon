using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform playerBody;
    private float sensitivity = 100f;
    public float xRot = 0f;
    public float yRot = 0f;

    private float cameraRotation;
    private float cameraTilt;

    public InputController inputScript;
    public float controllerSensitivity;
    public float mouseSensitivity;
    
    void Start()
    {
        Cursor.visible = false;
        if (inputScript.useController)
        {
            sensitivity = controllerSensitivity;
        }

        if (inputScript.useKeyboard)
        {
            sensitivity = mouseSensitivity;
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
        playerBody.localRotation = Quaternion.Euler(0f, yRot, 0f);
    }

 
}
