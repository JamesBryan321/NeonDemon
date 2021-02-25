using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Slider slider;
    void Start()
    {
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        health = slider.value;

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
       
    }


    public  void Damage()
    {
        slider.value = slider.value - 10f;
    }
    
}
