using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{
    public MainMenuCamera cam;
    public GameObject timeline0;

    public GameObject timeline1;
    public GameObject timeline2;
    public GameObject timeline3;
    public GameObject timeline4;
    public GameObject timeline5;
    public GameObject timeline6;





    // Start is called before the first frame update
    void Start()
    {
        timeline1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.CurrentCamera == 1)
        {
            timeline0.SetActive(true);
            timeline1.SetActive(false);

        }
        if (cam.CurrentCamera == 2)
        {
            timeline0.SetActive(false);

            timeline1.SetActive(true);
            timeline2.SetActive(false);

        }
        if (cam.CurrentCamera == 3)
        {
            timeline1.SetActive(false);

            timeline2.SetActive(true);
            timeline3.SetActive(false);


        }
        if (cam.CurrentCamera == 4)
        {
            timeline2.SetActive(false);

            timeline3.SetActive(true);
            timeline4.SetActive(false);

        }
        if (cam.CurrentCamera == 5)
        {
            timeline3.SetActive(false);

            timeline4.SetActive(true);
            timeline5.SetActive(false);

        }
        if (cam.CurrentCamera == 6)
        {
            timeline4.SetActive(false);

            timeline5.SetActive(true);
            timeline6.SetActive(false);


        }
        if (cam.CurrentCamera == 7)
        {
            timeline5.SetActive(false);

            timeline6.SetActive(true);


        }
        if (cam.CurrentCamera >=9)
        {
            PlayerPrefs.SetInt("comicProgress", 1);
            SceneManager.LoadScene("NewTutorial");
        }
    }
}



