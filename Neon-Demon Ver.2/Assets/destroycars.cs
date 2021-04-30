using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroycars : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Destroy(destroy);
            Debug.Log("destroyed");
        }

    }
}