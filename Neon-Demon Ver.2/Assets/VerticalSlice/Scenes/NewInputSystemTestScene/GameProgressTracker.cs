using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressTracker : MonoBehaviour
{
    public bool comicComplete, tutorialComplete, mainLevelComplete, bossComplete;

    void Start()
    {
        if (PlayerPrefs.GetInt("comicProgress") == 1)
        {
            comicComplete = true;
        }

        if (PlayerPrefs.GetInt("tutorialProgress") == 1)
        {
            tutorialComplete = true;
        }

        if (PlayerPrefs.GetInt("mainLevelProgress") == 1)
        {
            mainLevelComplete = true;
        }

        if (PlayerPrefs.GetInt("bossProgress") == 1)
        {
            bossComplete = true;
        }
    }


    void Update()
    {
        /*if (PlayerPrefs.GetInt("comicProgress") == 1)
        {
            comicComplete = true;
        }
        if (PlayerPrefs.GetInt("tutorialProgress") == 1)
        {
            tutorialComplete = true;
        }
        if (PlayerPrefs.GetInt("mainLevelProgress") == 1)
        {
            mainLevelComplete = true;
        }
        if (PlayerPrefs.GetInt("bossProgress") == 1)
        {
            bossComplete = true;
        }*/
    }
}
