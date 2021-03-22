using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public BoxCollider AttackZone;
    // Start is called before the first frame update
    void Start()
    {
        AttackZone.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player.GetComponent<PlayerHP>().PlayerHealth -= 0.25f;
        }
    }
}
