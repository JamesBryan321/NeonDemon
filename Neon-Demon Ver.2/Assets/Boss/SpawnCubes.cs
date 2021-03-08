using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    GameObject[] cubes = new GameObject[512];
    public float _maxScale;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject cubeinstance = (GameObject)Instantiate(cubePrefab);
            cubeinstance.transform.position = this.transform.position;
            cubeinstance.transform.parent = this.transform;
            cubeinstance.name = "AudioCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.7f * i, 0);
            cubeinstance.transform.position = Vector3.forward * 20;
            cubes[i] = cubeinstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if(cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(10, (AudioPeer._samples[i] * _maxScale) + 2, 10);
            }
        }
    }
}
