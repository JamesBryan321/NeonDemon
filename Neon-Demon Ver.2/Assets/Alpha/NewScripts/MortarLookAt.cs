using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarLookAt : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(Player.transform.position.x,
                                                transform.position.y,
                                                Player.transform.position.z);

        transform.LookAt(playerPosition);
    }

    public void die()
    {
        this.enabled = false;
    }
}
