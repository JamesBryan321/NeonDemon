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
    public bool shot = false;
    private bool FirstMortarAction = false;

    public float mortarDamage;



    //SFX

    public AudioSource HitbackRocketSFX;


    public Vector3[] Followpositions = new Vector3[20];
    // Start is called before the first frame update
    void Start()
    {
        //LineRef = GameObject.Find("MortarEnemy").GetComponent<MortarEnemy>();
        transform.position = Followpositions[CurrentWaypointID];
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = LineRef.positions[CurrentWaypointID];
        //Debug.Log(CurrentWaypointID);
        if (CurrentWaypointID < 19)
        {
            transform.LookAt(Followpositions[CurrentWaypointID]);
            //Debug.Log("TEst");
            //transform.position = Followpositions[CurrentWaypointID];
            Seek();
            if (Vector3.Distance(Followpositions[CurrentWaypointID], this.transform.position) < 3 && shot == false)
            {
                CurrentWaypointID = (CurrentWaypointID + 1);//% LineRef.positions.Length+1;
            }
            if (shot == true)
            {
                CurrentWaypointID = 0;
            }
         
        }
        else if (CurrentWaypointID >= 19)
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
    
   public void reverse()
    {
        CurrentWaypointID = (CurrentWaypointID - 1);
        var desiredVelocity = Followpositions[CurrentWaypointID] + transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, -MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position -= velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
        shot = true;
        HitbackRocketSFX.Play();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Mortar") && shot == true)
        {
            collision.gameObject.GetComponent<MortarReference>().DestroyRobot();
            GameObject Bomb = Instantiate(Explosion, this.transform);
            Bomb.transform.parent = null;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player hit with mortar.");
            collision.gameObject.GetComponent<PlayerHP>().PlayerHealth -= mortarDamage;
            collision.gameObject.GetComponent<PlayerHP>().PlayRandomHit();
            GameObject Bomb = Instantiate(Explosion, this.transform);
            Bomb.transform.parent = null;
            Destroy(gameObject);
        }
      
    }
}
