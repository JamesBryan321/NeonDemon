using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    private enum MeleeState { CHASE,IDLE,ATTACK,}
    private MeleeState z_MeleeState;

    [SerializeField] private GameObject Player;
    public float speed = 2f;
    public NavMeshAgent z_navMeshAgent;
    public float DetectionRadius = 50f;
    public List<Transform> Waypoints;
    private int CurrentWaypoint;

    public bool dodge;
    public bool Dead;
    public int EnemyDamage = 10;
    public int EnemyHealth = 100;
    public Animator MeleeAnim;
    public GameObject warningeffect;
    public GameObject key;

    public GameObject Thruster;

    public float extraRotationSpeed;
    public AudioSource DeathSFX;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        //Player = GameObject.Find("Player");
        z_MeleeState = MeleeState.CHASE;
        z_navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      //  z_navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(z_MeleeState)
        {
            case MeleeState.IDLE:
                Idle();
                break;
            case MeleeState.CHASE:
                Chase();
                break;
            case MeleeState.ATTACK:
                Attack();
                break;
            default:
                break;
        }

        Detection();

        if (Vector3.Distance(Player.transform.position, this.transform.position) < 5)
        {
            z_MeleeState = MeleeState.ATTACK;
        }

        if(EnemyHealth <= 0)
        { 
            Thruster.SetActive(false);
            z_navMeshAgent.enabled = false;
            Dead = true;
            DeathSFX.Play();
            transform.GetComponent<MeleeEnemy>().enabled = false;
            key.SetActive(true);
        }
    }


    void Detection()
    {
        Collider[] PlayerCollider = Physics.OverlapSphere(this.transform.position, DetectionRadius);

        foreach (Collider Object in PlayerCollider)
        {
            if (Object.gameObject.tag == "Player")
            {
                Vector3 targetDirection = (Object.gameObject.transform.position - this.transform.position).normalized;
                Ray rayToTarget = new Ray(this.transform.position, targetDirection);
                RaycastHit hit;
                if (Physics.Raycast(rayToTarget, out hit, DetectionRadius))
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        z_MeleeState = MeleeState.CHASE;
                    }
                }
            }

        }
    }

    void Idle()
    {
        StartCoroutine("WaitIdle");
    }

    IEnumerator WaitIdle()
    {
        yield return new WaitForSeconds(1f);
        z_MeleeState = MeleeState.CHASE;
    }

    void Chase()
    {
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
        z_navMeshAgent.SetDestination(Player.transform.position);
        agent.destination = Player.transform.position;
    }

    void Attack()
    {
        StartCoroutine(Warning());
        MeleeAnim.SetTrigger("Attack");
        z_MeleeState = MeleeState.CHASE;
    }

    public void Damage()
    {
        Player.GetComponent<PlayerHP>().PlayerHealth -= EnemyDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            z_MeleeState = MeleeState.CHASE;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            z_MeleeState = MeleeState.CHASE;
        }
    }
    private IEnumerator Warning()
    {
        warningeffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        warningeffect.SetActive(false);

    }

    private void WaitForSeconds(float v)
    {
        throw new NotImplementedException();
    }
}
