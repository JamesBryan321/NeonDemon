using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


//[RequireComponent(typeof(Rigidbody))]
public class NewPlayerMoveScript : MonoBehaviour
{
    
    public float speed;
    private Rigidbody playerRigidbody;

    public float sensitivity;
    public float ySensitivity;
    
    public GameObject groundCheck;
    [SerializeField] private bool isGrounded;

    public Vector3 groundCheckBoxSize;

    public float jumpForce;
    [SerializeField] private float slideForce;
    

    private Vector2 xMovement;
    private Vector2 zMovement;

    [SerializeField] public bool isJumping;
    [SerializeField] private bool secondJumpAvailable;

    private bool isCrouching;
    private bool isSliding;

    public Vector2 velocity;

    public List<GameObject> spawns;
    

    public float distToGround;
 

    public float gravityScale = 0.5f;
    public float globalGravity = -20f;
    public GameObject SpeedLineOBJ;
    public bool gamePaused;
   
    
    //New Stuff
    public float moveSpeed = 5.0f;
    
    private float horizontal;
    private float vertical;



    public float lookX;
    public float lookY;


    
    public float minCameraTilt = -60f;
    public float maxCameraTilt = 60f;

    private CharacterController charController;

    private float gravity = -20.0f;
    private Vector3 playerVelocity;
    public float jumpHeight = 2.0f;
    
    public GameObject playerCamera;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = groundCheck.GetComponent<GroundCheck>().isGrounded;
        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);
        if (isGrounded)
        {
            isJumping = false;
        }

        if (!isGrounded)
        {
            isJumping = true;
        }
     

        xMovement = new Vector2(horizontal * transform.right.x, 
            horizontal * transform.right.z);
        zMovement = new Vector2(vertical * transform.forward.x, 
            vertical * transform.forward.z);

        //Apply inputs to movement velocity
        velocity = (xMovement + zMovement).normalized * moveSpeed;
            playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.y);

    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
        //Debug.Log($"Player Controller: Left Stick Input: {vertical}, {horizontal}");
    }

    
  
    void FixedUpdate()
    {

    }

    public void OnJumpInput()
    {
        if (!isJumping && isGrounded)
        {
            isJumping = true;
            secondJumpAvailable = true;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        else if (secondJumpAvailable)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            secondJumpAvailable = false;
        }

    }
    
}
