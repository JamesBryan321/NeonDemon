using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowers : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player.GetComponent<PlayerHP>().PlayerHealth -= 0.01f;
        }

    }
}
