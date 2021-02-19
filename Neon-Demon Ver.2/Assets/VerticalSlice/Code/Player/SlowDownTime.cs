using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowDownTime : MonoBehaviour
{
    [Header("Slow Time")]
    public GameObject Meter;
    public int MeterAmount = 100;
    public bool devtest;
    private int TimeStop = 1;
    public PauseMenuScript PauseTest;


    /// <summary>
    /// Everything for the reality change 
    /// </summary>
    /// 

    [Header("RealityChange")]
    public GameObject[] CP_asset;
    public GameObject[] Hell_asset;
    public bool realityNormal;
    public GameObject HellVolume;
    public Animator Vignette;



    void Start()
    {
        Meter.GetComponent<Image>().fillAmount = 100;
        realityNormal = false;
    }

    public void OnRealityInput()
    {
        TimeStop = TimeStop * -1;
        WaitForChange();
    }


    void Update()
    {
        if (PauseTest.isPaused == false)
        {
            if (devtest == false)
            {
                if (Meter.GetComponent<Image>().fillAmount > 0 && TimeStop < 0)
                {
                    Meter.GetComponent<Image>().fillAmount -= 0.005f;
                    Time.timeScale = 0.5f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
            else
            {
                if (TimeStop < 0)
                {
                    Time.timeScale = 0.5f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
        }

    }

    public void AddMeter()
    {
        if (Meter.GetComponent<Image>().fillAmount < 100)
        {
            Meter.GetComponent<Image>().fillAmount += 0.5f;
            if (Meter.GetComponent<Image>().fillAmount > 100)
            {
                Meter.GetComponent<Image>().fillAmount = 100;
            }
        }
    }
    private void changeToNormal1()
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


    private void WaitForChange()
    {
       // yield return new WaitForSeconds(0.01f);

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

    }
    private void changeToHell()
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

    }
}
