using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArena : MonoBehaviour
{
    [SerializeField] public SceneChange sceneScript;

    private void OnTriggerEnter(Collider other)
    {
        sceneScript.LoadMainMenu();
    }
}
