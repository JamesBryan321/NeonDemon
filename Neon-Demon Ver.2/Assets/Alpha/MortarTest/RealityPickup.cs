using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealityPickup : MonoBehaviour
{
    //public SlowDownTime TimeRef;
    public GameObject TimeRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TimeRef.GetComponent<Image>().fillAmount < 100)
            {
                TimeRef.GetComponent<Image>().fillAmount += 50;
                Destroy(this.gameObject);
            }
        }
    }

}
