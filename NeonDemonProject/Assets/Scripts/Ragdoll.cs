using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField]
    public List<Collider> RagdollParts = new List<Collider>();
    public Animator enemeyAnimator;
    public Rigidbody enemyRigidbody;
    public GameObject armature;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void Awake()
    {

        
    }


    private void setRagdollparts()
    {

    
        enemeyAnimator.enabled = false;
    
    } 

    public void TurnOnRagdoll()
    {
        enemeyAnimator.enabled = false;
        enemeyAnimator.avatar = null;
        armature.SetActive(true);
        this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        this.gameObject.GetComponent<MeleeEnemy>().enabled = false;
    }
    private void SetColliderSpheres()
    {

    }

}
