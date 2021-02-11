﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = -transform.right * 10f;
    }
}
