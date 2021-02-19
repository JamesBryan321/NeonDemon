using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityChange : MonoBehaviour
{
    public GameObject[] CP_asset;
    public GameObject[] Hell_asset;
    public bool realityNormal;
   // public GameObject HellVolume;
    public Animator Vignette;

    // Start is called before the first frame update
    void Start()
    {
      realityNormal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            //Vignette.SetTrigger("vigstart");
          //  StartCoroutine(WaitForChange());
        }

     
        

            // Ammo = ReloadAmmo;
        
    }


    public void changeToHell()
    {
        
       // HellVolume.SetActive(true);
        foreach (var asset in Hell_asset)
        {
           
                asset.SetActive(true);
              
            
        }
        foreach (var name in CP_asset)
        {


            name.SetActive(false);

        }
        realityNormal = false;

        /* if(CP_asset[].activeSelf == true)
         {
             Hell_asset[].SetActive(true);
             CP_asset[].SetActive(false);
         }
       else if(Hell_asset[].activeSelf == true)
         {
             Hell_asset[].SetActive(false);
             CP_asset[].SetActive(true);
         }*/

    }
    public void changeToNormal1()
    {
        //HellVolume.SetActive(false);
        foreach (var name in CP_asset)
        {

            
            name.SetActive(true);

        }

        foreach (var name in Hell_asset)
        {

            name.SetActive(false);


        }
        realityNormal = true;
    }


   /* private IEnumerator WaitForChange()
    {
      //  yield return new WaitForSeconds(0.01f);

        if (realityNormal == true)
        {
            changeToHell();
            realityNormal = false;
        }
        else if (realityNormal == false)
        {
            changeToNormal1();
            realityNormal = true;
        }

    }*/


    /* public IEnumerator WaitForAnimation()
     {
         yield return new WaitForSeconds(1.5f);
         changeToHell();
     }*/


}
