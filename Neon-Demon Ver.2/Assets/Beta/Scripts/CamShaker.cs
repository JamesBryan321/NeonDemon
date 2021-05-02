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
    public void ShotgunshakeIt()
    {
        StartCoroutine(camerashake.Shake(.25f, 1.2f));
    }

    public void SmallershakeIt()
    {
        StartCoroutine(camerashake.Shake(.03f, .3f));
    }



}
