using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private GameObject Player;
    public MeleeEnemy Enemy;
    public int EnemyDmg = 10;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNavMesh()
    {
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.enabled = true;
    }

    public void Damage()
    {
        Player.GetComponent<PlayerHP>().PlayerHealth -= EnemyDmg;

    }

    
}
