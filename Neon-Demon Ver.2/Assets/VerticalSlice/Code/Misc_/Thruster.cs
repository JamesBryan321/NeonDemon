using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public float thrust = 10.0f;
    public Rigidbody rb;
    public ParticleSystem explodingeffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }


    public void Explode()
    {
        explodingeffect.Play();
    }
}
