using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector3 moveDirection;
    private float horizontal;
    private float vertical;

    private float cameraRotation;
    private float cameraTilt;

    private float lookX;
    private float lookY;

    public float sensitivityX;
    public float sensitivityY;
    
    public float minCameraTilt = -60f;
    public float maxCameraTilt = 60f;

    private CharacterController charController;

    private float gravity = -9.8f;
    private Vector3 playerVelocity;
    public float jumpHeight = 2.0f;
    
    public GameObject playerCamera;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //rotation
        lookX += cameraRotation * sensitivityX;
        transform.localEulerAngles = new Vector3(0, lookX, 0);
        
        //movement
        charController.Move(transform.right * horizontal * moveSpeed * Time.deltaTime
                            + transform.forward * vertical * moveSpeed * Time.deltaTime
                            + gravity * transform.up * Time.deltaTime);
        
        if (jumpHeight > gravity)
        {
            jumpHeight += gravity * Time.deltaTime;
        }


        lookY -= cameraTilt * sensitivityY;
        lookY = Mathf.Clamp(lookY/* - rotate.y*/, minCameraTilt, maxCameraTilt);
        playerCamera.transform.localEulerAngles = new Vector3(lookY, 0, 0);

    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
        //Debug.Log($"Player Controller: Left Stick Input: {vertical}, {horizontal}");
    }

    public void OnRotateInput(float cameraRotation, float cameraTilt)
    {
        this.cameraRotation = cameraRotation;
        this.cameraTilt = cameraTilt;
        //Debug.Log($"Player Controller: Right Stick Input: {vertical}, {horizontal}");
    }

    public void OnJumpInput()
    {
        Debug.Log("Jump?");
        jumpHeight = 5.0f;
        moveDirection = new Vector3(0, 0 + jumpHeight,0);
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
