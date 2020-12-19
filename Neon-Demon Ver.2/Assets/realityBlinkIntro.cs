using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realityBlinkIntro : MonoBehaviour
{
    public GameObject BelialText;
    
    private void Start()
    {
        BelialText.SetActive(false);
    }

    private void OnTriggerEnter(Collider Player)
    {
        BelialText.SetActive(true);
    }

    private void OnTriggerExit(Collider Player)
    {
        BelialText.SetActive(false);
    }
}
