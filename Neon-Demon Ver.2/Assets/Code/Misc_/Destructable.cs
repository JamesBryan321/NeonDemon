using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject Destroyedversion;
    public GameObject Canvas;
    public GameObject scorePrefab;
    public GameObject comboScore;
    public AudioSource audioData;



    private void Start()
    {
        audioData = GetComponent<AudioSource>();

       // Break();

    }

    public void Break()
    {
        Instantiate(Destroyedversion, transform.position, transform.rotation);
        audioData.Play(0);

        Destroy(gameObject);

      

    }
}
