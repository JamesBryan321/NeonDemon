using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class TutorialScript : MonoBehaviour
{
    public TMP_Text welcomeMessage;
    public  TMP_Text continueText;
    
    public Image welcomeBackground;

    public PlayerMove pMScript;
    
    // Start is called before the first frame update
    void Start()
    {
        pMScript.gamePaused = true;
        welcomeMessage.enabled = true;
        welcomeBackground.enabled = true;
        EnableContinueButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && welcomeMessage.enabled)
        {
            welcomeMessage.enabled = false;
            welcomeBackground.enabled = false;
            DisableContinueButton();
            pMScript.gamePaused = false;
        }
    }

    void EnableContinueButton()
    {
        continueText.enabled = true;
    }

    void DisableContinueButton()
    {
        continueText.enabled = false;
    }
}
