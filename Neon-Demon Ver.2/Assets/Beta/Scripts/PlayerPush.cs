using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{

    public Rigidbody player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("push"))
        {
            player.useGravity = false;
            player.mass = 0.1f;
            player.AddForce(transform.up *1.7f);
          
        }
        else
        {
            player.useGravity = true;
            player.mass = 0.92f;
        }
    }
}
