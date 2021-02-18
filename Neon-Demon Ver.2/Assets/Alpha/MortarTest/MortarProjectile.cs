﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarProjectile : MonoBehaviour
{
    public int CurrentWaypointID = 0;
    public float speed;
    private float reachDistance = 1f;
    //private MortarEnemy LineRef;
    Vector3 last_position;
    Vector3 current_position;
    public GameObject LineRef;

    public Vector3[] Followpositions = new Vector3[300];
    // Start is called before the first frame update
    void Start()
    {
        //LineRef = GameObject.Find("MortarEnemy").GetComponent<MortarEnemy>();
        transform.position =Followpositions[CurrentWaypointID];
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = LineRef.positions[CurrentWaypointID];
        //Debug.Log(CurrentWaypointID);
        if (CurrentWaypointID < 299)
        {
            Debug.Log("TEst");
            transform.position = Followpositions[CurrentWaypointID];
            if (Vector3.Distance(Followpositions[CurrentWaypointID], this.transform.position) < 1)
            {
                CurrentWaypointID = (CurrentWaypointID + 1);//% LineRef.positions.Length+1;
            }
        }
        else if (CurrentWaypointID >= 299)
        {
            Destroy(gameObject);
        }
    }
}
