﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxWallSpeed;
    public  bool isWallRight, isWallLeft;
    bool isWallRunning;
    public float maxWallRunCameraTilt, wallRunCameraTilt;
    public Transform orientation;

    public float speed;
    private Rigidbody playerRigidbody;

    public float sensitivity;
    public float ySensitivity;
    
    public GameObject playerCamera;
    public GameObject groundCheck;
    [SerializeField] private bool isGrounded;

    public Vector3 groundCheckBoxSize;

    public float jumpForce;
    [SerializeField] private float slideForce;

    private float cameraEulerAnglesX;

    private Vector2 xMovement;
    private Vector2 zMovement;

    private Vector3 defaultSize;
    [SerializeField] private Vector3 crouchSize;
    
    [SerializeField] public bool isJumping;
    [SerializeField] private bool secondJumpAvailable;

    private bool isCrouching;
    private bool isSliding;

    private Vector2 velocity;

    [Header("Dash Values")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float jumpRate = 1f;
    [SerializeField] private float jumpTime = 0f;

    //public MenuScript menuScript;

    public float gravityScale = 0.5f;
    public float globalGravity = -20f;
    public GameObject SpeedLineOBJ;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRigidbody = GetComponent<Rigidbody>();
        defaultSize = transform.localScale;
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
        /*
        if(!menuScript.gamePaused)
        {
            Move();
            Rotate();
        }
        */

        /*
        if (menuScript.gamePaused)
        {
            return;
        }
        */
    }

    void Update()
    {
        jumpTime += Time.deltaTime;
        
        //Check if player is on the ground or not
        isGrounded = Physics.OverlapBox(groundCheck.transform.position, groundCheckBoxSize).Length > 2;

        if (isGrounded)
        {
            isJumping = false;
        }

        if (!isGrounded)
        {
            isJumping = true;
        }

        //Check for jump input and, if grounded, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && jumpTime > jumpRate)
        {
            
            StartCoroutine(DashForward());
            //nextJump = Time.time + jumpRate;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S) && jumpTime > jumpRate)
        {
            //nextJump = Time.time + jumpRate;
            StartCoroutine(DashBack());
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && jumpTime > jumpRate)
        {
            //nextJump = Time.time + jumpRate;
            StartCoroutine(DashLeft());
        }
        else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && jumpTime > jumpRate)
        {
            //nextJump = Time.time + jumpRate;
            StartCoroutine(DashRight());
        }
        
        /*
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isCrouching = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            isCrouching = true;
            Slide();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouching = false;
            StopSliding();
            transform.localScale = defaultSize;
        }

       /* if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuScript.pauseMenu.GetComponent<Canvas>().enabled == false
                && menuScript.controlsMenu.GetComponent<Canvas>().enabled == false)
            {
                menuScript.OpenPauseMenu();
            }
            else if (menuScript.pauseMenu.GetComponent<Canvas>().enabled == true 
                     || menuScript.controlsMenu.GetComponent<Canvas>().enabled == true)
            {
                menuScript.ClosePauseMenu();
                menuScript.CloseControlsMenu();
            }
        }
       */
        if (isWallLeft)
            StartWallrun();


        if (isWallRight)
            StartWallrun();

        WallRunInput();
        CheckForWall();
     
    }

    void Move()
    {
        
        //Get Input from both axis to determine movement input direction
        xMovement = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, 
            Input.GetAxisRaw("Horizontal") * transform.right.z);
        zMovement = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, 
            Input.GetAxisRaw("Vertical") * transform.forward.z);

        //Apply inputs to movement velocity
        if (!isCrouching)
        {
            velocity = (xMovement + zMovement).normalized * speed * Time.deltaTime;
            playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);
        }

        if (isCrouching && !isSliding)
        {
            //velocity = (xMovement + zMovement).normalized * speed * Time.deltaTime / 4;
            //playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);
        }
    }

    void Rotate()
    {   
        //Get rotation information and apply to turn the player
        float yRotation = Input.GetAxisRaw("Mouse X") * sensitivity * ySensitivity;
        playerRigidbody.rotation *= Quaternion.Euler(0, yRotation * Time.deltaTime, 0);
        
        //Get rotation to tilt camera
        float xRotation = Input.GetAxisRaw("Mouse Y") * sensitivity;
        float xCameraRotation = playerCamera.transform.eulerAngles.x * Time.deltaTime;
        xCameraRotation -= xRotation;

        cameraEulerAnglesX = playerCamera.transform.localEulerAngles.x;
        cameraEulerAnglesX -= xRotation;
        
        playerCamera.transform.localEulerAngles = new Vector3(cameraEulerAnglesX, 0, wallRunCameraTilt);
        //Tilts camera in .5 second
        if (Math.Abs(wallRunCameraTilt) < maxWallRunCameraTilt && isWallRunning && isWallRight)
            wallRunCameraTilt += Time.deltaTime * maxWallRunCameraTilt * 4;
        if (Math.Abs(wallRunCameraTilt) < maxWallRunCameraTilt && isWallRunning && isWallLeft)
            wallRunCameraTilt -= Time.deltaTime * maxWallRunCameraTilt * 4;

        //Tilts camera back again
        if (wallRunCameraTilt > 0 && !isWallRight && !isWallLeft)
            wallRunCameraTilt -= Time.deltaTime * maxWallRunCameraTilt * 4;
        if (wallRunCameraTilt < 0 && !isWallRight && !isWallLeft)
            wallRunCameraTilt += Time.deltaTime * maxWallRunCameraTilt * 4;
    }

    void Jump()
    {
        if (!isJumping && isGrounded)
        {
            //playerRigidbody.AddForce(new Vector3(0, jumpForce));
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isJumping = true;
            secondJumpAvailable = true;
        }
        else if (secondJumpAvailable)
        {
            playerRigidbody.velocity = Vector3.zero;
            //playerRigidbody.AddForce(new Vector3(0, jumpForce));#
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            secondJumpAvailable = false;
        }

    }
    private IEnumerator DashForward()
    {
        playerRigidbody.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
    }
    private IEnumerator DashBack()
    {
        playerRigidbody.AddForce(transform.forward * dashForce * -1, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
    }
    private IEnumerator DashRight()
    {
        playerRigidbody.AddForce(transform.right * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
    }
    private IEnumerator DashLeft()
    {
        playerRigidbody.AddForce(transform.right * dashForce * - 1, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
    }

    void Slide()
    {
        if (isGrounded)
        {
            SpeedLineOBJ.SetActive(true);
            isSliding = true;
            transform.localScale = crouchSize;
            //playerRigidbody.AddRelativeForce((xMovement + zMovement).normalized * slideForce, ForceMode.VelocityChange);
            playerRigidbody.AddForce(new Vector3(velocity.x * slideForce, playerRigidbody.velocity.y, velocity.y * slideForce), ForceMode.VelocityChange);
        }
    }

    void StopSliding()
    {
        SpeedLineOBJ.SetActive(false);

        isSliding = false;
    }


    private void StartWallrun()
    {
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.useGravity = false;
        isWallRunning = true;

        playerRigidbody.AddForce(new Vector3(5, 0));
        // playerRigidbody.AddForce(orientation.forward * 50 * Time.deltaTime);
        if (playerRigidbody.velocity.magnitude <= maxWallSpeed)
        {
            playerRigidbody.AddForce(orientation.forward * wallrunForce * Time.deltaTime);


            if (isWallRight)
            {
                playerRigidbody.AddForce(orientation.right * wallrunForce / 5 * Time.deltaTime);
                playerRigidbody.AddForce(orientation.forward * 30000 * Time.deltaTime);
            }

            else
                playerRigidbody.AddForce(-orientation.right * wallrunForce / 5 * Time.deltaTime);
            playerRigidbody.AddForce(orientation.forward * 20000 * Time.deltaTime);
        }

        if (playerRigidbody.velocity.magnitude <= 1)
        {
            playerRigidbody.useGravity = true;
        }
    }
    private void StopWallRun()
    {
        SpeedLineOBJ.SetActive(false);
        isWallRunning = false;
        playerRigidbody.useGravity = true;
    }
    private void CheckForWall() 
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);

        //leave wall run
        if (!isWallLeft && !isWallRight) StopWallRun();
        
    
    //rset jump
        if (isWallLeft || isWallRight)  secondJumpAvailable = true;
    }

    private void WallRunInput() 
    {
        //Wallrun
        //if (Input.GetKey(KeyCode.D) && isWallRight) StartWallrun();
       // if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallrun();
       // if (Input.GetKey(KeyCode.W) && isWallLeft) StartWallrun();
    }

}
