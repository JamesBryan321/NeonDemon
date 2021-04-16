using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{
    public MainMenuCamera cam;

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
        if(cam.CurrentCamera == 2)
        {
            timeline1.SetActive(true);
        }
        if (cam.CurrentCamera == 3)
        {
            timeline2.SetActive(true);
        }
        if (cam.CurrentCamera == 4)
        {
            timeline3.SetActive(true);
        }
        if (cam.CurrentCamera == 5)
        {
            timeline4.SetActive(true);
        }
        if (cam.CurrentCamera == 6)
        {
            timeline5.SetActive(true);
        }
        if (cam.CurrentCamera == 7)
        {
            timeline6.SetActive(true);
        }
        if (cam.CurrentCamera >=9)
        {
            SceneManager.LoadScene("NewTutorial");
        }
    }
}



