using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSpeedReEnabler : MonoBehaviour
{
    public NewPlayerMoveScript pMScript;
    void Start()
    {
        Debug.Log("Movement Enabled");
        pMScript.AllowMovement();
    }
}
