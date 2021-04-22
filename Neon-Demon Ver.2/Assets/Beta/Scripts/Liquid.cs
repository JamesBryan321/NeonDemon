using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{



    public GameObject Beer;
    public GameObject beerMesh;

    private int sloshSpeed = 80;
    private int rotateSpeed = 35;
    private int difference = 5;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        slosh();
        beerMesh.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
    }


    public void slosh ()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        Vector3 finalRotation = Quaternion.RotateTowards(Beer.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        Beer.transform.localEulerAngles = finalRotation;


    }


    private float ClampRotationValue(float value, float differnce)
    {
        float returnValue = 0.0f;

        if(value > 180)
        {
            returnValue = Mathf.Clamp(value, 360 - differnce, 360);
        }
       else
        {
            returnValue = Mathf.Clamp(value,0, differnce);
        }
        return returnValue;
    }
}
