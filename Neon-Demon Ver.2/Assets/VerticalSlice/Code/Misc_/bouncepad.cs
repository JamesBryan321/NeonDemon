using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncepad : MonoBehaviour
{
    public int speed;
    
       


    void start()
    {
  
    }

    void OnCollisionEnter(Collision other)
    {
       /* if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterController>().Vector3.Lerp*(speed);



            //movement.Jump(Vector3.up, 1f);
        }*/
    }
}
