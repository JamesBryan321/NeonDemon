using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunAmmoCounter : MonoBehaviour
{
    public GameObject ShotgunManager;
    public int ShotgunAmmo;

    public GameObject ZeroText;
    public GameObject OneText;
    public GameObject TwoText;
    public GameObject ThreeText;

    // Start is called before the first frame update
    void Start()
    {
        
        Shooting shotgunScript = ShotgunManager.GetComponent<Shooting>();
        ShotgunAmmo = shotgunScript.SAmmo;

        ZeroText.SetActive(false);
        OneText.SetActive(false);
        TwoText.SetActive(false);
        ThreeText.SetActive(false);
    }

    public void AmmoCounter()
    {

        if (ShotgunAmmo == 0)
        {
            ZeroText.SetActive(true);
        }
        else
        {
            ZeroText.SetActive(false);
        }

        if (ShotgunAmmo == 1)
        {
            OneText.SetActive(true);
        }
        else
        {
            OneText.SetActive(false);
        }

        if (ShotgunAmmo == 2)
        {
            TwoText.SetActive(true);
        }
        else
        {
            TwoText.SetActive(false);
        }

        if (ShotgunAmmo == 3)
        {
            ThreeText.SetActive(true);
        }
        else
        {
            ThreeText.SetActive(false);
        }

    }

    void Update()
    {
        Shooting shotgunScript = ShotgunManager.GetComponent<Shooting>();
        ShotgunAmmo = shotgunScript.SAmmo;

        AmmoCounter();
    }
}
