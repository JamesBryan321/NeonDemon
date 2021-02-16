using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Player;

    [SerializeField]
    private List<Transform> SoftRespawns;
    [SerializeField]
    private List<Transform> HardRespawns;

    private int SoftRespawnCount = 0;
    private int HardRespawnCount = 0;

   
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

    }

    #endregion
    public void RespawnPlayer()
    {
        Player.transform.position = SoftRespawns[SoftRespawnCount-1].position;
    }
}
