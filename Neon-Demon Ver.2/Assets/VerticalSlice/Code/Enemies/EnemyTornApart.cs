using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTornApart : MonoBehaviour
{

    [SerializeField]
    public GameObject EnemyAnimated;
    [SerializeField]
    private GameObject EnemyTorn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TurnEnemyoff()
    {
        EnemyAnimated.SetActive(false);
        EnemyTorn.SetActive(true);
    }
    public void TurnEnemyOn()
    {
        EnemyAnimated.SetActive(true);
        EnemyTorn.SetActive(true);
    }
}
