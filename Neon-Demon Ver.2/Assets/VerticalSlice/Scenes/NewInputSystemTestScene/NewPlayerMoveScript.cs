using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


//[RequireComponent(typeof(Rigidbody))]
public class NewPlayerMoveScript : MonoBehaviour
{
    #region Variables

    
    private Rigidbody playerRigidbody;

    [Header("GroundCheck")]
    public GameObject groundCheck;
    [SerializeField] private bool isGrounded;
    public Vector3 groundCheckBoxSize;

    [Header("Jump")]
    [SerializeField] public bool isJumping;
    [SerializeField] private bool secondJumpAvailable;
    public float jumpForce;

    [Header("Movement")]
    private Vector2 xMovement;
    private Vector2 zMovement;
    public float moveSpeed = 5.0f;
    private float horizontal;
    private float vertical;
    public Vector2 velocity;


    [Header("Animations")]
    public Animator shotgun;
    public Animator revolver;

 

    public GameObject SpeedLineOBJ;



    public float lookX,lookY;
    private float gravity = -20.0f;
    private Vector3 playerVelocity;
    public float jumpHeight = 2.0f;
    
    public GameObject playerCamera;
    public Animator shotgunAnim;
    public Animator RevolverAnim;

    public bool disablePlayerMovement;
    public bool setPlayerRotation;
    #endregion

    #region StartAwake
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerRigidbody = GetComponent<Rigidbody>();
        if (disablePlayerMovement == true)
        {
            moveSpeed = 0;
        }

        if (setPlayerRotation == true)
        {
            
        }
    }
    #endregion
    
    #region Movement
    private void Update()
    {
        isGrounded = groundCheck.GetComponent<GroundCheck>().isGrounded;
        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);
        if (isGrounded)
        {
          
            revolver.ResetTrigger("In Air");
            isJumping = false;
        
            revolver.SetTrigger("OnGround");

            shotgun.SetTrigger("OnGround");
            shotgun.ResetTrigger("In Air");
        }

        if (!isGrounded)
        {
            isJumping = true;
            shotgun.ResetTrigger("Idle");
            shotgun.ResetTrigger("Run");
            shotgun.ResetTrigger("OnGround");

            revolver.ResetTrigger("Idle");
            revolver.ResetTrigger("Run");
            revolver.ResetTrigger("OnGround");
        }
      


        xMovement = new Vector2(horizontal * transform.right.x, 
            horizontal * transform.right.z);
        zMovement = new Vector2(vertical * transform.forward.x, 
            vertical * transform.forward.z);

        //Apply inputs to movement velocity
        velocity = (xMovement + zMovement).normalized * moveSpeed;
            playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);

        ///*
        if (velocity != null)
        {
        

            revolver.ResetTrigger("Idle");
            revolver.SetTrigger("Run");
            shotgun.ResetTrigger("Idle");
            shotgun.SetTrigger("Run");
        }




        else if (velocity == new Vector2(0,0))
        {

            shotgun.ResetTrigger("Run");
            shotgun.SetTrigger("Idle");
            revolver.ResetTrigger("Run");
            revolver.SetTrigger("Idle");
        }
        //*/

        if (velocity == new Vector2(0, 0))
        {
            shotgun.ResetTrigger("Run");
            shotgun.SetTrigger("Idle");

            revolver.ResetTrigger("Run");
            revolver.SetTrigger("Idle");
        }

    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;

        //Debug.Log($"Player Controller: Left Stick Input: {vertical}, {horizontal}");
    }

    public void AllowMovement()
    {
        moveSpeed = 18;
    }

    #endregion

    #region Jump
    public void OnJumpInput()
    {
        if (!isJumping && isGrounded)
        {
            isJumping = true;
            secondJumpAvailable = true;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

            revolver.ResetTrigger("Run");
            revolver.SetTrigger("Jump");
            shotgun.ResetTrigger("Run");
            shotgun.SetTrigger("Jump");
            //shotgun.ResetTrigger("Idle");
            //  shotgun.SetTrigger("Jump");

        }
        else if (secondJumpAvailable)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            secondJumpAvailable = false;

            revolver.ResetTrigger("Run");
            revolver.SetTrigger("DoubleJump");
            shotgun.ResetTrigger("Run");
            shotgun.SetTrigger("DoubleJump");
            // shotgun.ResetTrigger("Idle");
            // shotgun.SetTrigger("Jump");
        }

    }
    #endregion
}
