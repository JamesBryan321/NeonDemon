using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChamber : MonoBehaviour
{
    public GameObject GunChamberPrefab;
    private Vector3 GunChamberLocation;

    private void Start()
    {
    }

    void Spawn()
    {
        Instantiate(GunChamberPrefab, new Vector3(0, 10f, 0), Quaternion.identity);
    }
}
