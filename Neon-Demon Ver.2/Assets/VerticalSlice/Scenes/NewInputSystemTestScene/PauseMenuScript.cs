using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu;

    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;

    public InputController inputController;

    public bool ispaused;

    public void TogglePauseMenu()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            ispaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);

            //GetComponent<InputController>().enabled = false;
            inputController.DisableInputs();
        }
        else
        {
            ispaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            optionsMenu.SetActive(false);
            //GetComponent<InputController>().enabled = true;
            inputController.ReEnableInputs();
        }
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }
    
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }
}


