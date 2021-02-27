﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject Revolver;
    public Animator Gun_Anim;

    public AudioSource groovyGunPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Revolver.SetActive(true);
            groovyGunPickup.Play();
            Gun_Anim.SetTrigger("Pickup");
            Destroy(gameObject);
        }
    }

}
