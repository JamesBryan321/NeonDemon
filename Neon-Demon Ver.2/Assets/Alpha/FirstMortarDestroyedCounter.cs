using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMortarDestroyedCounter : MonoBehaviour
{
    public int numberOfMortarsDestroyed = 0;
    public bool audioHasPlayed = false;
    public AudioSource audioToTrigger;

    void Update()
    {
        if (numberOfMortarsDestroyed == 1 && audioHasPlayed == false)
        {
            audioHasPlayed = true;
            audioToTrigger.Play();
        }
    }

    public void AddToMortarCount()
    {
        numberOfMortarsDestroyed++;
    }
}
