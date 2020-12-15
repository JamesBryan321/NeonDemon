using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject HPUI;
    public int PlayerHealth = 100;
    void Start()
    {
        HPUI.GetComponent<Slider>().value = PlayerHealth;
    }

    void Update()
    {
        HPUI.GetComponent<Slider>().value = PlayerHealth;
    }
}
