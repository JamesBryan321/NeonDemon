using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private GameObject SpeedLineOBJ;
    [Header("Dash Values")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float jumpRate = 1f;
    [SerializeField] private float jumpTime = 0f;

    public Image DashCDR;
    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && jumpTime > jumpRate)
        {
            StartCoroutine(DashForward());
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S) && jumpTime > jumpRate)
        {
            StartCoroutine(DashBack());
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && jumpTime > jumpRate)
        {
            StartCoroutine(DashLeft());
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && jumpTime > jumpRate)
        {
            StartCoroutine(DashRight());
        }
    }

    private IEnumerator DashForward()
    {
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);
        jumpTime = 0;
        DashCDR.fillAmount = jumpTime;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
    }
    private IEnumerator DashBack()
    {
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.AddForce(transform.forward * dashForce * -1, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
    }
    private IEnumerator DashRight()
    {
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.AddForce(transform.right * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
    }
    private IEnumerator DashLeft()
    {
        SpeedLineOBJ.SetActive(true);
        playerRigidbody.AddForce(transform.right * dashForce * -1, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        jumpTime = 0;
        playerRigidbody.velocity = Vector3.zero;
        SpeedLineOBJ.SetActive(false);
    }
}
