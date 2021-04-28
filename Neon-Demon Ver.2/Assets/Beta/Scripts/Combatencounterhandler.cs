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
        foreach (var enemy in enemies)
        {
            var movescript = enemy.GetComponent<MeleeEnemy>();

            if(movescript == false)
            {

                off();
            }

        }
    }

    private void off()
    {
        portal1.SetActive(false);
        portal2.SetActive(false);
       
    }
}
