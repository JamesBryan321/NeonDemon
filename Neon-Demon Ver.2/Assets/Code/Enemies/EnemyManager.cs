using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public GameObject MeleeEnemy;
    public GameObject PortalVFX;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {

            Instantiate(PortalVFX, SpawnPoints[i].transform);
            Instantiate(MeleeEnemy, SpawnPoints[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
