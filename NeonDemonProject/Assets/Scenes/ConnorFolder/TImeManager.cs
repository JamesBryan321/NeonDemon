using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImeManager : MonoBehaviour
{
    
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 10f;
    public bool IsSlow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale < 1f)
        {
            IsSlow = true;

        }
        else
        {
            IsSlow = false;
        }
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmotion()
    {
       
        
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
