using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private GameObject Player;
    public MeleeEnemy Enemy;
    public float EnemyDmg = 0.1f;

    public GameObject Projectile;
    public Transform ShootPoint;

    public BoxCollider AttackZone;
    public AudioSource MeleeSFX;
    [SerializeField] private int CheckReality = 1;
    // Start is called before the first frame update
    void Start()
    {
        CheckReality = 1;
        Player = GameObject.Find("Player");
        Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.enabled = true;
        AttackZone.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.E))
        {
            CheckReality = CheckReality * -1;
            if (CheckReality < 0)
            {
                Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.speed = 30;
            }
            else
            {
                Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.speed = 20;
            }
        }*/
    }
    /*
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

        if (CheckReality < 0)
        {
            Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.speed = 30;
        }
        else
        {
            Enemy.GetComponent<MeleeEnemy>().z_navMeshAgent.speed = 20;
        }
    }
    */
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //MeleeSFX.Play();
            Player.GetComponent<PlayerHP>().PlayerHealth -= EnemyDmg;
        }
    }

    public void AttackSFX()
    {
        MeleeSFX.Play();
    }



}
