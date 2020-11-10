using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class IKBehaviors : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    
    private GameObject target = null;

    
    public bool ikActive;
    public Transform rightHandObj = null;
    public Transform rightHandObjrevolver = null;
    public Transform leftHandObjrevolver = null;
    public Transform leftHandObj = null;
    private Transform lookObj = null;
    private bool revolverActive;
    public GameObject revolver;
    public GameObject machinegun;

    //[SerializeField] private Transform torso;

    //private bool headTurn, headTilt;

    void Start()
    {
        //headTurn = false;
        //headTilt = false;
    }

    [Obsolete]
    private void Update()
    {
        //OnAnimatorIK();

        if (machinegun.active == true)
        {
            ikActive = true;
            revolverActive = false;
        }
        if (revolver.active == true)
        {
            ikActive = false;
            revolverActive = true;
        }
    }

    void OnAnimatorIK()
    {

        if(playerAnimator) {
            
            //if the IK is active, set the position and rotation directly to the goal. 
            if(ikActive) {

                // Set the look target position, if one has been assigned
                if(lookObj != null) {
                    playerAnimator.SetLookAtWeight(1);
                    playerAnimator.SetLookAtPosition(lookObj.position);
                }    

                // Set the right hand target position and rotation, if one has been assigned
                if(rightHandObj != null) {
                    playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
                    playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
                    playerAnimator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
                    playerAnimator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
                }

                if (leftHandObj != null) {
                    playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
                    playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
                    playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
                    playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
                }   
                
            }
            if (revolverActive)
            {
                if (rightHandObjrevolver != null)
                {
                    playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObjrevolver.position);
                    playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObjrevolver.rotation);
                }
                if (leftHandObjrevolver != null)
                {
                    playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObjrevolver.position);
                    playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObjrevolver.rotation);
                }
            }
            
            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else {          
                playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
                playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
                playerAnimator.SetLookAtWeight(0);
            }
        }
    } 
    void checkGuns()
    {

    }
}
