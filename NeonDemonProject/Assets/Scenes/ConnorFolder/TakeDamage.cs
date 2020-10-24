﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP<=0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(float damage)
    {
        HP = HP - damage;
    }
}
