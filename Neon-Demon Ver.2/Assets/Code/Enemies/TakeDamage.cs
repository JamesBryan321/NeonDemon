﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public MeleeEnemy EnemyRef;
    public AudioSource Pain;
    void Update()
    {
        if (EnemyRef.EnemyHealth <=0)
        {
            var ragDollscript = gameObject.GetComponent<RagDoll>();
            ragDollscript.TurnOnRagdoll();
        }
    }

    public void Damage(int damage)
    {
        Pain.Play();
        EnemyRef.EnemyHealth = EnemyRef.EnemyHealth - damage;
    }
    public void Thrusterdamage()
    {
        EnemyRef.EnemyHealth = EnemyRef.EnemyHealth - 100;
    }
}
