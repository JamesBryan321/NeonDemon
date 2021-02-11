using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowDownTime : MonoBehaviour
{
    public GameObject Meter;
    public int MeterAmount = 100;
    public bool devtest;
    private int TimeStop = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Meter.GetComponent<Slider>().value = MeterAmount;
        Meter.GetComponent<Image>().fillAmount = 100;
    }

    public void OnRealityInput()
    {
        TimeStop = TimeStop * -1;
   
    }


    // Update is called once per frame
    void Update()
    {
        if (devtest == false)
        {
            if (Meter.GetComponent<Image>().fillAmount > 0 && TimeStop < 0)
            {
                Meter.GetComponent<Image>().fillAmount -= 0.005f;
                //TimeRef.DoSlowmotion();
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

    public void AddMeter()
    {
        if (Meter.GetComponent<Image>().fillAmount < 100)
        {
            Meter.GetComponent<Image>().fillAmount += 0.5f;
            if(Meter.GetComponent<Image>().fillAmount > 100)
            {
                Meter.GetComponent<Image>().fillAmount = 100;
            }
        }
    }
}
