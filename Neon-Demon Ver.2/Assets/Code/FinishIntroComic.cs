using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishIntroComic : MonoBehaviour
{
    [SerializeField] public SceneChange sceneScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Function());
    }
    IEnumerator Function()
    {
        yield return new WaitForSeconds(70);

        sceneScript.LoadTutorial();
    }
}
