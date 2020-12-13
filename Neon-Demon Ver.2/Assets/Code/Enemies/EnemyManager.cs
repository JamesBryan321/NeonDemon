using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public GameObject MeleeEnemy;
    public GameObject PortalVFX;
    public GameObject DoorObject;
    GameObject theObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {

            Instantiate(PortalVFX, SpawnPoints[i].transform);
            theObject = Instantiate(MeleeEnemy, SpawnPoints[i].transform);
            //theObject.transform.parent = SpawnPoints[i].transform;
            //theObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Spawn();
            DoorObject.SetActive(true);
        }
    }
}
