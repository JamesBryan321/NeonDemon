using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Diagnostics;
//using System.Diagnostics;

public class Shooting : MonoBehaviour
{
    [Header("Gun Stats")]
    public TMP_Text AmmoCount;
    public float damage = 25;
    public float Ammo;
    public float ReloadAmmo;
    public float Firerate = 1f;
    public float nextFire = 0f;
    public Transform FirePoint;
    public float BulletSpeed;

    [Header("Particle Effects")]
    public GameObject projectile;
    public List<ParticleSystem> ShootingSFX;
    public ParticleSystem Muzzleflash;
    public GameObject impactEffect;

    [Header("Extras")]
    public TImeManager timeManager;
    public Camera cam;
    public Animator Gun_Anim;
    public Animator Cam_Anim;
    public Animator Ads_anim;

    //private IEnumerator WaitForReload;


    // Start is called before the first frame update
    void Start()
    {
        Ads_anim = GetComponent<Animator>();
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
            //Gun_Anim.SetTrigger("Shoot");
            Ammo -= 1;
            int randomNum = Random.Range(0, 2);
            Shoot();
            ShootingSFX[randomNum].Emit(1);
        }
        if (Input.GetMouseButton(1))
        {
            Ads_anim.SetBool("Ads", true);


        } else {
            Ads_anim.SetBool("Ads", false);
        }
        if (Input./*GetMouseButtonDown*/ GetKeyDown(KeyCode.R))
        {
            Ads_anim.SetBool("Reload", true);

         StartCoroutine(WaitForReload());
           // Ammo = ReloadAmmo;
        }
      

        else
        {
           
        }

    }
    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        GameObject bullet = Instantiate(projectile, FirePoint.position, FirePoint.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.right * BulletSpeed);
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
            if (hit.transform.CompareTag("barrel"))
            {
                var barrelScript = hit.transform.GetComponent<Explodingbarrel>();
                barrelScript.explode();
            }
            if (hit.transform.CompareTag("Twitter"))
            {
                OpenTwitter();
            }


        }
    }

    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(1);
        Ammo = ReloadAmmo;
        Ads_anim.SetBool("Reload", false);
    }
    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/NeonDemonGame");
    }


}
