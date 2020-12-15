using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagDoll : MonoBehaviour
{

    public GameObject Armature;
    public GameObject Anim;
    public Animator enemy;
    public GameObject NavMesh;
   
    public void TurnOnRagdoll()
    {
        //Armature.SetActive(true);
        Anim.GetComponent<Animator>().enabled = false;
        enemy.enabled = false;
        NavMesh.GetComponent<NavMeshAgent>().enabled = false;
    }
}
