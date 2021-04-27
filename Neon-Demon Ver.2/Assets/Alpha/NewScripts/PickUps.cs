using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject Revolver;
    public GameObject RevolverRet;

    public Animator Gun_Anim;
    public Shooting GunEnable;
    public AudioSource groovyGunPickup;
    // Start is called before the first frame update
    void Start()
    {
        GunEnable.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             GunEnable.enabled = true;
            GunEnable.Ammo = 6;
            Revolver.SetActive(true);
            RevolverRet.SetActive(true);

            groovyGunPickup.Play();
            Gun_Anim.SetTrigger("Pickup");
            Destroy(gameObject);
        }
    }

}
