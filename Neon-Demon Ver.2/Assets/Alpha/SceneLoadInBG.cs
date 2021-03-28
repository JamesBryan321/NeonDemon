using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadInBG : MonoBehaviour
{
    public bool loadtest;
    private AsyncOperation asyncLoad;
    // Start is called before the first frame update
    void Start()
    {

        
    }
    public void Loadnext()
    {
        loadtest = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (loadtest == true)
        {
            StartCoroutine("loadScene");
        }
    }

    IEnumerator loadScene()
    {
        
        AsyncOperation async = SceneManager.LoadSceneAsync("NewTutorial");
        async.allowSceneActivation = false;
        while (async.progress <= 0.89f)
        {
            Debug.Log(async.progress.ToString());
            yield return null;
        }
        async.allowSceneActivation = true;
      
        /*
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("NewTutorial");

       

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        */
    }

    public void tut()
    {
        SceneManager.LoadScene("NewTutorial");
    }
}
