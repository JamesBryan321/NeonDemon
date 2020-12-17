using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 orginalRot;
   
    // Start is called before the first frame update
    void Start()
    {
        orginalRot = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            recoil();
            StartCoroutine(resetrec());
        }
    }

    public void recoil()
    {
        transform.localEulerAngles += upRecoil;
        // transform.rotation = Quaternion.RotateTowards(Temp.rotation, RecoilPos.rotation, 80f * Time.deltaTime);
        return;

    }
    public IEnumerator resetrec()
    {
        yield return new WaitForSeconds(0.15f);
        transform.localEulerAngles = orginalRot;
        
    }



}
