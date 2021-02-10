using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    public float xRot = 0f;
    public float yRot = 0f;

    private float cameraRotation;
    private float cameraTilt;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    public void OnRotateInput(float cameraRotation, float cameraTilt)
    {
        this.cameraRotation = cameraRotation;
        this.cameraTilt = cameraTilt;
        //Debug.Log($"Player Controller: Right Stick Input: {vertical}, {horizontal}");
    }

    // Update is called once per frame
    void Update()
    {

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;



        xRot -= cameraTilt;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        yRot += cameraRotation;
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * cameraRotation);
        playerBody.localRotation = Quaternion.Euler(0f, yRot, 0f);
    }

 
}
