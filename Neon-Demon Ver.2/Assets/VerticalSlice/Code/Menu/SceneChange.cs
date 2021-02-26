using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void LoadComicIntro()
    {
        SceneManager.LoadScene("ComicScene");
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadTutorial()
    {
        SceneManager.LoadScene("NewTutorial");
    }
    
    public void LoadMainLevel()
    {
        SceneManager.LoadScene("NewTutorial");
    }
}
