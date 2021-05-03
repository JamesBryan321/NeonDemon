using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

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
    public List<GameObject> FlameColliders;

    [SerializeField] private GameObject Player;

    public Transform Attack2Pos;
    public Transform LastPlayerRef;
    public Transform InvunerablePos;

    public NavMeshAgent b_navMeshAgent;
    UnityEngine.AI.NavMeshAgent agent;
    private IEnumerator coroutine;
    private IEnumerator Chargecoroutine;
    private IEnumerator INVUNcoroutine;
    private IEnumerator Enemycoroutine;
    public Animator bossAnim;
    private int TempHP;
    public bool BossStartBool;

    public List<Renderer> AudioCubes;
    public List<ParticleSystem> ThrusterEffects;
    public ParticleSystem ChargeVFX,ChargeVFX2;
    public ParticleSystem YellowVFX;
    public Material Green, Yellow, Red;
    public SkinnedMeshRenderer BossMat;
    public SkinnedMeshRenderer KeytarMat;
    public List<Transform> Enemies;
    public GameObject Enemy;
    private Renderer MaterialColour;
    public Color AttackColour, VunerableColour,ChargeColour;

    public GameObject painsfx;
    public GameObject flamesfx;
    public AudioSource FlameThrowerSFX, ChargeSFX, SwingSFX;
    public GameObject FadeOut;
    public List<GameObject> UIobjs;
    public GameObject quitToMenuButton;


    public List<Transform> FireWaypoints;
    // Start is called before the first frame update
    void Start()
    {
        MaterialColour = GetComponent<Renderer>();
        b_navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        BossVunerable = false;
        KeytarMat.material = Green;
        BossMat.material = Green;

        foreach (Renderer color in AudioCubes)
        {
            color.material.SetColor("_EmissionColor", Color.green);
        }
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

        if (aoe == true)
        {
            //FlameThrowerSFX.Play();
            flamesfx.SetActive(true);
            AOEattack();
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
       
        YellowVFX.Stop();
        BossVunerable = false;
        TempHP = BossHealth;
        BossMat.material = Red;
        KeytarMat.material = Red;
        foreach (Renderer color in AudioCubes)
        {
            color.material.SetColor("_EmissionColor", Color.red);
        }
        Chargecoroutine = AttackCharge(0.2f);
        //bossAnim.SetTrigger("attack1");
        StartCoroutine(Chargecoroutine);
    }

    IEnumerator AttackCharge(float ChargeTime)
    {
        LastPlayerRef.position = Player.transform.position;
        ChargeVFX.Play();
        ChargeVFX2.Play();
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
        ChargeSFX.Play();
        b_BossState = BossState.ATTACK1;

    }

    void Attack1()
    {
        ChargeVFX.Stop();
        ChargeVFX2.Stop();
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
        agent.speed = 20;
        BossMat.material = Green;
        KeytarMat.material = Green;
        YellowVFX.Stop();
        bossAnim.ResetTrigger("attack1");
        
        YellowVFX.Stop();
        TempHP = BossHealth;
        BossVunerable = false;
        if(Vector3.Distance(Attack2Pos.position, this.transform.position)<2)
        {
            bossAnim.SetTrigger("attack2charge");
        
          
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
    private int currentwaypoint;
    void AOEattack()
    {
        //YellowVFX.Stop();
        BossMat.material = Red;
        KeytarMat.material = Red;
        foreach (Renderer color in AudioCubes)
        {
            color.material.SetColor("_EmissionColor", Color.red);
        }
        Debug.Log("spin");
        transform.Rotate(0, 30 * Time.deltaTime, 0);

        b_navMeshAgent.SetDestination(FireWaypoints[currentwaypoint].position);

        if(Vector3.Distance(FireWaypoints[currentwaypoint].position, this.transform.position)<2)
        {
            currentwaypoint = (currentwaypoint + 1) % FireWaypoints.Count;
        }

        foreach (ParticleSystem Fire in Flames)
        {
            Fire.Play();
            
        }
        foreach (GameObject col in FlameColliders)
        {
            col.SetActive(true);
        }
        bossAnim.SetBool("attack_2", true);
        coroutine = AttackCooldown(10.0f);
        StartCoroutine(coroutine);
    }

    IEnumerator AttackCooldown(float waitTime)
    {
        TempHP = BossHealth;
       
        yield return new WaitForSeconds(waitTime);
        aoe = false;
        bossAnim.SetBool("attack_2", false);
        //FlameThrowerSFX.Stop();
        flamesfx.SetActive(false);
        foreach (ParticleSystem Fire in Flames)
        {
            Fire.Stop();
          
        }
        foreach (GameObject col in FlameColliders)
        {
            col.SetActive(false);
        }
        bossAnim.SetTrigger("vun");
        bossAnim.ResetTrigger("hit");
        YellowVFX.Play();
        b_BossState = BossState.VUNERABLE;

    }

    void Vunerable()
    {
        
        StopAllCoroutines();
       
        BossVunerable = true;
        bossAnim.ResetTrigger("attack1");
        bossAnim.ResetTrigger("attack2charge");
        BossMat.material = Yellow;
        KeytarMat.material = Yellow;
        foreach (Renderer color in AudioCubes)
        {
            color.material.SetColor("_EmissionColor", Color.yellow);
        }
        if (BossHealth < TempHP)
        {
            YellowVFX.Stop();
            painsfx.SetActive(true);
            BossVunerable = false;
            HPsquares[BossHealth].SetActive(false);
            bossAnim.SetTrigger("hit");
            agent.speed = 10;
          
        }
       
       
    }

    public void hitsfx()
    {
        painsfx.SetActive(false);
    }

    public void PlaySwing()
    {
        SwingSFX.Play();
    }
    public void GoToVUN()
    {
        bossAnim.ResetTrigger("hit");
        bossAnim.SetTrigger("vun");
        YellowVFX.Play();

        b_BossState = BossState.VUNERABLE;
    }

    public GameObject BossSprite1,BossSprite2, BossSprite3;

    public void hittransistion()
    {
        BossVunerable = false;
        if (BossHealth == 4 )
        {
            BossSprite1.SetActive(false);
            BossSprite2.SetActive(true);
            agent.speed = 20;
            EnemiesSpawn = true;
            b_BossState = BossState.INVUNERABLE;
        }
        else if(BossHealth == 2)
        {
            BossSprite2.SetActive(false);
            BossSprite3.SetActive(true);
            agent.speed = 20;
            EnemiesSpawn = true;
            b_BossState = BossState.INVUNERABLE;
        }
        else if(BossHealth <= 0)
        {
            b_BossState = BossState.DEAD;

        }
        else
        {
            int random = Random.Range(0, 2);
            if(random == 0)
            {
                b_BossState = BossState.CHARGE;
            }
            else
            {
                b_BossState = BossState.ATTACK2;
            }

        }
    }

    public void chargeaftervun()
    {
        BossVunerable = false;
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            b_BossState = BossState.CHARGE;
        }
        else
        {
            b_BossState = BossState.ATTACK2;
        }

    }

    public bool EnemiesSpawn;

    void Invunerable()
    {
        YellowVFX.Stop();
        BossMat.material = Green;
        KeytarMat.material = Green;
        foreach (Renderer color in AudioCubes)
        {
            color.material.SetColor("_EmissionColor", Color.green);
        }
        BossVunerable = false;
        if (Vector3.Distance(InvunerablePos.position, this.transform.position) > 3)
        {
            b_navMeshAgent.SetDestination(InvunerablePos.position);
            if (EnemiesSpawn == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(Enemy, Enemies[i]);
                }
            }
            Enemycoroutine = SpawnEnemies(0.1f);
            StartCoroutine(Enemycoroutine);
        }
        else
        {
            bossAnim.SetBool("invun", true);
            transform.LookAt(Attack2Pos.transform);
            // EnemiesSpawn = true;
         
            INVUNcoroutine = InvunTime(15.0f);
           StartCoroutine(INVUNcoroutine);

        }
        
    }

    IEnumerator SpawnEnemies(float spawntime)
    {
        
       
        EnemiesSpawn = false;
        yield return new WaitForSeconds(spawntime);
    }

    IEnumerator InvunTime(float invuncdr)
    {
        yield return new WaitForSeconds(invuncdr);
        bossAnim.SetBool("invun", false);
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            b_BossState = BossState.CHARGE;
            StopAllCoroutines();
            yield break;
        }
        else
        {
            b_BossState = BossState.ATTACK2;
            StopAllCoroutines();
            yield break;
        }
    }

    void Dead()
    {
        foreach (ParticleSystem fire in ThrusterEffects)
        {
            fire.Stop();
        }
        YellowVFX.Stop();
        bossAnim.SetBool("dead", true);
    }

    public void FadeOutAnim()
    {
        this.transform.GetComponent<Boss>().enabled = false;
        foreach (GameObject item in UIobjs)
        {
            item.SetActive(false);
        }
       FadeOut.SetActive(true);
       EventSystem.current.SetSelectedGameObject(null);
       EventSystem.current.SetSelectedGameObject(quitToMenuButton);
    }    
       
}
