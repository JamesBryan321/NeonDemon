using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu;

    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;

    public InputController inputController;

    public bool isPaused;

    public Image playerAimReticle;
    public Slider reticleColourSlider;
    public Renderer reticleRenderer;

    public void TogglePauseMenu()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);

            //GetComponent<InputController>().enabled = false;
            inputController.DisableInputs();
        }
        else
        {
            isPaused = false;
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

    public void ChangeReticleColour()
    {
        //reticleRenderer.material.color = Color.HSVToRGB(reticleColourSlider.value * 10, 100, 100);
        playerAimReticle.color = Color.HSVToRGB(reticleColourSlider.value / 10, 100, 100);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }

    public void SetBossLevelComplete()
    {
        PlayerPrefs.SetInt("bossLevelComplete", 1);
    }
}


