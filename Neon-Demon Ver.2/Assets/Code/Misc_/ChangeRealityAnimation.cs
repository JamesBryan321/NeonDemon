﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChangeRealityAnimation : MonoBehaviour
{

    public Animator Belial_Anim;
    public GameObject postProccesing;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            //Belial_Anim.SetBool("RealityChange", true);
            Belial_Anim.SetTrigger("RealityChange");
            StartCoroutine(WaitForChange());
         
        }

    }

    public IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(0.01f);

        //Belial_Anim.SetBool("RealityChange", false);
    }
}
