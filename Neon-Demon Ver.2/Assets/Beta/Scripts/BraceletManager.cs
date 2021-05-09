using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BraceletManager : MonoBehaviour
{
    public int keyCount = 0;
    public GameObject goToNC;
   // public GameObject goToNC1;


    public GameObject braceletImage1;
    public GameObject braceletImage2;

    public GameObject TextDelete,TextDelete2,TextDelete3;
    // Start is called before the first frame update
    void Start()
    {
        goToNC.SetActive(false);
        //goToNC1.SetActive(false);
        braceletImage1.SetActive(false);
        braceletImage2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            keyCount += 1;
            Destroy(other.gameObject);

            if (keyCount == 1)
            {
                braceletImage1.SetActive(true);
            }
            if (keyCount == 2)
            {
                goToNC.SetActive(true);
                braceletImage2.SetActive(true);
                Destroy(TextDelete);
                Destroy(TextDelete2);
                Destroy(TextDelete3);
            }
        }
        if (other.gameObject.CompareTag("Nightclub") && keyCount >= 2)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Boss");
        }
        if (other.gameObject.CompareTag("Nightclub") && keyCount <= 2)
        {
            //   goToNC1.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Nightclub") && keyCount <= 2)
        {
            //  goToNC1.SetActive(false);
        }
    }
}
