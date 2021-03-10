using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSwayScript : MonoBehaviour
{
    public float amount = 0.055f;
    public float maxAmount = 0.09f;
    float smooth = 3;
    Vector3 def;
    Vector3 defAth;
    Vector3 euler;

    public float horizontalInput, verticalInput;
    
    GameObject ath;
    
    // Start is called before the first frame update
    void Start()
    {
        def = transform.localPosition;
        euler = transform.localEulerAngles;
    }

    float _smooth;
    // Update is called once per frame
    void Update()
    {
        UpdateSway();
    }
    
    public void OnRotateInput(float cameraRotation, float cameraTilt)
    {
        verticalInput = cameraRotation;
        horizontalInput = cameraTilt;
    }

    void UpdateSway()
    {
        _smooth = smooth;
        float factorX = verticalInput * amount;
        float factorY = horizontalInput * amount;

        if(factorX > maxAmount)
        {
            factorX = maxAmount;
        }
        if (factorX < -maxAmount)
        {
            factorX = -maxAmount;
        }
        if (factorY > maxAmount)
        {
            factorY = maxAmount;
        }
        if (factorY < -maxAmount)
        {
            factorY = -maxAmount;
        }

        Vector3 final = new Vector3(def.x + factorX, def.y + factorY, def.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, final, Time.deltaTime * _smooth);
    }
}
