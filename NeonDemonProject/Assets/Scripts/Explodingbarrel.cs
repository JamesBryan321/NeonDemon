using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodingbarrel : MonoBehaviour
{

    public GameObject Barrel;
    public GameObject Explosion;
    public GameObject Explosion2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void explode()
    {
        Barrel.SetActive(false);
        Explosion.SetActive(true);
        Explosion2.SetActive(true);

    }
}
