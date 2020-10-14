using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;

    public float currentHealth = 0.5f;

    public float maxHealth = 1f;


    public void SetMaxHealth()
    {
        slider.maxValue = maxHealth;
    }

    public void Update()
    {
        slider.value = currentHealth;
    }
}
