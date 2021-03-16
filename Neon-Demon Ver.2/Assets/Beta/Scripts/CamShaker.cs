using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaker : MonoBehaviour
{

    public CameraShake camerashake;



    public void shakeIt()
    {
        StartCoroutine(camerashake.Shake(.2f, .6f));
    }


}
