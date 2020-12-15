using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Diagnostics;
//using System.Diagnostics;

public class Shooting : MonoBehaviour
{
    public MenuScript menuScript;
    
    [Header("Gun Stats")]
    public TMP_Text AmmoCount;
    public int damage = 25;
    public int Ammo;
    public int ReloadAmmo;
    public float Firerate = 1f;
    public float nextFire = 0f;
    public Transform FirePoint;
    public float BulletSpeed;

    [Header("SFX")]
    public AudioSource FIRESFX;

    [Header("Particle Effects")]
   // public GameObject projectile;
    public List<ParticleSystem> ShootingSFX;
    public ParticleSystem Muzzleflash;
    public GameObject impactEffect;
    public List<GameObject> BloodFX;
    public Light DirLight;

    [Header("Extras")]
   // public TImeManager timeManager;
    public Camera cam;
    //public Animator Gun_Anim;
   // public Animator Cam_Anim;
   // public Animator Ads_anim;

    //private IEnumerator WaitForReload;


    void Start()
    {
        //Ads_anim = GetComponent<Animator>();
       //Cam_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        AmmoCount.text = "" + Ammo;
        /*
        if (menuScript.gamePaused)
        {
            return;
        }*/
        
        //////
        if (Input.GetMouseButton(0) && Ammo > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + Firerate;
            Muzzleflash.Play();
            //Gun_Anim.SetTrigger("Shoot");
            Ammo -= 1;
            int randomNum = Random.Range(0, 2);
            Shoot();
            ShootingSFX[randomNum].Emit(1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Ammo = ReloadAmmo;
        }
       /* if (Input.GetMouseButton(1))
        {
            Ads_anim.SetBool("Ads", true);


        } else {
            Ads_anim.SetBool("Ads", false);
        }
        if (Input./*GetMouseButtonDown GetKeyDown(KeyCode.R))
        {
            Ads_anim.SetBool("Reload", true);

         StartCoroutine(WaitForReload());
           // Ammo = ReloadAmmo;
        }
      

        else
        {
           
        }
      */

    }
    void Shoot()
    {
        FIRESFX.Play();
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
            Destroy(impactEffectGO, 2);        
            if (hit.transform.CompareTag("Enemy"))
            {
                float angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;
                int randomblood = Random.Range(0, BloodFX.Count);
                var instance = (Instantiate(BloodFX[randomblood], hit.point, Quaternion.Euler(0, angle + 90, 0)));
                var settings = instance.GetComponent<BFX_BloodSettings>();
                settings.FreezeDecalDisappearance = true;
                settings.LightIntensityMultiplier = DirLight.intensity;
                hit.transform.GetComponent<TakeDamage>().Damage(damage);
            }
            if (hit.transform.CompareTag("bottle"))
            {
               var destructableScript = hit.transform.GetComponent<Destructable>();
                destructableScript.Break();
            }
            if (hit.transform.CompareTag("barrel"))
            {
                var barrelScript = hit.transform.GetComponent<Explodingbarrel>();
                barrelScript.explode();
            }
        }
    }

    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(1);
        Ammo = ReloadAmmo;
        //Ads_anim.SetBool("Reload", false);
    }
    /*
    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/NeonDemonGame");
    }
    */


}
