using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public GameObject MeleeEnemy;
    public GameObject PortalVFX;
    GameObject theObject;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {

            Instantiate(PortalVFX, SpawnPoints[i].transform);
            theObject = Instantiate(MeleeEnemy, SpawnPoints[i].transform);
            //theObject.transform.parent = SpawnPoints[i].transform;
            //theObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
