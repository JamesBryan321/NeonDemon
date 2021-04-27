using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorialText : MonoBehaviour
{
    public GameObject BelialText;

    private void Start()
    {
        BelialText.SetActive(false);

        this.gameObject.SetActive(true);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BelialText.SetActive(true);
        }
    }
    */
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BelialText.SetActive(false);

            //this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BelialText.SetActive(true);
        }
    }
}
