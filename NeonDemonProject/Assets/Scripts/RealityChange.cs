﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityChange : MonoBehaviour
{
    public GameObject CP_asset;
    public GameObject Hell_asset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) changeToHell();
    }


    public void changeToHell()
    {
        if(CP_asset.activeSelf == true)
        {
            Hell_asset.SetActive(true);
            CP_asset.SetActive(false);
        }
      else if(Hell_asset.activeSelf == true)
        {
            Hell_asset.SetActive(false);
            CP_asset.SetActive(true);
        }
    }
}
