using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapping : MonoBehaviour
{
    public int selectedWeapon = 0;

    private Shooting shootingScript;

    public GameObject ReticleRevolver;
    public GameObject ShotgunReticle;



    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    public void WeaponSwitchInput()
    {
        int previousSlecetedWeapon = selectedWeapon;

        if (selectedWeapon >= transform.childCount - 1)
        {
            selectedWeapon = 0;
        }
        else
        {
            selectedWeapon++;
        }

        if (previousSlecetedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousSlecetedWeapon = selectedWeapon;

        if (previousSlecetedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        if(selectedWeapon == 0)
        {
            ReticleRevolver.SetActive(true);
            ShotgunReticle.SetActive(false);

        }
        if (selectedWeapon == 1)
        {
            ShotgunReticle.SetActive(true);
            ReticleRevolver.SetActive(false);

        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);

                shootingScript = weapon.gameObject.GetComponent<Shooting>();
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }

    public void ShootCurrentWeapon()
    {
        shootingScript.OnShootInput();
    }
}
