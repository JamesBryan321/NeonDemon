using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [Header("CameraTransition")]
    public Animator Cam;
    public GameObject CamRef;
    [SerializeField] private GameObject Fade;
    // Start is called before the first frame update
    void Start()
    {
      
    }

   public void Transistion()
    {
        CamRef.transform.parent = this.transform;
        Cam.SetTrigger("start");
        CamRef.GetComponent<MainMenuCamera>().enabled = false;
    }

    public void StartFade()
    {
        Fade.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
