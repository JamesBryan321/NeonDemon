using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realityBlinkIntro : MonoBehaviour
{
    public GameObject BelialText;
    //public GameObject Trigger_RealityBlinkIntro;

    private void OnTriggerEnter(Collider Player)
    {
        BelialText.SetActive(true);
    }

    private void OnTriggerExit(Collider Player)
    {
        BelialText.SetActive(false);
        //Trigger_RealityBlinkIntro.SetActive(false);
    }
}
