using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRemainIdle : MonoBehaviour
{
    public Animator enemyAnimator;
    void Start()
    {
        enemyAnimator.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
