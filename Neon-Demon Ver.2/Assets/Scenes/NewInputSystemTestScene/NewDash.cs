using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewDash : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private GameObject SpeedLineOBJ;
    [Header("Dash Values")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float jumpRate = 1f;
    [SerializeField] private float jumpTime = 0f;

    public Image DashCDR;

    private Vector2 dashVelocity;

    public NewPlayerMoveScript playerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTime += Time.deltaTime;
        //if(DashCDR.fillAmount <  jumpRate)
        //{
           // DashCDR.fillAmount += Time.deltaTime;
        //}

        
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
        StartCoroutine(DashTest());

    }
    
    private IEnumerator DashTest()
    {
        Debug.Log("Dash");
        //dashVelocity = playerMoveScript.velocity * dashForce;
        //playerRigidbody.velocity = new Vector3(dashVelocity.x, 0, dashVelocity.y);
        
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.AddForce(new Vector3(playerMoveScript.velocity.x, 0, 
                                playerMoveScript.velocity.y) * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        //DashCDR.fillAmount = jumpTime;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
        
        
    }
}
