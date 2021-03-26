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


    public TMP_Text AmmoText;
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
    private RaycastHit[] shotgunHitPoint;
    private Ray[] shotgunRay;

    void Start()
    {
        //Ads_anim = GetComponent<Animator>();
       //Cam_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        AmmoText.text = "" + Ammo;
        Ads_anim.SetInteger("AnimAmmo", Ammo); 
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
            Ads_anim.SetTrigger("reload");
            //Ammo = ReloadAmmo;
          //  StartCoroutine(WaitForReload());
        }
      

 
      

    }

    void Shoot()
    {
        if (shotgun)
        {
            ShootShotgun();
            //ShootPistol();
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
            //Instantiate(bulletMarker, hit.point, Quaternion.LookRotation(hit.normal));
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
                hit.transform.GetComponent<Thruster>().Explode();
                //hit.transform.GetComponent<Thruster>().enabled = true;
                foreach (Collider hit1 in colliders)
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
                hit.transform.GetComponent<TakeDamage>().Thrusterdamage();

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
        /*bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        */
        
        //var shotgunRay1 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        //var shotgunRay2 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        //var shotgunRay3 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        //var shotgunRay4 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        //var shotgunRay5 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));

        RaycastHit shotgunHitPoint;
        RaycastHit shotgunHitPoint2;
        RaycastHit shotgunHitPoint3;
        RaycastHit shotgunHitPoint4;
        RaycastHit shotgunHitPoint5;

        //RaycastHit[] hit;
        Ads_anim.SetBool("Shoot", true);
        Reticle.SetTrigger("Shoot");
        
        #region shotgun ray 1
        
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        
        
        var shotgunRay1 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        
        if (Physics.Raycast(shotgunRay1, out shotgunHitPoint, Mathf.Infinity))
            {
                //Instantiate(bulletMarker, shotgunHitPoint.point, Quaternion.LookRotation(shotgunHitPoint.normal));
                GameObject impactEffectGO =
                    Instantiate(impactEffect, shotgunHitPoint.point,
                        Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                Destroy(impactEffectGO, 2);

                StartCoroutine(wait());
                if (shotgunHitPoint.transform.CompareTag("Enemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint.normal.x, shotgunHitPoint.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint.transform.GetComponent<TakeDamage>().Damage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint.transform.CompareTag("BigEnemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint.normal.x, shotgunHitPoint.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint.transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint.transform.CompareTag("Rocket"))
                {

                    shotgunHitPoint.transform.GetComponent<MortarProjectile>().reverse();

                }

                if (shotgunHitPoint.transform.CompareTag("BossCollider"))
                {

                    shotgunHitPoint.transform.GetComponent<BossHealth>().Damage();

                }

                if (shotgunHitPoint.transform.CompareTag("Thruster"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint.normal.x, shotgunHitPoint.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    // settings.LightIntensityMultiplier = DirLight.intensity;
                    StartCoroutine(wait());
                    Debug.Log("hit thruster, BOOOM");


                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                    shotgunHitPoint.transform.GetComponent<TakeDamage>().Thrusterdamage();
                    //hit.transform.GetComponent<Thruster>().enabled = true;
                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }

                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
                }

                if (shotgunHitPoint.transform.CompareTag("Head"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint.normal.x, shotgunHitPoint.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    shotgunHitPoint.transform.GetComponent<Headshot>().BoomHeadshot();
                shotgunHitPoint.transform.GetComponent<TakeDamage>().Thrusterdamage();

                foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }


                    Debug.Log("Boom epic headshot!!!!!!");
                }

                if (shotgunHitPoint.transform.CompareTag("bottle"))
                {
                    var destructableScript = shotgunHitPoint.transform.GetComponent<Destructable>();
                    destructableScript.Break();
                    shotgunHitPoint.transform.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint.transform.CompareTag("barrel"))
                {
                    var barrelScript = shotgunHitPoint.transform.GetComponent<Explodingbarrel>();
                    barrelScript.explode();
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint.transform.CompareTag("Mortar"))
                {

                    shotgunHitPoint.transform.GetComponent<MortarReference>().DestroyRobot();

                }

                if (shotgunHitPoint.transform.CompareTag("Boss"))
                {
                    if (shotgunHitPoint.transform.GetComponent<Boss>().BossVunerable == true)
                    {
                        shotgunHitPoint.transform.GetComponent<Boss>().BossHealth -= 1;
                        shotgunHitPoint.transform.GetComponent<Boss>().BossVunerable = false;
                    }
                }
            
        }
        #endregion
        
        #region shotgun ray 2
        
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        
        
        var shotgunRay2 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        
        if (Physics.Raycast(shotgunRay2, out shotgunHitPoint2, Mathf.Infinity))
            {
                //Instantiate(bulletMarker, shotgunHitPoint2.point, Quaternion.LookRotation(shotgunHitPoint2.normal));
                GameObject impactEffectGO =
                    Instantiate(impactEffect, shotgunHitPoint2.point,
                        Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                Destroy(impactEffectGO, 2);

                StartCoroutine(wait());
                if (shotgunHitPoint2.transform.CompareTag("Enemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint2.normal.x, shotgunHitPoint2.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint2.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint2.transform.GetComponent<TakeDamage>().Damage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint2.transform.CompareTag("BigEnemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint2.normal.x, shotgunHitPoint2.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint2.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint2.transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint2.transform.CompareTag("Rocket"))
                {

                    shotgunHitPoint2.transform.GetComponent<MortarProjectile>().reverse();

                }

                if (shotgunHitPoint2.transform.CompareTag("BossCollider"))
                {

                    shotgunHitPoint2.transform.GetComponent<BossHealth>().Damage();

                }

                if (shotgunHitPoint2.transform.CompareTag("Thruster"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint2.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint2.normal.x, shotgunHitPoint2.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint2.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    // settings.LightIntensityMultiplier = DirLight.intensity;
                    StartCoroutine(wait());
                    Debug.Log("hit thruster, BOOOM");


                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                    shotgunHitPoint2.transform.GetComponent<TakeDamage>().Thrusterdamage();
                    //hit.transform.GetComponent<Thruster>().enabled = true;
                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint2.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }

                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
                }

                if (shotgunHitPoint2.transform.CompareTag("Head"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint2.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint2.normal.x, shotgunHitPoint2.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint2.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    shotgunHitPoint2.transform.GetComponent<Headshot>().BoomHeadshot();
                shotgunHitPoint2.transform.GetComponent<TakeDamage>().Thrusterdamage();
                foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint2.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }


                    Debug.Log("Boom epic headshot!!!!!!");
                }

                if (shotgunHitPoint2.transform.CompareTag("bottle"))
                {
                    var destructableScript = shotgunHitPoint2.transform.GetComponent<Destructable>();
                    destructableScript.Break();
                    shotgunHitPoint2.transform.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint2.transform.CompareTag("barrel"))
                {
                    var barrelScript = shotgunHitPoint2.transform.GetComponent<Explodingbarrel>();
                    barrelScript.explode();
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint2.transform.CompareTag("Mortar"))
                {

                    shotgunHitPoint2.transform.GetComponent<MortarReference>().DestroyRobot();

                }

                if (shotgunHitPoint2.transform.CompareTag("Boss"))
                {
                    if (shotgunHitPoint2.transform.GetComponent<Boss>().BossVunerable == true)
                    {
                        shotgunHitPoint2.transform.GetComponent<Boss>().BossHealth -= 1;
                        shotgunHitPoint2.transform.GetComponent<Boss>().BossVunerable = false;
                    }
                }
            
        }
        #endregion
        
        #region shotgun ray 3
        
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        
        
        var shotgunRay3 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        
        if (Physics.Raycast(shotgunRay3, out shotgunHitPoint3, Mathf.Infinity))
            {
                //Instantiate(bulletMarker, shotgunHitPoint3.point, Quaternion.LookRotation(shotgunHitPoint3.normal));
                GameObject impactEffectGO =
                    Instantiate(impactEffect, shotgunHitPoint3.point,
                        Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                Destroy(impactEffectGO, 2);

                StartCoroutine(wait());
                if (shotgunHitPoint3.transform.CompareTag("Enemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint3.normal.x, shotgunHitPoint3.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint3.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint3.transform.GetComponent<TakeDamage>().Damage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint3.transform.CompareTag("BigEnemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint3.normal.x, shotgunHitPoint3.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint3.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint3.transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint3.transform.CompareTag("Rocket"))
                {

                    shotgunHitPoint3.transform.GetComponent<MortarProjectile>().reverse();

                }

                if (shotgunHitPoint3.transform.CompareTag("BossCollider"))
                {

                    shotgunHitPoint3.transform.GetComponent<BossHealth>().Damage();

                }

                if (shotgunHitPoint3.transform.CompareTag("Thruster"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint3.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint3.normal.x, shotgunHitPoint3.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint3.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    // settings.LightIntensityMultiplier = DirLight.intensity;
                    StartCoroutine(wait());
                    Debug.Log("hit thruster, BOOOM");


                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                    shotgunHitPoint3.transform.GetComponent<TakeDamage>().Thrusterdamage();
                    //hit.transform.GetComponent<Thruster>().enabled = true;
                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint3.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }

                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
                }

                if (shotgunHitPoint3.transform.CompareTag("Head"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint3.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint3.normal.x, shotgunHitPoint3.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint3.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    shotgunHitPoint3.transform.GetComponent<Headshot>().BoomHeadshot();
                shotgunHitPoint3.transform.GetComponent<TakeDamage>().Thrusterdamage();

                foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint3.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }


                    Debug.Log("Boom epic headshot!!!!!!");
                }

                if (shotgunHitPoint3.transform.CompareTag("bottle"))
                {
                    var destructableScript = shotgunHitPoint3.transform.GetComponent<Destructable>();
                    destructableScript.Break();
                    shotgunHitPoint3.transform.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint3.transform.CompareTag("barrel"))
                {
                    var barrelScript = shotgunHitPoint3.transform.GetComponent<Explodingbarrel>();
                    barrelScript.explode();
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint3.transform.CompareTag("Mortar"))
                {

                    shotgunHitPoint3.transform.GetComponent<MortarReference>().DestroyRobot();

                }

                if (shotgunHitPoint3.transform.CompareTag("Boss"))
                {
                    if (shotgunHitPoint3.transform.GetComponent<Boss>().BossVunerable == true)
                    {
                        shotgunHitPoint3.transform.GetComponent<Boss>().BossHealth -= 1;
                        shotgunHitPoint3.transform.GetComponent<Boss>().BossVunerable = false;
                    }
                }
            
        }
        #endregion
        
        #region shotgun ray 4
        
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        
        
        var shotgunRay4 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        
        if (Physics.Raycast(shotgunRay4, out shotgunHitPoint4, Mathf.Infinity))
            {
                //Instantiate(bulletMarker, shotgunHitPoint4.point, Quaternion.LookRotation(shotgunHitPoint4.normal));
                GameObject impactEffectGO =
                    Instantiate(impactEffect, shotgunHitPoint4.point,
                        Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                Destroy(impactEffectGO, 2);

                StartCoroutine(wait());
                if (shotgunHitPoint4.transform.CompareTag("Enemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint4.normal.x, shotgunHitPoint4.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint4.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint4.transform.GetComponent<TakeDamage>().Damage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint4.transform.CompareTag("BigEnemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint4.normal.x, shotgunHitPoint4.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint4.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint4.transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint4.transform.CompareTag("Rocket"))
                {

                    shotgunHitPoint4.transform.GetComponent<MortarProjectile>().reverse();

                }

                if (shotgunHitPoint4.transform.CompareTag("BossCollider"))
                {

                    shotgunHitPoint4.transform.GetComponent<BossHealth>().Damage();

                }

                if (shotgunHitPoint4.transform.CompareTag("Thruster"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint4.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint4.normal.x, shotgunHitPoint4.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint4.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    // settings.LightIntensityMultiplier = DirLight.intensity;
                    StartCoroutine(wait());
                    Debug.Log("hit thruster, BOOOM");


                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                    shotgunHitPoint4.transform.GetComponent<TakeDamage>().Thrusterdamage();
                    //hit.transform.GetComponent<Thruster>().enabled = true;
                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint4.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }

                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
                }

                if (shotgunHitPoint4.transform.CompareTag("Head"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint4.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint4.normal.x, shotgunHitPoint4.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint4.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    shotgunHitPoint4.transform.GetComponent<Headshot>().BoomHeadshot();
                shotgunHitPoint4.transform.GetComponent<TakeDamage>().Thrusterdamage();
                foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint4.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }


                    Debug.Log("Boom epic headshot!!!!!!");
                }

                if (shotgunHitPoint4.transform.CompareTag("bottle"))
                {
                    var destructableScript = shotgunHitPoint4.transform.GetComponent<Destructable>();
                    destructableScript.Break();
                    shotgunHitPoint4.transform.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint4.transform.CompareTag("barrel"))
                {
                    var barrelScript = shotgunHitPoint4.transform.GetComponent<Explodingbarrel>();
                    barrelScript.explode();
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint4.transform.CompareTag("Mortar"))
                {

                    shotgunHitPoint4.transform.GetComponent<MortarReference>().DestroyRobot();

                }

                if (shotgunHitPoint4.transform.CompareTag("Boss"))
                {
                    if (shotgunHitPoint4.transform.GetComponent<Boss>().BossVunerable == true)
                    {
                        shotgunHitPoint4.transform.GetComponent<Boss>().BossHealth -= 1;
                        shotgunHitPoint4.transform.GetComponent<Boss>().BossVunerable = false;
                    }
                }
            
        }
        #endregion
        
        #region shotgun ray 5
        
        bulletXOffset = Random.Range(-bulletSpread, bulletSpread);
        bulletYOffset = Random.Range(-bulletSpread, bulletSpread);
        
        
        var shotgunRay5 = cam.ViewportPointToRay(new Vector3(0.5F + bulletXOffset, 0.5F + bulletYOffset, 0));
        
        if (Physics.Raycast(shotgunRay5, out shotgunHitPoint5, Mathf.Infinity))
            {
                //Instantiate(bulletMarker, shotgunHitPoint5.point, Quaternion.LookRotation(shotgunHitPoint5.normal));
                GameObject impactEffectGO =
                    Instantiate(impactEffect, shotgunHitPoint5.point,
                        Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
                Destroy(impactEffectGO, 2);

                StartCoroutine(wait());
                if (shotgunHitPoint5.transform.CompareTag("Enemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint5.normal.x, shotgunHitPoint5.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint5.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint5.transform.GetComponent<TakeDamage>().Damage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint5.transform.CompareTag("BigEnemy"))
                {
                    float angle = Mathf.Atan2(shotgunHitPoint5.normal.x, shotgunHitPoint5.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint5.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;
                    //  settings.LightIntensityMultiplier = DirLight.intensity;
                    shotgunHitPoint5.transform.GetComponent<TakeDamage>().bigGuyDamage(damage);
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint5.transform.CompareTag("Rocket"))
                {

                    shotgunHitPoint5.transform.GetComponent<MortarProjectile>().reverse();

                }

                if (shotgunHitPoint5.transform.CompareTag("BossCollider"))
                {

                    shotgunHitPoint5.transform.GetComponent<BossHealth>().Damage();

                }

                if (shotgunHitPoint5.transform.CompareTag("Thruster"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint5.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint5.normal.x, shotgunHitPoint5.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint5.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    // settings.LightIntensityMultiplier = DirLight.intensity;
                    StartCoroutine(wait());
                    Debug.Log("hit thruster, BOOOM");


                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyOn();



                    shotgunHitPoint5.transform.GetComponent<TakeDamage>().Thrusterdamage();
                    //hit.transform.GetComponent<Thruster>().enabled = true;
                    foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint5.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }

                    //hit.transform.GetComponent<EnemyTornApart>().TurnEnemyoff();
                }

                if (shotgunHitPoint5.transform.CompareTag("Head"))
                {
                    Collider[] colliders = Physics.OverlapSphere(shotgunHitPoint5.transform.position, 5f);
                    float angle = Mathf.Atan2(shotgunHitPoint5.normal.x, shotgunHitPoint5.normal.z) * Mathf.Rad2Deg + 180;
                    int randomblood = Random.Range(0, BloodFX.Count);
                    var instance = (Instantiate(BloodFX[randomblood], shotgunHitPoint5.point, Quaternion.Euler(0, angle + 90, 0)));
                    var settings = instance.GetComponent<BFX_BloodSettings>();
                    settings.FreezeDecalDisappearance = true;

                    shotgunHitPoint5.transform.GetComponent<Headshot>().BoomHeadshot();
                shotgunHitPoint5.transform.GetComponent<TakeDamage>().Thrusterdamage();

                foreach (Collider hit1 in colliders)
                    {
                        Rigidbody rib = hit1.GetComponent<Rigidbody>();
                        if (rib != null)
                        {
                            rib.AddExplosionForce(100f, shotgunHitPoint5.transform.position, 100f, 1f, ForceMode.Impulse);

                        }
                    }


                    Debug.Log("Boom epic headshot!!!!!!");
                }

                if (shotgunHitPoint5.transform.CompareTag("bottle"))
                {
                    var destructableScript = shotgunHitPoint5.transform.GetComponent<Destructable>();
                    destructableScript.Break();
                    shotgunHitPoint5.transform.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint5.transform.CompareTag("barrel"))
                {
                    var barrelScript = shotgunHitPoint5.transform.GetComponent<Explodingbarrel>();
                    barrelScript.explode();
                    StartCoroutine(wait());
                }

                if (shotgunHitPoint5.transform.CompareTag("Mortar"))
                {

                    shotgunHitPoint5.transform.GetComponent<MortarReference>().DestroyRobot();

                }

                if (shotgunHitPoint5.transform.CompareTag("Boss"))
                {
                    if (shotgunHitPoint5.transform.GetComponent<Boss>().BossVunerable == true)
                    {
                        shotgunHitPoint5.transform.GetComponent<Boss>().BossHealth -= 1;
                        shotgunHitPoint5.transform.GetComponent<Boss>().BossVunerable = false;
                    }
                }
            
        }
        #endregion

        StartCoroutine(wait());
    }

    public void ReloadBullets()
    {
        Ammo = ReloadAmmo;
    }
    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(2);
        Ammo = ReloadAmmo;

       
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
        //StartCoroutine(WaitForReload());
        // Ads_anim.enabled = true;
        //Ads_anim.SetBool("Reload", true);
        Ads_anim.SetTrigger("reload");
        //StartCoroutine(WaitForReload());
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
