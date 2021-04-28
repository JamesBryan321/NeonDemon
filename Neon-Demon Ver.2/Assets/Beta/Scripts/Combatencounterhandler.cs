using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatencounterhandler : MonoBehaviour
{


    public GameObject portal1;
    public GameObject portal2;


    public GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(enemies[0].GetComponent<MeleeEnemy>().enabled == false && enemies[3].GetComponent<MeleeEnemy>().enabled == false && enemies[2].GetComponent<MeleeEnemy>().enabled == false && enemies[4].GetComponent<MeleeEnemy>().enabled == false)
        {
            off();
        }
    }

    private void off()
    {
        portal1.SetActive(false);
        portal2.SetActive(false);
       
    }
}
