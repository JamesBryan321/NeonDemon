using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public GameObject HPUI;
    public int PlayerHealth = 100;
    public List<GameObject> DamageObjects;
    void Start()
    {
        HPUI.GetComponent<Slider>().value = PlayerHealth;
    }

    void Update()
    {
        HPUI.GetComponent<Slider>().value = PlayerHealth;

        if(PlayerHealth<=100 && PlayerHealth > 60)
        {
            DamageObjects[0].SetActive(false);
            DamageObjects[1].SetActive(false);
            DamageObjects[2].SetActive(false);
        }
        else if(PlayerHealth< 60 && PlayerHealth > 40)
        {
            DamageObjects[0].SetActive(true);
            DamageObjects[1].SetActive(false);
            DamageObjects[2].SetActive(false);
        }
        else if (PlayerHealth < 40 && PlayerHealth > 20)
        {
            DamageObjects[0].SetActive(false);
            DamageObjects[1].SetActive(true);
            DamageObjects[2].SetActive(false);
        }
        else if (PlayerHealth < 20)
        {
            DamageObjects[0].SetActive(false);
            DamageObjects[1].SetActive(false);
            DamageObjects[2].SetActive(true);
        }

        if(PlayerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
