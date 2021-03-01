using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    public NavMeshAgent bossAgent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    private bool charging;
    private bool ringattacking;
    public GameObject ring;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;


    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    // Effects 
    public GameObject ChargeEffect;
    public GameObject DizzyEffect;
    public GameObject RunEffect;


    //Boss 
    public Animator boss;
    public GameObject bossCollider;

    private void Awake()
    {
        bossAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);



   
        if (!charging)
        {
            if (playerInSightRange && playerInAttackRange) attacking();
        }

        if (!playerInSightRange && !playerInAttackRange) patroling();
        if (playerInSightRange && !playerInAttackRange) charge();
 
    }

    private void patroling()
    {
        if (!walkPointSet) searchWalkPoint();

        if (walkPointSet)
        {
            bossAgent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }
    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
                
    }
    private void attacking()
    {
        bossAgent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
                Instantiate(ring, this.transform.position, Quaternion.Euler(90, 0, 0));
                bossCollider.SetActive(true);
      

           


            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);

        }

    }
    private void resetAttack()
    {
        alreadyAttacked = false;
    }

    private void charge()
    {
        charging = true;
        ChargeEffect.SetActive(true);
        bossAgent.SetDestination(transform.position);
        StartCoroutine(waitToCharge());
      
    
  

    }

    private IEnumerator waitToCharge()
    {
        yield return new WaitForSeconds(2f);
        ChargeEffect.SetActive(false);
        bossAgent.speed = 15f;
        bossAgent.acceleration = 15f;
        bossAgent.SetDestination(player.transform.position);
        boss.SetTrigger("Run");
        StartCoroutine(waitToBeDizzy());
    }
    private IEnumerator waitToBeDizzy()
    {
        yield return new WaitForSeconds(3f);
        Dizzy();
        bossAgent.SetDestination(transform.position);
        

        

        
    }
    private void Dizzy()
    {
     
        boss.SetTrigger("Dizzy");
        DizzyEffect.SetActive(true);
        bossCollider.SetActive(true);
        StartCoroutine(resetAnims());
   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
    private IEnumerator resetAnims()
    {
        yield return new WaitForSeconds(3f);
    
        boss.SetTrigger("Idle");
        DizzyEffect.SetActive(false);
        bossAgent.speed = 6f;
        bossAgent.acceleration = 3.5f;

        charging = false;
    }
}
