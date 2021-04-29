using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealitySwapPP : MonoBehaviour
{
    public GameObject PP_RS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PPSetActiveTrue()
    {
        PP_RS.SetActive(true);
    }
    public void PPSetActiveFalse()
    {
        PP_RS.SetActive(false);
    }
}
