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
        pauseMenu.sortingOrder = 10;
        controlsMenu.sortingOrder = 9;
        pauseMenu.GetComponent<Canvas>().enabled = false;
        controlsMenu.GetComponent<Canvas>().enabled = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenPauseMenu()
    {
        pauseMenu.sortingOrder = 10;
        controlsMenu.sortingOrder = 9;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.GetComponent<Canvas>().enabled = true;
    }
    
    public void ClosePauseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.GetComponent<Canvas>().enabled = false;
    }

    public void OpenControlsMenu()
    {
        pauseMenu.sortingOrder = 10;
        controlsMenu.sortingOrder = 9;
        ClosePauseMenu();
        controlsMenu.GetComponent<Canvas>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
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
