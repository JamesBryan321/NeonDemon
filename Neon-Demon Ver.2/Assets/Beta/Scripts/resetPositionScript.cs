using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPositionScript : MonoBehaviour
{
    public GameObject startPositionObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Car hit.");
        other.transform.position = startPositionObject.transform.position;
    }
}
