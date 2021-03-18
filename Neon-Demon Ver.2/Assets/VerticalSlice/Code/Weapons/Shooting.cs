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
    //public ParticleSystem shotgun;

    [Header("Extras")]
   // public TImeManager timeManager;
    public Camera cam;
    //public Animator Gun_Anim;
   // public Animator Cam_Anim;
    public Animator Ads_anim;
    public InputController inputScript;
    public Animator Reticle;

    //private IEnumerator WaitForReload;
public float bulletSpread, bulletXOffset, bulletYOffset;
    public GameObject bulletMarker;
    public bool shotgun;
    private RaycastHit[] shotgunHitPoints;
    private Ray[] shotgunRay;

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
        if (shotgun)
        {
            //ShootShotgun();
            ShootPistol();
        }
        else if (!shotgun)
        {
            ShootPistol();
        }
    }
  
    void ShootPistol()
    {
        FIRESFX.Play();
        //shotgun.Play();
        Rumble();
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        RaycastHit hit;
        Ads_anim.SetBool("Shoot", true);
        Reticle.SetTrigger("Shoot");

        if (Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            Instantiate(bulletMarker, hit.point, Quaternion.LookRotation(hit.normal));
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
            if (hit.transform.CompareTag("BigEnemy"))
            {
                float angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;
                int randomblood = Random.Range(0, BloodFX.Count);
                var instance = (Instantiate(BloodFX[randomblood], hit.point, Quaternion.Euler(0, angle + 90, 0)));
                var settings = instance.GetComponent<BFX_BloodSettings>();
                settings.FreezeDecalDisappearance = true;
                //  settings.LightIntensityMultiplier = DirLight.intensity;
                hit.transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                StartCoroutine(wait());
            }
            if (hit.transform.CompareTag("Rocket"))
            {
      
                hit.transform.GetComponent<MortarProjectile>().reverse();
            
            }
            if (hit.transform.CompareTag("BossCollider"))
            {

                hit.transform.GetComponent<BossHealth>().Damage();
            
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
                Debug.Log("hit thruster, BOOOM");


                //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                hit.transform.GetComponent<TakeDamage>().Thrusterdamage();
                //hit.transform.GetComponent<Thruster>().enabled = true;
                 foreach(Collider hit1 in colliders)
                {
                    Rigidbody rib = hit1.GetComponent<Rigidbody>();
                    if (rib != null)
                    {
                        rib.AddExplosionForce(100f, hit.transform.position, 100f, 1f, ForceMode.Impulse);
                      
                    }
                }
                //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
            }
            if (hit.transform.CompareTag("Head"))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.transform.position, 5f);
                float angle = Mathf.Atan2(hit.normal.x, hit.normal.z) * Mathf.Rad2Deg + 180;
                int randomblood = Random.Range(0, BloodFX.Count);
                var instance = (Instantiate(BloodFX[randomblood], hit.point, Quaternion.Euler(0, angle + 90, 0)));
                var settings = instance.GetComponent<BFX_BloodSettings>();
                settings.FreezeDecalDisappearance = true;

                hit.transform.GetComponent<Headshot>().BoomHeadshot();

                foreach (Collider hit1 in colliders)
                {
                    Rigidbody rib = hit1.GetComponent<Rigidbody>();
                    if (rib != null)
                    {
                        rib.AddExplosionForce(100f, hit.transform.position, 100f, 1f, ForceMode.Impulse);

                    }
                }


                Debug.Log("Boom epic headshot!!!!!!");
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
            if (hit.transform.CompareTag("Mortar"))
            {
            
                hit.transform.GetComponent<MortarReference>().DestroyRobot();
               
            }

            if(hit.transform.CompareTag("Boss"))
            {
                if(hit.transform.GetComponent<Boss>().BossVunerable == true)
                {
                    hit.transform.GetComponent<Boss>().BossHealth -= 1;
                    hit.transform.GetComponent<Boss>().BossVunerable = false;
                }
            }
        }
        StartCoroutine(wait());

    }

    void ShootShotgun()
    {
        FIRESFX.Play();
        //shotgun.Play();
        Rumble();
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        //Ray[] ray;
        for (int i = 1; i <= 6; i++)
        {
            shotgunRay[i] = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        }

        //RaycastHit[] hit;
        Ads_anim.SetBool("Shoot", true);
        Reticle.SetTrigger("Shoot");
        for (int i = 1; i <= 6; i++)
        {
            
            if (Physics.Raycast(shotgunRay[i], out shotgunHitPoints[i], Mathf.Infinity))
            {
                Instantiate(bulletMarker, shotgunHitPoints[i].point, Quaternion.LookRotation(shotgunHitPoints[i].normal));
                GameObject impactEffectGO =
                    Instantiate(impactEffect, shotgunHitPoints[i].point,
                        Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                Destroy(impactEffectGO, 2);

                StartCoroutine(wait());
                if (shotgunHitPoints[i].transform.CompareTag("Enemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoints[i].normal.x, shotgunHitPoints[i].normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoints[i].point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoints[i].transform.GetComponent<TakeDamage>().Damage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoints[i].transform.CompareTag("BigEnemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoints[i].normal.x, shotgunHitPoints[i].normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoints[i].point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoints[i].transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoints[i].transform.CompareTag("Rocket"))
                {

                    shotgunHitPoints[i].transform.GetComponent<MortarProjectile>().reverse();

                }

                if (shotgunHitPoints[i].transform.CompareTag("BossCollider"))
                {

                    shotgunHitPoints[i].transform.GetComponent<BossHealth>().Damage();

                }

                if (shotgunHitPoints[i].transform.CompareTag("Thruster"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoints[i].transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoints[i].normal.x, shotgunHitPoints[i].normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoints[i].point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    // settings.LightIntensityMultiplier = DirLight.intensity;
                    StartCoroutine(wait());
                    Debug.Log("hit thruster, BOOOM");


                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                    shotgunHitPoints[i].transform.GetComponent<TakeDamage>().Thrusterdamage();
                    //hit.transform.GetComponent<Thruster>().enabled = true;
                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoints[i].transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }

                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
                }

                if (shotgunHitPoints[i].transform.CompareTag("Head"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoints[i].transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoints[i].normal.x, shotgunHitPoints[i].normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoints[i].point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    shotgunHitPoints[i].transform.GetComponent<Headshot>().BoomHeadshot();

                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoints[i].transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }


                    Debug.Log("Boom epic headshot!!!!!!");
                }

                if (shotgunHitPoints[i].transform.CompareTag("bottle"))
                {
                    var destructableScript = shotgunHitPoints[i].transform.GetComponent<Destructable>();
                    destructableScript.Break();
                    shotgunHitPoints[i].transform.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(wait());
                }

                if (shotgunHitPoints[i].transform.CompareTag("barrel"))
                {
                    var barrelScript = shotgunHitPoints[i].transform.GetComponent<Explodingbarrel>();
                    barrelScript.explode();
                    StartCoroutine(wait());
                }

                if (shotgunHitPoints[i].transform.CompareTag("Mortar"))
                {

                    shotgunHitPoints[i].transform.GetComponent<MortarReference>().DestroyRobot();

                }

                if (shotgunHitPoints[i].transform.CompareTag("Boss"))
                {
                    if (shotgunHitPoints[i].transform.GetComponent<Boss>().BossVunerable == true)
                    {
                        shotgunHitPoints[i].transform.GetComponent<Boss>().BossHealth -= 1;
                        shotgunHitPoints[i].transform.GetComponent<Boss>().BossVunerable = false;
                    }
                }
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

        public void Rumble()
        {
            StartCoroutine(GunFireVibration());
        }

        public IEnumerator GunFireVibration()
        {
            inputScript.gamePad.SetMotorSpeeds(2f, 2f);
            yield return new WaitForSeconds(0.3f);
            inputScript.gamePad.SetMotorSpeeds(0, 0);
        }
        
    }
