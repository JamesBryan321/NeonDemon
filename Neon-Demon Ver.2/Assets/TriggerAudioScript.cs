using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioScript : MonoBehaviour
{
    public AudioSource audioToTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioToTrigger.Play();
            Destroy(this.gameObject);
        }
    }
}
