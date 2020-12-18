using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    void LoadComicIntro()
    {
        SceneManager.LoadScene("ComicScene");
    }
    
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
    void LoadMainLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
