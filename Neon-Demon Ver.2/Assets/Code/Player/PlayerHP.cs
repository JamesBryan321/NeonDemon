using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject HPUI;
    public int PlayerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        HPUI.GetComponent<Slider>().value = PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HPUI.GetComponent<Slider>().value = PlayerHealth;
    }
}
