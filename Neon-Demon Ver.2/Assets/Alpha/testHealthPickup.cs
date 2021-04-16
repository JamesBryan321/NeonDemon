using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHealthPickup : MonoBehaviour
{
    public PlayerHP HealthRef;
    public float Firerate;
    public float nextFire = 0f;
    private bool checktime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        HealthRef = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.time > nextFire)
        {
            gameObject.SetActive(true);
            checktime = false;
        }

        /*
        if(checktime == true)
        {
            nextFire = Time.time + Firerate;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && HealthRef.PlayerHealth < 1f)
        {
            //checktime = true;
            StartCoroutine(Wait());
            HealthRef.PlayerHealth += 1f;
            gameObject.SetActive(false);

        }
    }

    IEnumerator Wait()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
    }

}
