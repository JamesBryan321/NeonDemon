using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    [SerializeField] public SceneChange sceneScript;

    private void OnTriggerEnter(Collider other)
    {
        sceneScript.LoadMainLevel();
    }
}
