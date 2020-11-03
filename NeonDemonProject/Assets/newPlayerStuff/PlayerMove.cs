using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRigidbody;

    public float sensitivity;
    public float ySensitivity;
    
    public GameObject playerCamera;
    public GameObject groundCheck;
    [SerializeField] private bool isGrounded;

    public Vector3 groundCheckBoxSize;

    public float jumpForce;
    private float slideForce;
    private float minSlideForce = 1;
    [SerializeField] private float maxSlideForce;

    private float cameraEulerAnglesX;

    private Vector2 xMovement;
    private Vector2 zMovement;

    private Vector3 defaultSize;
    [SerializeField] private Vector3 crouchSize;
    
    [SerializeField] private bool isJumping;
    [SerializeField] private bool secondJumpAvailable;

    private bool isCrouching;
    private bool isSliding;

    private Vector2 velocity;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        slideForce = minSlideForce;
        defaultSize = transform.localScale;
    }
    
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Update()
    {
        //Check if player is on the ground or not
        isGrounded = Physics.OverlapBox(groundCheck.transform.position, groundCheckBoxSize).Length > 2;

        if (isGrounded)
        {
            isJumping = false;
        }

        //Check for jump input and, if grounded, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isCrouching = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Slide();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouching = false;
            StopSliding();
            transform.localScale = defaultSize;
        }
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
            velocity = (xMovement + zMovement).normalized * speed * Time.deltaTime * slideForce;
            playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);
        }

        if (isCrouching)
        {
            if (!isSliding)
            {
                velocity = (xMovement + zMovement).normalized * speed * Time.deltaTime * slideForce / 4;
                playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);
            }

            if (isSliding)
            {
                velocity = (xMovement + zMovement).normalized * speed * Time.deltaTime * slideForce;
                playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);
            }
        }
    }

    void Rotate()
    {
        //Get rotation information and apply to turn the player
        float yRotation = Input.GetAxisRaw("Mouse X") * sensitivity * ySensitivity;
        playerRigidbody.rotation *= Quaternion.Euler(0, yRotation * Time.deltaTime, 0);
        
        //Get rotation to tilt camera
        float xRotation = Input.GetAxisRaw("Mouse Y") * sensitivity;
        float xCameraRotation = playerCamera.transform.eulerAngles.x;
        xCameraRotation -= xRotation;

        cameraEulerAnglesX = playerCamera.transform.localEulerAngles.x;
        cameraEulerAnglesX -= xRotation;

        playerCamera.transform.localEulerAngles = new Vector3(cameraEulerAnglesX, 0, 0);
    }

    void Jump()
    {
        if (!isJumping && isGrounded)
        {
            playerRigidbody.AddForce(new Vector3(0, jumpForce));
            isJumping = true;
            secondJumpAvailable = true;
        }
        else if (secondJumpAvailable)
        {
            playerRigidbody.AddForce(new Vector3(0, jumpForce));
            secondJumpAvailable = false;
        }

    }

    void Slide()
    {
        isSliding = true;
        transform.localScale = crouchSize;
        slideForce = maxSlideForce;
        StartCoroutine(SlideTimer());
    }

    void StopSliding()
    {
        isSliding = false;
        slideForce = minSlideForce;
    }

    IEnumerator SlideTimer()
    {
        yield return new WaitForSeconds(0.5f);
        StopSliding();
    }
}
