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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RespawnTest()
    {
        Debug.Log("Respawn");
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        /*if ()
        {
            Debug.Log("Respawn");
            RespawnPlayer();
           
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SoftRespawn"))
        {
            Transform CurrentRespawn = other.gameObject.transform;
            SoftRespawns.Add(CurrentRespawn);
            SoftRespawnCount++;
            other.gameObject.SetActive(false);
        }
    }

    public void RespawnPlayer()
    {
        Player.transform.position = SoftRespawns[SoftRespawnCount-1].position;
    }
}
