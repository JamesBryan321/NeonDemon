using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRealityAnimation : MonoBehaviour
{

    public Animator Belial_Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        
            Belial_Anim.SetBool("RealityChange", true);
            StartCoroutine(WaitForChange());
        }

    }

    public IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(1);

        Belial_Anim.SetBool("RealityChange", false);
    }
}
