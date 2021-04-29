using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMortarReference : MonoBehaviour
{
    public GameObject player;

    public FirstMortarDestroyedCounter mortarDestructionScript;

    public Animator MortarAnimator;
    public GameObject MortarEnemy;

    // Start is called before the first frame update
    void Start()
    {
        MortarAnimator = MortarEnemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyRobot()
    {

        mortarDestructionScript.AddToMortarCount();
        player.GetComponent<CamShaker>().shakeIt();

        MortarAnimator.SetBool("IsDead", true);
    }

}
