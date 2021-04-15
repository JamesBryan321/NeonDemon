using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewDash : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private GameObject SpeedLineOBJ;
    [SerializeField] private ParticleSystem DashEffect;



    [Header("Dash Values")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashForceGround;
    [SerializeField] private float dashDuration;
    [SerializeField] private float jumpRate = 1f;
    [SerializeField] private float jumpTime = 0f;

    public Image DashCDR;

    private Vector2 dashVelocity;

    public NewPlayerMoveScript playerMoveScript;

    public InputController inputScript;

    // Start is called before the first frame update
    void Start()
    {

        DashEffect.GetComponent<ParticleSystem>();
            playerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpTime += Time.deltaTime;
        if(DashCDR.fillAmount <  jumpRate)
        {
           DashCDR.fillAmount += Time.deltaTime;
        }

        
    }

    private IEnumerator DashForward()
    {
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);
        jumpTime = 0;
        //DashCDR.fillAmount = jumpTime;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
       
    }


    public void OnDashInput()
    {
        if (jumpTime > jumpRate)
        {
            Rumble();
            StartCoroutine(DashTest());
            DashEffect.Play();
        }
    }
    
    private IEnumerator DashTest()
    {
        //dashVelocity = playerMoveScript.velocity * dashForce;
        //playerRigidbody.velocity = new Vector3(dashVelocity.x, 0, dashVelocity.y);



        if(this.GetComponent<NewPlayerMoveScript>().groundCheck == true)
        {
            playerRigidbody.AddForce(new Vector3(playerMoveScript.velocity.x, 0, playerMoveScript.velocity.y) * dashForceGround, ForceMode.VelocityChange);
        }
        if (this.GetComponent<NewPlayerMoveScript>().groundCheck == false)
        {
            playerRigidbody.AddForce(new Vector3(playerMoveScript.velocity.x, 0, playerMoveScript.velocity.y) * dashForce, ForceMode.VelocityChange);
        }


        SpeedLineOBJ.SetActive(true);
        // playerRigidbody.AddForce(new Vector3(playerMoveScript.velocity.x, 0, playerMoveScript.velocity.y) * dashForce, ForceMode.VelocityChange);
       

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        DashCDR.fillAmount = jumpTime;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
        
        
    }

    public void Rumble()
    {
        StartCoroutine(Vibration());
    }

    public IEnumerator Vibration()
    {
        inputScript.gamePad.SetMotorSpeeds(0.8f, 0.8f);
        yield return new WaitForSeconds(0.3f);
        inputScript.gamePad.SetMotorSpeeds(0, 0);
    }
}
