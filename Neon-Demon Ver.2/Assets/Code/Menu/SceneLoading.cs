using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [Header("CameraTransition")]
    public Animator Cam;
    [SerializeField] private GameObject Fade;
    // Start is called before the first frame update
    void Start()
    {
      
    }

   public void Transistion()
    {
        Cam.SetTrigger("start");
    }

    public void StartFade()
    {
        Fade.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }
}
