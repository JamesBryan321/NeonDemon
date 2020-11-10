using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    private enum MeleeState { PATROL,CHASE,IDLE,ATTACK,DODGE}
    private MeleeState z_MeleeState;

    public GameObject Player;
    public float speed = 2f;
    private NavMeshAgent z_navMeshAgent;
    public float DetectionRadius = 10f;
    public List<Transform> Waypoints;
    private int CurrentWaypoint;
    
    // Start is called before the first frame update
    void Start()
    {
        z_MeleeState = MeleeState.IDLE;
        z_navMeshAgent = GetComponent<NavMeshAgent>();
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


        Detection();
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
                        //Debug.DrawLine(this.gameObject.transform.position, hit.collider.gameObject.transform.position, Color.red);

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
        StartCoroutine("WaitIdle");
    }

    IEnumerator WaitIdle()
    {
        yield return new WaitForSeconds(3f);
        z_MeleeState = MeleeState.PATROL;
    }

    void Chase()
    {
        z_navMeshAgent.SetDestination(Player.transform.position);
    }

    void Patrol()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Waypoints[CurrentWaypoint].rotation, Time.deltaTime * 0.2f);
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

    }

    void Dodge()
    {

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
