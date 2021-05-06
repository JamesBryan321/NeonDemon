using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressTracker : MonoBehaviour
{
    public bool comicComplete, tutorialComplete, mainLevelComplete, bossComplete;

    public GameObject tutorialButton, mainLevelButton, bossLevelButton;

    public GameObject backButton0, backButton1, backButton2, backButton3;

    public bool allLevelsUnlocked;

    void Start()
    {
        if (allLevelsUnlocked)
        {
            PlayerPrefs.SetInt("comicProgress", 1);
            PlayerPrefs.SetInt("tutorialProgress", 1);
            PlayerPrefs.SetInt("mainLevelProgress", 1);
            PlayerPrefs.SetInt("bossProgress", 1);
        }
        
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
        if (!comicComplete)
        {
            tutorialButton.SetActive(false);
            PlayerPrefs.SetInt("comicProgress", 0);
        }

        if (!tutorialComplete)
        {
            mainLevelButton.SetActive(false);
            PlayerPrefs.SetInt("tutorialProgress", 0);
        }

        if (!mainLevelComplete)
        {
            bossLevelButton.SetActive(false);
            PlayerPrefs.SetInt("mainLevelProgress", 0);
        }
        
        if (comicComplete)
        {
            tutorialButton.SetActive(true);
        }

        if (tutorialComplete)
        {
            mainLevelButton.SetActive(true);
        }

        if (mainLevelComplete)
        {
            bossLevelButton.SetActive(true);
        }

        if (tutorialButton.activeInHierarchy == false && mainLevelButton.activeInHierarchy == false 
                                                      && bossLevelButton.activeInHierarchy == false)
        {
            backButton0.SetActive(true);
            backButton1.SetActive(false);
            backButton2.SetActive(false);
            backButton3.SetActive(false);
        }
        
        if (tutorialButton.activeInHierarchy == true && mainLevelButton.activeInHierarchy == false 
                                                      && bossLevelButton.activeInHierarchy == false)
        {
            backButton0.SetActive(false);
            backButton1.SetActive(true);
            backButton2.SetActive(false);
            backButton3.SetActive(false);
        }
        
        if (tutorialButton.activeInHierarchy == true && mainLevelButton.activeInHierarchy == true 
                                                     && bossLevelButton.activeInHierarchy == false)
        {
            backButton0.SetActive(false);
            backButton1.SetActive(false);
            backButton2.SetActive(true);
            backButton3.SetActive(false);
        }
        
        if (tutorialButton.activeInHierarchy == true && mainLevelButton.activeInHierarchy == true 
                                                     && bossLevelButton.activeInHierarchy == true)
        {
            backButton0.SetActive(false);
            backButton1.SetActive(false);
            backButton2.SetActive(false);
            backButton3.SetActive(true);
        }
    }

    public void ClearLevelProgress()
    {
        PlayerPrefs.SetInt("comicProgress", 0);
        PlayerPrefs.SetInt("tutorialProgress", 0);
        PlayerPrefs.SetInt("mainLevelProgress", 0);
        PlayerPrefs.SetInt("bossProgress", 0);
    }
}
