﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMortarAction : MonoBehaviour
{

   public GameObject enemyNavObstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy == true)
        {
            enemyNavObstacle.SetActive(false);
        }
    }
    
}
