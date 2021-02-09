﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]

public class MoveInputEvent : UnityEvent<float, float> {}

[Serializable]
public class RotateInputEvent : UnityEvent<float, float> {}

[Serializable]
public class JumpInputEvent : UnityEvent {}

[Serializable]
public class DashInputEvent : UnityEvent {}

[Serializable]
public class ADSInputEvent : UnityEvent {}

[Serializable]
public class ShootInputEvent : UnityEvent {}

[Serializable]
public class ReloadInputEvent : UnityEvent {}

[Serializable]
public class WeaponSwitchInputEvent : UnityEvent {}

[Serializable]
public class RealitySwitchInputEvent : UnityEvent {}


public class InputController : MonoBehaviour
{
    Controls controls;
    public MoveInputEvent moveInputEvent;
    public RotateInputEvent rotateInputEvent;
    public JumpInputEvent jumpInputEvent;
    public DashInputEvent dashInputEvent;
    public ADSInputEvent adsInputEvent;
    public ShootInputEvent shootInputEvent;
    public ReloadInputEvent reloadInputEvent;
    public WeaponSwitchInputEvent weaponSwitchInputEvent;
    public RealitySwitchInputEvent realitySwitchInputEvent;

    //public InputAction jumpAction;

    public bool useController;
    public bool useKeyboard;

    private void Awake()
    {
        controls = new Controls();
    }

    private void EnableController()
    {
        controls.Controller.Enable();
        controls.Controller.Move.performed += OnMovePerformed;
        controls.Controller.Move.canceled += OnMovePerformed;
        controls.Controller.Rotate.performed += OnRotatePerformed;
        controls.Controller.Rotate.canceled += OnRotatePerformed;
        controls.Controller.Jump.performed += OnJumpPerformed;
        controls.Controller.Dash.performed += OnDashPerformed;
        controls.Controller.ADS.performed += OnADSPerformed;
        controls.Controller.Shoot.performed += OnShootPerformed;
        controls.Controller.Reload.performed += OnReloadPerformed;
        controls.Controller.SwitchWeapon.performed += OnWeaponSwitchPerformed;
        controls.Controller.SwitchReality.performed += OnRealitySwitchPerformed;
        //controls.Controller.Jump.canceled += OnJumpPerformed;
    }
    
    private void EnableKeyboardMouse()
    {
        controls.KeyboardMouse.Enable();
        controls.KeyboardMouse.Move.performed += OnMovePerformed;
        controls.KeyboardMouse.Move.canceled += OnMovePerformed;
        controls.KeyboardMouse.Rotate.performed += OnRotatePerformed;
        controls.KeyboardMouse.Rotate.canceled += OnRotatePerformed;
        controls.KeyboardMouse.Jump.performed += OnJumpPerformed;
        controls.KeyboardMouse.Dash.performed += OnDashPerformed;
        controls.KeyboardMouse.ADS.performed += OnADSPerformed;
        controls.KeyboardMouse.Shoot.performed += OnShootPerformed;
        controls.KeyboardMouse.Reload.performed += OnReloadPerformed;
        controls.KeyboardMouse.SwitchWeapon.performed += OnWeaponSwitchPerformed;
        controls.KeyboardMouse.SwitchReality.performed += OnRealitySwitchPerformed;
    }

    private void OnEnable()
    {
        if (useController == true)
        {
            EnableController();
        }

        if (useKeyboard == true)
        {
            EnableKeyboardMouse();
        }

        //jumpAction.Enable();
        
        
        /*else
        {
            controls.Gameplay.Enable();
            controls.Gameplay.Move.performed += OnMovePerformed;
            controls.Gameplay.Move.canceled += OnMovePerformed;
            controls.Gameplay.Rotate.performed += OnRotatePerformed;
            controls.Gameplay.Rotate.canceled += OnRotatePerformed;
        }*/


    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
        //Debug.Log($"Move Input: {moveInput}");
    }

    private void OnRotatePerformed(InputAction.CallbackContext context)
    {
        Vector2 rotationInput = context.ReadValue<Vector2>();
        rotateInputEvent.Invoke(rotationInput.x, rotationInput.y);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump");
        jumpInputEvent.Invoke();
    }
    
    private void OnDashPerformed(InputAction.CallbackContext context)
    {
        dashInputEvent.Invoke();
    }
    
    private void OnADSPerformed(InputAction.CallbackContext context)
    {
        adsInputEvent.Invoke();
    }
    
    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        shootInputEvent.Invoke();
    }
    
    private void OnReloadPerformed(InputAction.CallbackContext context)
    {
        reloadInputEvent.Invoke();
    }
    
    private void OnWeaponSwitchPerformed(InputAction.CallbackContext context)
    {
        weaponSwitchInputEvent.Invoke();
    }
    
    private void OnRealitySwitchPerformed(InputAction.CallbackContext context)
    {
        realitySwitchInputEvent.Invoke();
    }
}
