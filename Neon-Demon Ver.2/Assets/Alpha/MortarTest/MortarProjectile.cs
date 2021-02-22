using System.Collections;
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
    public GameObject Explosion;

    public float Mass = 15;
    public float MaxVelocity = 6;
    public float MaxForce = 20;

    public Vector3 velocity;
    public Vector3 force;

    public Vector3[] Followpositions = new Vector3[80];
    // Start is called before the first frame update
    void Start()
    {
        //LineRef = GameObject.Find("MortarEnemy").GetComponent<MortarEnemy>();
        transform.position =Followpositions[CurrentWaypointID];
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Followpositions[CurrentWaypointID]);
        //transform.position = LineRef.positions[CurrentWaypointID];
        //Debug.Log(CurrentWaypointID);
        if (CurrentWaypointID < 79)
        {
            Debug.Log("TEst");
            //transform.position = Followpositions[CurrentWaypointID];
            Seek();
            if (Vector3.Distance(Followpositions[CurrentWaypointID], this.transform.position) < 1)
            {
                CurrentWaypointID = (CurrentWaypointID + 1);//% LineRef.positions.Length+1;
            }
        }
        else if (CurrentWaypointID >= 79)
        {
            GameObject Bomb = Instantiate(Explosion, this.transform);
            Bomb.transform.parent = null;
            Destroy(gameObject);
        }
    }

    void Seek()
    {

        var desiredVelocity = Followpositions[CurrentWaypointID] - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
    }
}
