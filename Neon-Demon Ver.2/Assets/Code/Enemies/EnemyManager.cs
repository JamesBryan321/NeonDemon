using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public GameObject MeleeEnemy;
    public GameObject PortalVFX;
    public GameObject DoorObject;
    public GameObject OpenDoor;
    GameObject theObject;

    [Header("Arena Settings")]
    public int NumberOfWaves;
    public List<int> NumberOfMeleeEnemies;
    public int CurrentWave;
    public List<GameObject> CurrentEnemies = new List<GameObject>();
    public bool EnemiesDead;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject Enemy in CurrentEnemies)
        {
            if(Enemy.GetComponent<MeleeEnemy>().Dead == true)
            {
                
                EnemiesDead = true;
            }
            else
            {
                EnemiesDead = false;
            }
        }

        if(EnemiesDead == true)
        {
            CurrentWave++;
            Spawn();
        }

       
    }

    void Spawn()
    {
        
        if(CurrentWave > NumberOfWaves)
        {
            OpenDoor.SetActive(false);
        }
        
        if (CurrentWave > NumberOfWaves)
        {
            EnemiesDead = false;
            Debug.Log("End");
            transform.GetComponent<EnemyManager>().enabled = false;
        }

        for (int i = 0; i < NumberOfMeleeEnemies[CurrentWave]; i++)
        {

            Instantiate(PortalVFX, SpawnPoints[i].transform);
            theObject = Instantiate(MeleeEnemy, SpawnPoints[i].transform);
            CurrentEnemies.Add(theObject);
            //theObject.transform.parent = SpawnPoints[i].transform;
            //theObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        EnemiesDead = false;
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
