using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public TMP_Text welcomeMessage;
    public  TMP_Text continueText;
    
    // Start is called before the first frame update
    void Start()
    {
        welcomeMessage.enabled = true;
        EnableContinueButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && welcomeMessage.enabled == true)
        {
            welcomeMessage.enabled = false;
            DisableContinueButton();
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
