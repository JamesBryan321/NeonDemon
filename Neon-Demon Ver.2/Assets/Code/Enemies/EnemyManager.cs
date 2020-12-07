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
        Instantiate(PortalVFX, SpawnPoints[0].transform);
        Instantiate(MeleeEnemy, SpawnPoints[0].transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
