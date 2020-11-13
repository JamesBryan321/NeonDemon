using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas controlsMenu;

    void Start()
    {
        pauseMenu.GetComponent<Canvas>().enabled = false;
        controlsMenu.GetComponent<Canvas>().enabled = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenPauseMenu()
    {
        pauseMenu.GetComponent<Canvas>().enabled = true;
    }
    
    public void ClosePauseMenu()
    {
        pauseMenu.GetComponent<Canvas>().enabled = false;
    }

    public void OpenControlsMenu()
    {
        ClosePauseMenu();
        controlsMenu.GetComponent<Canvas>().enabled = true;
    }
    
    public void CloseControlsMenu()
    {
        controlsMenu.GetComponent<Canvas>().enabled = false;
        OpenPauseMenu();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/NeonDemonGame");
    }
}
