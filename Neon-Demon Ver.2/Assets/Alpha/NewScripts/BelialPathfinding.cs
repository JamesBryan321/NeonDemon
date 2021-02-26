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
    private GameObject Player;
    public int FinalPosition;
    public List<Transform> target;
    public int CurrentWaypoint;
    public float speed = 10f;
    public GameObject BelialLook;
    public GameObject Questionmark;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

   public void testbelial()
    {
        CurrentWaypoint++;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurrentWaypoint < FinalPosition)
        {
            transform.LookAt(target[CurrentWaypoint]);
            if (Vector3.Distance(target[CurrentWaypoint].position, this.transform.position) < 1)
            {
                //this.transform.position = target[CurrentWaypoint].position;
                CurrentWaypoint = (CurrentWaypoint + 1);
            }
            else
            {
                Questionmark.SetActive(false);
                Seek();
            }
        }
        else
        {
            Questionmark.SetActive(true);
            this.transform.position = target[CurrentWaypoint - 1].position;
            BelialLook.transform.LookAt(Player.transform);
            //transform.LookAt(Player.transform);
            //transform.rotation = Quaternion.Lerp(this.transform.rotation, Player.transform.rotation, Time.deltaTime * speed);
        }
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
