using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject Destroyedversion;
    public GameObject Rock;
    /*public GameObject Canvas;
    public GameObject scorePrefab;
    public GameObject comboScore;
    public AudioSource audioData;
    */


    private void Start()
    {
        //audioData = GetComponent<AudioSource>();

       // Break();

    }

    public void Break()
    {
        Debug.Log("Rock");
        Destroyedversion.transform.localScale = new Vector3(this.transform.localScale.x, 
            this.transform.localScale.y, this.transform.localScale.z);
        Instantiate(Destroyedversion, transform.position, transform.rotation);
       // audioData.Play(0);
       
        Rock.SetActive(false);
        Destroy(this.gameObject);

      

    }
}
