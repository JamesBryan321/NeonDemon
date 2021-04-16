using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public MeleeEnemy EnemyRef;
    public AudioSource Pain;
    public GameObject key;

    void Start()
    {
        EnemyRef = gameObject.GetComponentInParent<MeleeEnemy>();
    }
    
    void Update()
    {
        if (EnemyRef.EnemyHealth <=0)
        {
            var ragDollscript = gameObject.GetComponent<RagDoll>();
            ragDollscript.TurnOnRagdoll();
            transform.GetComponent<TakeDamage>().enabled = false;
            return;
        }

     
    }

    public void Damage(int damage)
    {
        Pain.Play();
        EnemyRef.EnemyHealth = EnemyRef.EnemyHealth - damage;
    }

    public void bigGuyDamage(int damage)
    {
        Pain.Play();
        EnemyRef.BigEnemyHealth = EnemyRef.BigEnemyHealth - damage;
      // key.SetActive(true);

    }
    public void Thrusterdamage()
    {
        EnemyRef.EnemyHealth = EnemyRef.EnemyHealth - 100;
    }
}
