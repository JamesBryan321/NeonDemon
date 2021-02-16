using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelialPathfinding : MonoBehaviour
{

    public float Mass = 15;
    public float MaxVelocity = 6;
    public float MaxForce = 20;

    public Vector3 velocity;
    public Vector3 force;


    public List<Transform> target;
    public int CurrentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }

    void Seek()
    {

        var desiredVelocity = target[CurrentWaypoint].position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
    }

}
