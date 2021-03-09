using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
   
    private enum BossState {MOVE, ATTACK1, ATTACK2, VUNERABLE}
    private BossState b_BossState;

    [Header("Boss Stats")]
    public int BossHealth = 6;
    public bool BossVunerable;

    [Header("Boss Attacks")]
    public List<ParticleSystem> Flames;

    [SerializeField] private GameObject Player;

    public Transform Attack2Pos;

    public NavMeshAgent b_navMeshAgent;
    UnityEngine.AI.NavMeshAgent agent;
    private IEnumerator coroutine;
    private IEnumerator Vcoroutine;

    private int TempHP;

    private Renderer MaterialColour;
    public Color AttackColour, VunerableColour;
    // Start is called before the first frame update
    void Start()
    {
        MaterialColour = GetComponent<Renderer>();
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
            case BossState.ATTACK1:

                break;
            case BossState.ATTACK2:
                Attack2();
                break;
            case BossState.VUNERABLE:
                Vunerable();
                break;
            default:
                break;

        }


    }

    void Move()
    {
        BossVunerable = false;
    }

    void Attack1()
    {
        BossVunerable = false;
    }

    void Attack2()
    {
        BossVunerable = false;
        MaterialColour.material.SetColor("_Color", AttackColour);
        if(Vector3.Distance(Attack2Pos.position, this.transform.position)<3)
        {
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
       
        b_BossState = BossState.VUNERABLE;
    }

    void Vunerable()
    {
        StopAllCoroutines();
        BossVunerable = true;
        MaterialColour.material.SetColor("_Color", VunerableColour);

        if (BossHealth < TempHP)
        {
            b_BossState = BossState.ATTACK2;
        }
    }
    /*
    IEnumerator VunerableCooldown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        b_BossState = BossState.ATTACK2;
    }
    */
}
