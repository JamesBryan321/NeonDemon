using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject Player;
    //public Animator Fade;


    [SerializeField]
    private List<Transform> SoftRespawns;
    [SerializeField]
    private List<Transform> HardRespawns;

    private int SoftRespawnCount = 0;
    private int HardRespawnCount = 0;

    public InputController inputScript;
    #region Debug
    public void RespawnTest()
    {
        RespawnPlayer();
    }
    #endregion
  
    #region Trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SoftRespawn"))
        {
            Transform CurrentRespawn = other.gameObject.transform;
            SoftRespawns.Add(CurrentRespawn);
            SoftRespawnCount++;
            other.gameObject.SetActive(false);
        }

        if(other.CompareTag("HardRespawn"))
        {
            Transform CurrentRespawn = other.gameObject.transform;
            HardRespawns.Add(CurrentRespawn);
            HardRespawnCount++;
            other.gameObject.SetActive(false);
        }


        if(other.CompareTag("SoftRespawnZone"))
        {
            RespawnPlayer();
        }
    }

    #endregion
    public void RespawnPlayer()
    {
        //Fade.SetTrigger("_fade");
        Rumble();
        Player.transform.position = SoftRespawns[SoftRespawnCount-1].position;
    }

    public void HardRespawnPlayer()
    {
        Rumble();
        Player.transform.position = HardRespawns[HardRespawnCount - 1].position;
    }


    public void Rumble()
    {
        StartCoroutine(Vibration());
    }

    public IEnumerator Vibration()
    {
        inputScript.gamePad.SetMotorSpeeds(0.5f, 0.5f);
        yield return new WaitForSeconds(0.4f);
        inputScript.gamePad.SetMotorSpeeds(0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bottle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
