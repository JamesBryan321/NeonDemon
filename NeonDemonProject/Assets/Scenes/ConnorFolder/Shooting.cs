using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [Header("Gun Stats")]
    public TMP_Text AmmoCount;
    public float damage = 25;
    public float Ammo;
    public float ReloadAmmo;
    public float Firerate = 1f;
    public float nextFire = 0f;


    [Header("Particle Effects")]
    public List<ParticleSystem> ShootingSFX;
    public ParticleSystem Muzzleflash;
    public GameObject impactEffect;

    [Header("Extras")]
    public TImeManager timeManager;
    public Camera cam;
    public Animator Gun_Anim;
    public Animator Cam_Anim;
   


    // Start is called before the first frame update
    void Start()
    {
 
       Cam_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AmmoCount.text = "" + Ammo;
        //////
        if (Input.GetMouseButton(0) && Ammo > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + Firerate;
            Muzzleflash.Play();
            Gun_Anim.SetTrigger("Shoot");
            Ammo -= 1;
            int randomNum = Random.Range(0, 2);
            Shoot();
            ShootingSFX[randomNum].Emit(1);
        }
        else if(Input.GetMouseButtonDown(1))
        {
             Gun_Anim.SetTrigger("Reload");
       
            Ammo = ReloadAmmo;
        }
        else
        {
           
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
            Destroy(impactEffectGO, 2);
           
            Debug.Log( hit.collider.gameObject.name);
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<TakeDamage>().Damage(damage);
            }
            if (hit.transform.CompareTag("bottle"))
            {
               var destructableScript = hit.transform.GetComponent<Destructable>();
                destructableScript.Break();
            }
        }
    }

 

}
