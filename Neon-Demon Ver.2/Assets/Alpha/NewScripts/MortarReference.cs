using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarReference : MonoBehaviour
{

    public GameObject explosion;
    public GameObject robotNormal;
    public GameObject robotDestroyed;
    public GameObject player;

    public FirstMortarDestroyedCounter mortarDestructionScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyRobot()
    {
        explosion.SetActive(true);
        Destroy(gameObject);
        
        robotDestroyed.SetActive(true);
        robotNormal.SetActive(false);
        mortarDestructionScript.AddToMortarCount();
        player.GetComponent<CamShaker>().shakeIt();
        
    }
}
