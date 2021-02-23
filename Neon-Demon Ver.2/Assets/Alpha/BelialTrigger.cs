using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelialTrigger : MonoBehaviour
{
    public int NextWaypoint;
    private GameObject Belial;
    // Start is called before the first frame update
    void Start()
    {
        Belial = GameObject.Find("BelialOBJ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Belial.GetComponent<BelialPathfinding>().FinalPosition = NextWaypoint;
            Destroy(gameObject);
        }
    }
}
