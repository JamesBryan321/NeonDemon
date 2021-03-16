using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headshot : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyHeadless;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoomHeadshot()
    {
        enemy.SetActive(false);
        enemyHeadless.SetActive(true);
    }
}
