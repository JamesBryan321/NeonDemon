using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverSFX : MonoBehaviour
{

    [Header("SFX")]
    public AudioSource Click;
    public AudioSource ReloadSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevolverClick()
    {
        Click.Play();
    }

    public void Reload()
    {
        ReloadSFX.Play();
    }
}
