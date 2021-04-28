using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverAmmoCounter : MonoBehaviour
{
    public GameObject RevolverManager;
    public int RevolverAmmo;

    public GameObject ZeroText;
    public GameObject OneText;
    public GameObject TwoText;
    public GameObject ThreeText;
    public GameObject FourText;
    public GameObject FiveText;
    public GameObject SixText;

    public Animator RevolverBackgroundAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
        Shooting revolverScript = RevolverManager.GetComponent<Shooting>();
        RevolverAmmo = revolverScript.Ammo;

        ZeroText.SetActive(false);
        OneText.SetActive(false);
        TwoText.SetActive(false);
        ThreeText.SetActive(false);
        FourText.SetActive(false);
        FiveText.SetActive(false);
        SixText.SetActive(false);

        RevolverBackgroundAnimator = this.GetComponent<Animator>();
    }

    public void AmmoCounter()
    {

        if (RevolverAmmo == 0)
        {
            ZeroText.SetActive(true);
            SixText.SetActive(false);
        }
        else
        {
            ZeroText.SetActive(false);
        }

        if (RevolverAmmo == 1)
        {
            OneText.SetActive(true);
        }
        else
        {
            OneText.SetActive(false);
        }

        if (RevolverAmmo == 2)
        {
            TwoText.SetActive(true);
        }
        else
        {
            TwoText.SetActive(false);
        }

        if (RevolverAmmo == 3)
        {
            ThreeText.SetActive(true);
        }
        else
        {
            ThreeText.SetActive(false);
        }

        if (RevolverAmmo == 4)
        {
            FourText.SetActive(true);
        }
        else
        {
            FourText.SetActive(false);
        }

        if (RevolverAmmo == 5)
        {
            FiveText.SetActive(true);
        }
        else
        {
            FiveText.SetActive(false);
        }

        if (RevolverAmmo == 6)
        {
            SixText.SetActive(true);
            ZeroText.SetActive(false);
        }
        else if (RevolverAmmo < 6)
        {
            SixText.SetActive(false);
        }
    }

    public void FiredShot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RevolverBackgroundAnimator.SetBool("ShotFired",true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            RevolverBackgroundAnimator.SetBool("ShotFired", false);
        }
    }

    void Update()
    {
        GameObject RevolverManager = GameObject.Find("RevolverMain");
        Shooting revolverScript = RevolverManager.GetComponent<Shooting>();
        RevolverAmmo = revolverScript.Ammo;

        AmmoCounter();

        FiredShot();
    }
}
