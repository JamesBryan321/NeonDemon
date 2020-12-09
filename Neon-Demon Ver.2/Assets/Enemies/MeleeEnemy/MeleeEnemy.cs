using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    private enum MeleeState { PATROL,CHASE,IDLE,ATTACK,DODGE}
    private MeleeState z_MeleeState;

    private GameObject Player;
    public float speed = 2f;
    public NavMeshAgent z_navMeshAgent;
    public float DetectionRadius = 30f;
    public List<Transform> Waypoints;
    private int CurrentWaypoint;

    public bool dodge;
    public int EnemyDamage = 10;
    public Animator MeleeAnim;

    UnityEngine.AI.NavMeshAgent agent;
    //public Transform LineEnemy;
    //public LineRenderer PlayerDet;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        z_MeleeState = MeleeState.CHASE;
        z_navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        z_navMeshAgent.enabled = false;

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
            case MeleeState.PATROL:
                Patrol();
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

        Detection();

        if (Vector3.Distance(Player.transform.position, this.transform.position) < 5)
        {
            z_MeleeState = MeleeState.ATTACK;
            //StartCoroutine("Damage");
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
                        //LastPlayerSighting = hit.collider.gameObject.transform.position;
                        //Searching = false;
                    }
                }
            }

        }
    }

    void Idle()
    {
        //Debug.Log("Idle");
        StartCoroutine("WaitIdle");
    }

    IEnumerator WaitIdle()
    {
        yield return new WaitForSeconds(1f);
        z_MeleeState = MeleeState.CHASE;
    }

    void Chase()
    {
        //Debug.Log("Chase");
        //PlayerDet.SetPosition(0, LineEnemy.position);
        // PlayerDet.SetPosition(1, Player.transform.position);
        z_navMeshAgent.SetDestination(Player.transform.position);
        agent.destination = Player.transform.position;
    }

    void Patrol()
    {
        //PlayerDet.SetPosition(0, this.transform.position);
        //PlayerDet.SetPosition(1, this.transform.position);
        //Debug.Log("Patrol");
        transform.rotation = Quaternion.Lerp(transform.rotation, Waypoints[CurrentWaypoint].rotation, Time.deltaTime * 1.6f);
        //transform.LookAt(Waypoints[CurrentWaypoint].position);
        z_navMeshAgent.SetDestination(Waypoints[CurrentWaypoint].position);

        if (Vector3.Distance(Waypoints[CurrentWaypoint].position, this.transform.position) < 2)
        {
            CurrentWaypoint = (CurrentWaypoint + 1) % Waypoints.Count;
            z_MeleeState = MeleeState.IDLE;

        }
    }

    void Attack()
    {
        //Debug.Log("Attack");
        MeleeAnim.SetTrigger("Attack");
        //StartCoroutine("Damage");
        z_MeleeState = MeleeState.CHASE;
    }


    public void Damage()
    {
        Player.GetComponent<PlayerHP>().PlayerHealth -= EnemyDamage;

    }

    void Dodge()
    {
        //Debug.Log("Dodge");
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
