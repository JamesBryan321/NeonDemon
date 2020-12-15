using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponManager;
    public Canvas playerCanvas;

    public GameObject arms;

    // Start is called before the first frame update
    void Start()
    {
        playerCanvas.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            weaponManager.SetActive(true);
            arms.SetActive(true);
            playerCanvas.enabled = true;
        }
    }
}
