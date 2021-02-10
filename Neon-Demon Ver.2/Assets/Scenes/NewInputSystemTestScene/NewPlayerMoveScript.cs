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
    public TImeManager TimeRef;
    
    //New Stuff
    public float moveSpeed = 5.0f;
    
    private float horizontal;
    private float vertical;

    private float cameraRotation;
    private float cameraTilt;

    public float lookX;
    public float lookY;

    public float sensitivityX;
    public float sensitivityY;
    
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
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
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

    
    public void OnRotateInput(float cameraRotation, float cameraTilt)
    {
        this.cameraRotation = cameraRotation;
        this.cameraTilt = cameraTilt;
        //Debug.Log($"Player Controller: Right Stick Input: {vertical}, {horizontal}");
    }
    void FixedUpdate()
    {
        if (gamePaused)
        {
            return;
        }
        
        lookX += cameraRotation * sensitivityX * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, lookX, 0);
        
        //movement
        /*charController.Move(transform.right * horizontal * moveSpeed * Time.deltaTime
                            + transform.forward * vertical * moveSpeed * Time.deltaTime
                            + gravity * transform.up * Time.deltaTime);
        */

        lookY -= cameraTilt * sensitivityY * Time.deltaTime;
        lookY = Mathf.Clamp(lookY/* - rotate.y*/, minCameraTilt, maxCameraTilt);
        playerCamera.transform.localEulerAngles = new Vector3(lookY, 0, 0);
        //Move();
        //Rotate();
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

    public void OnJumpInput()
    {
        //Debug.Log("Jump 1");
        if (!isJumping && isGrounded)
        {
            //Debug.Log("Jump 2");
            playerRigidbody.AddForce(new Vector3(0, jumpForce));
            isJumping = true;
            secondJumpAvailable = true;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * gravity);
        }
        else if (secondJumpAvailable)
        {
            //charController.velocity = Vector3.zero;
            //playerRigidbody.AddForce(new Vector3(0, jumpForce));
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            secondJumpAvailable = false;
        }

    }
    
   

    void Slide()
    {
        if (isGrounded)
        {
            SpeedLineOBJ.SetActive(true);
            isSliding = true;
            //transform.localScale = crouchSize;
            //playerRigidbody.AddRelativeForce((xMovement + zMovement).normalized * slideForce, ForceMode.VelocityChange);
            //playerRigidbody.AddForce(new Vector3(velocity.x * slideForce, playerRigidbody.velocity.y, velocity.y * slideForce), ForceMode.VelocityChange);
        }
    }

    void StopSliding()
    {
        SpeedLineOBJ.SetActive(false);

        isSliding = false;
    }

    /*
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
        isWallRight = Physics.Raycast(transform.position, orientation.right, 2f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 2f, whatIsWall);

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
    */
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tutorial1"))
        {
            this.transform.position = spawns[0].transform.position;
        }
        else if (collision.gameObject.CompareTag("tutorial2"))
        {
            this.transform.position = spawns[1].transform.position;
        }
        else if (collision.gameObject.CompareTag("tutorial3"))
        {
            this.transform.position = spawns[2].transform.position;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
