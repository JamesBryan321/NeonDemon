using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public PlayerHP HealthRef;
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
        if(other.CompareTag("Player"))
        {
            if(HealthRef.PlayerHealth < 1)
            {
                HealthRef.PlayerHealth += 0.5f;
                Destroy(gameObject);

            }
        }
    }
}
