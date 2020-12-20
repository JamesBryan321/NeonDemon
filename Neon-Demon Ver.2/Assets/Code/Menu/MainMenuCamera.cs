using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public List<Transform> CameraPositions;

    private Transform Temp;
    int CurrentCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Temp = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CameraPositions[CurrentCamera].position, 4.0f * Time.deltaTime);
        //transform.rotation = CameraPositions[CurrentCamera].rotation;
        transform.rotation = Quaternion.RotateTowards(Temp.rotation, CameraPositions[CurrentCamera].rotation, 80f * Time.deltaTime);
    }

    public void Move0()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 0;
    }


    public void Move1()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 1;
    }

    public void Move2()
    {
        Debug.Log("Click");
        Temp = this.transform;
        CurrentCamera = 2;
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/NeonDemonGame");
    }
}