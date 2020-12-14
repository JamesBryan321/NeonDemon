using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public MeleeEnemy EnemyRef;
   // public int HP =  new int 100;
    // Start is called before the first frame update
    void Start()
    {
        //HP = EnemyRef.EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //HP = EnemyRef.EnemyHealth;

        if (EnemyRef.EnemyHealth <=0)
        {
            var ragDollscript = gameObject.GetComponent<RagDoll>();
            ragDollscript.TurnOnRagdoll();
        }
    }

    public void Damage(int damage)
    {
        //HP = HP - damage;
        EnemyRef.EnemyHealth = EnemyRef.EnemyHealth - damage;
       
    }
}
