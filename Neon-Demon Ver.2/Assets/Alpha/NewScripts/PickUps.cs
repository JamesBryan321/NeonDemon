using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject Revolver;
    public Animator Gun_Anim;
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
            Revolver.SetActive(true);
            Gun_Anim.SetTrigger("Pickup");
            Destroy(gameObject);
        }
    }

}
