using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSFX : MonoBehaviour
{
    [Header("SFX")]
    public AudioSource Click;
    public AudioSource ReloadSFX;
    public AudioSource Click2;
    public AudioSource BarrelLoad;
    public Shooting GunRef;

    public AudioSource power;

    public GameObject Cartridge;
    public Transform SpawnCartridgePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShotgunClick()
    {
        Click.Play();
    }
    public void BarrelClick()
    {
        BarrelLoad.Play();
    }
    public void ShotgunClick2()
    {
        Click2.Play();
    }
    public void ShotgunPower()
    {
        power.Play();
    }

    public void Reload()
    {
        ReloadSFX.Play();
    }

    public void SpawnCartridge()
    {
        //Instantiate(Cartridge, SpawnCartridgePos);
    }
    public void ReloadBullets()
    {
        GunRef.Ammo = GunRef.ReloadAmmo;
    }
}
