using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public List<ParticleSystem> ShootingSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int randomNum = Random.Range(0, 2);
            ShootingSFX[randomNum].Emit(1);
        }
    }
}
