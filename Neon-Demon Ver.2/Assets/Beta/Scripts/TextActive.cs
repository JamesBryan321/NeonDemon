using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActive : MonoBehaviour
{
    public InputController inputref;

    public List<GameObject> ControllerText;
    public List<GameObject> KeyboardText;
    // Start is called before the first frame update
    void Start()
    {
        if(inputref.useController == true)
        {
            foreach (GameObject text in KeyboardText)
            {
                text.SetActive(false);
            }
            foreach (GameObject text in ControllerText)
            {
                text.SetActive(true);
            }
        }
        else if(inputref.useKeyboard == true)
        {
            foreach (GameObject text in ControllerText)
            {
                text.SetActive(false);
            }
            foreach (GameObject text in KeyboardText)
            {
                text.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
