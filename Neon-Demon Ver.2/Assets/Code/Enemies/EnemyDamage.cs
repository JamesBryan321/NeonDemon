using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private GameObject Player;
    public MeleeEnemy Enemy;
    public int EnemyDmg = 10;

    public GameObject Projectile;
    public Transform ShootPoint;

    public BoxCollider AttackZone;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.enabled = false;
        AttackZone.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNavMesh()
    {
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.enabled = true;
    }

  

    public void RangeAttack()
    {
        Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
    }

    public void StopEnemy()
    {
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.speed = 0;
    }

    public void StartEnemy()
    {
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.speed = 15;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player.GetComponent<PlayerHP>().PlayerHealth -= EnemyDmg;
        }
    }



}
