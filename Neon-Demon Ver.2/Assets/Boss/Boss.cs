using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
   
    private enum BossState {START,INVUNERABLE,MOVE, CHARGE, ATTACK1, ATTACK2, VUNERABLE,DEAD}
    private BossState b_BossState;

    [Header("Boss Stats")]
    public int BossHealth = 6;
    public bool BossVunerable;
    public List<GameObject> HPsquares;

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
    public bool BossStartBool;
    //private Renderer MaterialColour;
    public Color AttackColour, VunerableColour,ChargeColour;
    // Start is called before the first frame update
    void Start()
    {
        //MaterialColour = GetComponent<Renderer>();
        b_navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        BossVunerable = false;

        b_BossState = BossState.START;
    }

    // Update is called once per frame
    void Update()
    {
        switch(b_BossState)
        {
            case BossState.START:
                BossStart();
                break;
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
            case BossState.DEAD:
                Dead();
                break;
            default:
                break;

        }


    }

    public void Timelineend()
    {
        BossStartBool = true;
    }
    void BossStart()
    {
        if(BossStartBool == true)
        {
            bossAnim.SetBool("bossstart", true);
            b_BossState = BossState.ATTACK2;
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
        Chargecoroutine = AttackCharge(0.2f);
        //bossAnim.SetTrigger("attack1");
        StartCoroutine(Chargecoroutine);
    }

    IEnumerator AttackCharge(float ChargeTime)
    {
        LastPlayerRef.position = Player.transform.position;
        transform.LookAt(Player.transform);
        //bossAnim.SetBool("chargestart", true);
        yield return new WaitForSeconds(ChargeTime);
        bossAnim.SetTrigger("attack1");
    }

    public void BossSafetyMeasure()
    {
        bossAnim.SetBool("charge", true);
    }

    public void Attack1AnimState()
    {
        //bossAnim.SetBool("chargestart", false);
        b_BossState = BossState.ATTACK1;

    }

    void Attack1()
    {
        bossAnim.SetBool("chargestart", false);
        TempHP = BossHealth;
        BossVunerable = false;
        this.transform.LookAt(Player.transform);
        agent.speed = 200;
        agent.acceleration = 70;
       

        if (Vector3.Distance(LastPlayerRef.position, this.transform.position) < 5)
        {
            agent.speed = 0;
            bossAnim.SetBool("charge",false);
            //b_BossState = BossState.VUNERABLE;
        }
        else
        {
            bossAnim.SetBool("charge", true);
            b_navMeshAgent.SetDestination(LastPlayerRef.position);
        }
    }

    bool aoe;
    void Attack2()
    {
        TempHP = BossHealth;
        BossVunerable = false;
        if(Vector3.Distance(Attack2Pos.position, this.transform.position)<3)
        {
            bossAnim.SetTrigger("attack2charge");
            if(aoe == true)
            {
                AOEattack();
            }
          
        }
        else
        {
            b_navMeshAgent.SetDestination(Attack2Pos.position);
        }
    }

    public void Attack2AnimState()
    {
        //AOEattack();
        aoe = true;
    }

    void AOEattack()
    {

        Debug.Log("spin");
        transform.Rotate(0, 50 * Time.deltaTime, 0);
        foreach (ParticleSystem Fire in Flames)
        {
            Fire.Play();
        }
        bossAnim.SetBool("attack_2", true);
        coroutine = AttackCooldown(5.0f);
        StartCoroutine(coroutine);
    }

    IEnumerator AttackCooldown(float waitTime)
    {
        TempHP = BossHealth;
       
        yield return new WaitForSeconds(waitTime);
        aoe = false;
        bossAnim.SetBool("attack_2", false);

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
        bossAnim.ResetTrigger("attack1");
        bossAnim.ResetTrigger("attack2charge");
        if (BossHealth < TempHP)
        {
            HPsquares[BossHealth].SetActive(false);
            bossAnim.SetTrigger("hit");
            agent.speed = 10;
          
        }
       
       
    }

    public void GoToVUN()
    {
        bossAnim.SetTrigger("vun");
        b_BossState = BossState.VUNERABLE;
    }

    public void hittransistion()
    {
        BossVunerable = false;
        if (BossHealth == 4 || BossHealth == 2)
        {
            agent.speed = 10;
            b_BossState = BossState.INVUNERABLE;
        }
        else if(BossHealth <= 0)
        {
            b_BossState = BossState.DEAD;

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
            bossAnim.SetBool("invun", true);
            transform.LookAt(Attack2Pos.transform);
            INVUNcoroutine = InvunTime(15.0f);
           StartCoroutine(INVUNcoroutine);

        }
        
    }

    IEnumerator InvunTime(float invuncdr)
    {
        yield return new WaitForSeconds(invuncdr);
        bossAnim.SetBool("invun", false);
        b_BossState = BossState.ATTACK2;
    }

    void Dead()
    {
        bossAnim.SetBool("dead", true);
    }
       
}
