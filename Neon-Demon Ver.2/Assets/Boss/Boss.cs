using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
   
    private enum BossState {INVUNERABLE,MOVE, CHARGE, ATTACK1, ATTACK2, VUNERABLE}
    private BossState b_BossState;

    [Header("Boss Stats")]
    public int BossHealth = 6;
    public bool BossVunerable;

    [Header("Boss Attacks")]
    public List<ParticleSystem> Flames;

    [SerializeField] private GameObject Player;

    public Transform Attack2Pos;
    public Transform LastPlayerRef;
    public Transform InvunerablePos;

    public NavMeshAgent b_navMeshAgent;
    UnityEngine.AI.NavMeshAgent agent;
    private IEnumerator coroutine;
    private IEnumerator Chargecoroutine;
    private IEnumerator INVUNcoroutine;

    public Animator bossAnim;
    private int TempHP;

    //private Renderer MaterialColour;
    public Color AttackColour, VunerableColour,ChargeColour;
    // Start is called before the first frame update
    void Start()
    {
        //MaterialColour = GetComponent<Renderer>();
        b_navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        BossVunerable = false;

        b_BossState = BossState.ATTACK2;
    }

    // Update is called once per frame
    void Update()
    {
        switch(b_BossState)
        {
            case BossState.MOVE:

                break;
            case BossState.CHARGE:
                Charge();
                break;
            case BossState.ATTACK1:
                Attack1();
                break;
            case BossState.ATTACK2:
                Attack2();
                break;
            case BossState.VUNERABLE:
                Vunerable();
                break;
            case BossState.INVUNERABLE:
                Invunerable();
                break;
            default:
                break;

        }


    }

    void Move()
    {
        BossVunerable = false;
    }

    void Charge()
    {
        BossVunerable = false;
        TempHP = BossHealth;
        Chargecoroutine = AttackCharge(3.0f);
        StartCoroutine(Chargecoroutine);
    }

    IEnumerator AttackCharge(float ChargeTime)
    {
        LastPlayerRef.position = Player.transform.position;
        transform.LookAt(Player.transform);
        yield return new WaitForSeconds(ChargeTime);
        b_BossState = BossState.ATTACK1;
    }

    void Attack1()
    {
        BossVunerable = false;
        this.transform.LookAt(Player.transform);
        agent.speed = 200;
        agent.acceleration = 70;
       

        if (Vector3.Distance(LastPlayerRef.position, this.transform.position) < 5)
        {
            agent.speed = 0;
            bossAnim.SetTrigger("vun");
            b_BossState = BossState.VUNERABLE;
        }
        else
        {
            b_navMeshAgent.SetDestination(LastPlayerRef.position);
        }
    }

    void Attack2()
    {
        
        BossVunerable = false;
        if(Vector3.Distance(Attack2Pos.position, this.transform.position)<3)
        {
            bossAnim.SetTrigger("attack2");
            transform.Rotate(0, 50 * Time.deltaTime, 0);
            foreach (ParticleSystem Fire in Flames)
            {
                Fire.Play();
            }
            coroutine = AttackCooldown(5.0f);
            StartCoroutine(coroutine);
        }
        else
        {
            b_navMeshAgent.SetDestination(Attack2Pos.position);
        }
    }

    IEnumerator AttackCooldown(float waitTime)
    {
        TempHP = BossHealth;
       
        yield return new WaitForSeconds(waitTime);
        foreach (ParticleSystem Fire in Flames)
        {
            Fire.Stop();
          
        }
        bossAnim.SetTrigger("vun");
        b_BossState = BossState.VUNERABLE;

    }

    void Vunerable()
    {
        
        StopAllCoroutines();
        BossVunerable = true;

        if (BossHealth < TempHP)
        {
            bossAnim.SetTrigger("hit");
            agent.speed = 10;
          
        }

       
    }

    public void hittransistion()
    {
        BossVunerable = false;
        if (BossHealth == 4 || BossHealth == 2)
        {
            agent.speed = 10;
            b_BossState = BossState.INVUNERABLE;
        }
        else
        {
            b_BossState = BossState.CHARGE;

        }
    }

    public void chargeaftervun()
    {
        BossVunerable = false;
        b_BossState = BossState.CHARGE;

    }

    void Invunerable()
    {
        BossVunerable = false;
        if (Vector3.Distance(InvunerablePos.position, this.transform.position) > 3)
        {
            b_navMeshAgent.SetDestination(InvunerablePos.position);
        }
        else
        {
           INVUNcoroutine = InvunTime(5.0f);
           StartCoroutine(INVUNcoroutine);

        }
        
    }

    IEnumerator InvunTime(float invuncdr)
    {
        yield return new WaitForSeconds(invuncdr);
        b_BossState = BossState.ATTACK2;
    }
       
}
