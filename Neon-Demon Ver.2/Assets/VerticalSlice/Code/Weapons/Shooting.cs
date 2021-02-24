using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Diagnostics;
//using System.Diagnostics;

public class Shooting : MonoBehaviour
{
    public MenuScript menuScript;
    public Vector3 upRecoil;
    Vector3 originalRot;

    [Header("Gun Stats")]
   // public TMP_Text AmmoCount;
    public int damage = 25;
    public int Ammo;
    public int ReloadAmmo;
    public float Firerate = 1f;
    public float nextFire = 0f;
    public Transform FirePoint;
    public float BulletSpeed;
    public GameObject armsway;
    public GameObject gunsway;



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
    public Animator Ads_anim;

    //private IEnumerator WaitForReload;


    void Start()
    {
        //Ads_anim = GetComponent<Animator>();
       //Cam_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        //AmmoCount.text = "" + Ammo;
        /*
        if (menuScript.gamePaused)
        {
            return;
        }*/
        
        //////
        //
        /*
        if (Input.GetMouseButton(0) && Ammo > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + Firerate;
            Muzzleflash.Play();
            //Gun_Anim.SetTrigger("Shoot");
            Ammo -= 1;
            int randomNum = Random.Range(0, 2);
            Shoot();
            ShootingSFX[randomNum].Emit(1);
          //  Ads_anim.SetBool("Fire", true);


        }  
        */
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
           // Ammo = ReloadAmmo;
        }
        if (Input.GetMouseButton(1))
        {
           // Ads_anim.SetBool("Ads", true);


        } 
        
        else {
           // Ads_anim.SetBool("Ads", false);
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(WaitForReload());
            Ads_anim.enabled = true;
            Ads_anim.SetBool("Reload", true);

            StartCoroutine(WaitForReload());
         
       
            //Ammo = ReloadAmmo;
        }
        */

        if(Ammo == 0)
        {
           // Ads_anim.enabled = true;
           // Ads_anim.SetBool("Reload", true);

          //  StartCoroutine(WaitForReload());
        }
      

 
      

    }
  
    void Shoot()
    {
        FIRESFX.Play();
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        Ads_anim.SetBool("Shoot", true);

        if (Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
            Destroy(impactEffectGO, 2);

            StartCoroutine(wait());
            if (hit.transform.CompareTag("Enemy"))
            {
                float angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;
                int randomblood = Random.Range(0, BloodFX.Count);
                var instance = (Instantiate(BloodFX[randomblood], hit.point, Quaternion.Euler(0, angle + 90, 0)));
                var settings = instance.GetComponent<BFX_BloodSettings>();
                settings.FreezeDecalDisappearance = true;
              //  settings.LightIntensityMultiplier = DirLight.intensity;
                hit.transform.GetComponent<TakeDamage>().Damage(damage);
                StartCoroutine(wait());
            }
            if (hit.transform.CompareTag("Thruster"))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.transform.position, 5f);
                float angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;
                int randomblood = Random.Range(0, BloodFX.Count);
                var instance = (Instantiate(BloodFX[randomblood], hit.point, Quaternion.Euler(0, angle + 90, 0)));
                var settings = instance.GetComponent<BFX_BloodSettings>();
                settings.FreezeDecalDisappearance = true;
                
               // settings.LightIntensityMultiplier = DirLight.intensity;
                StartCoroutine(wait());



                //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                hit.transform.GetComponent<TakeDamage>().Thrusterdamage();
                hit.transform.GetComponent<Thruster>().enabled = true;
                /* foreach(Collider hit1 in colliders)
                {
                    Rigidbody rib = hit1.GetComponent<Rigidbody>();
                    if (rib != null)
                    {
                        rib.AddExplosionForce(1000f, hit.transform.GetComponent<EnemyTornApart>().EnemyAnimated.transform.position, 100f, 1f, ForceMode.Impulse);
                    }
                }
                hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();*/
            }
            if (hit.transform.CompareTag("bottle"))
            {
               var destructableScript = hit.transform.GetComponent<Destructable>();
                destructableScript.Break();
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(wait());
            }
            if (hit.transform.CompareTag("barrel"))
            {
                var barrelScript = hit.transform.GetComponent<Explodingbarrel>();
                barrelScript.explode();
                StartCoroutine(wait());
            }
        }
        StartCoroutine(wait());

    }

    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(2);
        Ammo = ReloadAmmo;
        Ads_anim.SetBool("Reload", false);

       
    }
    public IEnumerator wait()
    {
        
        yield return new WaitForSeconds(0.25f);
        Ads_anim.SetBool("Shoot", false);
      //  Ads_anim.SetBool("Reload", true);
       // armsway.GetComponent<Sway>().enabled = false;
      //  gunsway.GetComponent<Sway>().enabled = false;

       // StartCoroutine(WaitForReload());
    }
        //public void OpenTwitter()
        //   {
        //    Application.OpenURL("https://twitter.com/NeonDemonGame");
        // }


        public void OnShootInput()
        {
            if (Ammo > 0 && Time.time > nextFire)
            {
                nextFire = Time.time + Firerate;
                Muzzleflash.Play();
                //Gun_Anim.SetTrigger("Shoot");
                Ammo -= 1;
                int randomNum = Random.Range(0, 2);
            Ads_anim.SetTrigger("Shooting");
                Shoot();
                ShootingSFX[randomNum].Emit(1);
                //  Ads_anim.SetBool("Fire", true);
            }
        }

        public void OnReloadInput()
        {
            StartCoroutine(WaitForReload());
            Ads_anim.enabled = true;
            Ads_anim.SetBool("Reload", true);

            StartCoroutine(WaitForReload());
        }

        public void OnADSInput()
        {
            Debug.Log("ADS");
        }
        
    }
