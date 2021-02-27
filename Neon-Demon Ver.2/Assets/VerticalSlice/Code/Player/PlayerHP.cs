using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public GameObject HPUI;
    public float PlayerHealth = 1;
    public List<GameObject> DamageObjects;
    void Start()
    {
        //HPUI.GetComponent<Image>().fillAmount = PlayerHealth;
    }

    void Update()
    {
        HPUI.GetComponent<Image>().fillAmount = PlayerHealth;

        /*
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
        */
    }
}
