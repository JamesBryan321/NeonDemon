﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverSFX : MonoBehaviour
{

    [Header("SFX")]
    public AudioSource Click;
    public AudioSource ReloadSFX;
    public Shooting GunRef;
    public GameObject Cartridge;
    public Transform SpawnCartridgePos;

    public Animator RevAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevolverClick()
    {
        Click.Play();
    }

    public void Reload()
    {
        ReloadSFX.Play();
    }

    public void SpawnCartridge()
    {
        Instantiate(Cartridge, SpawnCartridgePos);
    }

    public void ReloadBullets()
    {
        RevAnim.ResetTrigger("reload");
        GunRef.Ammo = GunRef.ReloadAmmo;
    }

    public void ResetBullets()
    {
        GunRef.Ammo = 0;
    }
}
