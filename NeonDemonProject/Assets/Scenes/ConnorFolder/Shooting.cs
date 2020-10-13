using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public TMP_Text AmmoCount;
    public float Ammo = 12;
    public Camera cam;
    public List<ParticleSystem> ShootingSFX;
    public GameObject impactEffect;
    public Animator Gun_Anim;
    // Start is called before the first frame update
    void Start()
    {
       // Gun_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AmmoCount.text = "" + Ammo;
        //////
        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            Ammo -= 1;
            int randomNum = Random.Range(0, 2);
            Shoot();
            ShootingSFX[randomNum].Emit(1);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Gun_Anim.SetTrigger("Reload");
            Ammo = 12;
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
            Destroy(impactEffectGO, 5);
           
            Debug.Log( hit.collider.gameObject.name);
        }
    }

 

}
