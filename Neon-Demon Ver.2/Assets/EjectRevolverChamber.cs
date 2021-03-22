using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectRevolverChamber : MonoBehaviour
{
    private Rigidbody ChamberRB;
    private GameObject GunChamberLocation;

    // Start is called before the first frame update
    void Start()
    {
        ChamberRB = this.gameObject.GetComponent<Rigidbody>();
        GunChamberLocation = GameObject.Find("GunChamberLocation");

        ChamberRB.AddForce(this.gameObject.transform.up * 10f);
    }
}
