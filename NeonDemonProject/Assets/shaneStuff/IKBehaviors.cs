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
    public Transform leftHandObj = null;
    private Transform lookObj = null;
    //[SerializeField] private Transform torso;

    //private bool headTurn, headTilt;
    
    void Start()
    {
        //headTurn = false;
        //headTilt = false;
    }

    private void Update()
    {
        OnAnimatorIK();
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
                
                if(leftHandObj != null) {
                    playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
                    playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
                    playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
                    playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
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
}
