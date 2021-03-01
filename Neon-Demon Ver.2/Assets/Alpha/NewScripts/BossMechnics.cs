using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMechnics : MonoBehaviour
{

    public GameObject Player;
    private Transform target;
    public GameObject ChargeEffect;
    public GameObject DizzyEffect;
    public GameObject RunEffect;
    public bool attack;
    public Animator boss;
    public GameObject bossCollider;
    private float distance = 5;


    public GameObject Ring;
    public bool ringAttack;

   



    void Start()
    {
   
 
    }

    private void Update()
    {


       

        transform.LookAt(Player.transform);
        if(attack == true)
        {
            Charge();
        }
        if (ringAttack == true)
        {
           ringAttacking1();
        }
    
        

    }




    private void Charge()
    {
        target = Player.transform;
        StartCoroutine(WaitToCharge());


    }
    private void ringAttacking1()
    {
        Instantiate(Ring, this.transform.position, Quaternion.Euler(90, 0, 0));
        bossCollider.SetActive(true);
        StartCoroutine(RingWait());
     
    }
    private IEnumerator RingWait()
    {
        ChargeEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        bossCollider.SetActive(false);



    }

    private IEnumerator WaitToCharge()
    {
        ChargeEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        
        StartCoroutine(finishAttack());
        boss.SetTrigger("Run");
        RunEffect.SetActive(true);



    }

    private IEnumerator finishAttack()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.15f);
        ChargeEffect.SetActive(false);
        yield return new WaitForSeconds(0.5f);
       
        attack = false;

        boss.SetTrigger("Dizzy");
        bossCollider.SetActive(true);
        RunEffect.SetActive(false);
        StartCoroutine(Reset());
    }


    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.5f);
        DizzyEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
       boss.ResetTrigger("Run");
       boss.ResetTrigger("Dizzy");

       
        boss.SetTrigger("Idle");

        yield return new WaitForSeconds(1.5f);

        DizzyEffect.SetActive(false);
        bossCollider.SetActive(false);
    }

}
