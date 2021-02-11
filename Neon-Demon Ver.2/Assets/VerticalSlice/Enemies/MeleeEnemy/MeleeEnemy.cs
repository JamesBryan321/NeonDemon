using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    private enum MeleeState { CHASE,IDLE,ATTACK,DODGE,RANGED}
    private MeleeState z_MeleeState;

    private GameObject Player;
    public float speed = 2f;
    public NavMeshAgent z_navMeshAgent;
    public float DetectionRadius = 30f;
    public List<Transform> Waypoints;
    private int CurrentWaypoint;

    public bool dodge;
    public bool Dead;
    public int EnemyDamage = 10;
    public int EnemyHealth = 100;
    public Animator MeleeAnim;

    public GameObject Thruster;

    public float Firerate = 1f;
    public float nextFire = 0f;
    public float extraRotationSpeed;
    public AudioSource DeathSFX;
    private GameObject SlowDown;
    UnityEngine.AI.NavMeshAgent agent;
    //public Transform LineEnemy;
    //public LineRenderer PlayerDet;

    void Start()
    {
        SlowDown = GameObject.Find("SlowdownMeter");
        Player = GameObject.Find("Player");
        z_MeleeState = MeleeState.CHASE;
        z_navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        z_navMeshAgent.enabled = false;

        Firerate = Random.Range(4f, 8f);
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
            case MeleeState.RANGED:
                Ranged();
                break;
            case MeleeState.ATTACK:
                Attack();
                break;
            case MeleeState.DODGE:
                Dodge();
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            z_MeleeState = MeleeState.DODGE;
        }

        //Detection();

        if(Time.time > nextFire && z_MeleeState != MeleeState.ATTACK)
        {
            nextFire = Time.time + Firerate;
            z_MeleeState = MeleeState.RANGED;
        }
        else
        {
            Detection();
        }


        if (Vector3.Distance(Player.transform.position, this.transform.position) < 5)
        {
            z_MeleeState = MeleeState.ATTACK;
        }

        if(EnemyHealth <= 0)
        {
            
            Thruster.SetActive(false);
            z_navMeshAgent.enabled = false;
            Dead = true;
            SlowDown.GetComponent<SlowDownTime>().AddMeter();
            DeathSFX.Play();
            transform.GetComponent<MeleeEnemy>().enabled = false;
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
                        Debug.DrawLine(this.gameObject.transform.position, hit.collider.gameObject.transform.position, Color.red);

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
        //z_navMeshAgent.speed = 15;
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);

        z_navMeshAgent.SetDestination(Player.transform.position);
        agent.destination = Player.transform.position;
    }



    void Attack()
    {
        MeleeAnim.SetTrigger("Attack");
        z_MeleeState = MeleeState.CHASE;
    }

    void Ranged()
    {
        MeleeAnim.SetTrigger("Ranged");
        //z_navMeshAgent.speed = 0;
       
    }


    public void Damage()
    {
        Player.GetComponent<PlayerHP>().PlayerHealth -= EnemyDamage;
    }

    void Dodge()
    {
        transform.Translate(Vector3.right * Time.deltaTime, transform);
        z_MeleeState = MeleeState.CHASE;
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
    
}
