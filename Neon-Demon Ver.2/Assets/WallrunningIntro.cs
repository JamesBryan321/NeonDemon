using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallrunningIntro : MonoBehaviour
{
    public GameObject BelialText;
    public GameObject Trigger;

    private void Start()
    {
        BelialText.SetActive(false);

        Trigger.SetActive(true);
    }

    private void OnTriggerEnter(Collider Player)
    {
        BelialText.SetActive(true);
    }

    private void OnTriggerExit(Collider Player)
    {
        BelialText.SetActive(false);

        Trigger.SetActive(false);
    }
}
