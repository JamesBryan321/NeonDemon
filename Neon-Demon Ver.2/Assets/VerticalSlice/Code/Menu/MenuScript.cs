using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas controlsMenu;

    public GameObject pauseMenuObject;

    public bool gamePaused;

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
        gamePaused = true;
        Time.timeScale = 0;
        pauseMenuObject.SetActive(true);
        pauseMenu.sortingOrder = 10;
        controlsMenu.sortingOrder = 9;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.GetComponent<Canvas>().enabled = true;
    }
    
    public void ClosePauseMenu()
    {
       
        gamePaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.GetComponent<Canvas>().enabled = false;
        pauseMenuObject.SetActive(false);
    }

    public void OpenControlsMenu()
    {
        gamePaused = true;
        pauseMenu.sortingOrder = 10;
        controlsMenu.sortingOrder = 9;
        controlsMenu.GetComponent<Canvas>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void CloseControlsMenu()
    {
        controlsMenu.GetComponent<Canvas>().enabled = false;
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
