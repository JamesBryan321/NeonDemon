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
    public Respawn spawnref;
    
    public AudioSource hit0, hit1, hit2, hit3, die0, die1;

    public AudioSource[] hitSFX;
   
    void Start()
    {
        //HPUI.GetComponent<Image>().fillAmount = PlayerHealth;
    }

    [System.Obsolete]
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
        */
        if(PlayerHealth <= 0)
        {
            //Application.LoadLevel(Application.loadedLevel);
            PlayRandomDie();
            spawnref.HardRespawnPlayer();
            PlayerHealth = 1;
        }
     
        
    }

    public void PlayRandomHit()
    {
        //Debug.Log("Ouch");
        if (hitSFX[0].isPlaying || hitSFX[1].isPlaying || hitSFX[2].isPlaying || hitSFX[3].isPlaying)
        {
            return;
        }
        //Debug.Log("Ouchie");
        int clipToPlay = Random.Range(0, 3);
        hitSFX[clipToPlay].Play();
    }

    public void PlayRandomDie()
    {
        die0.Play();
    }




}
