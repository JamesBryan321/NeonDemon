// GENERATED AUTOMATICALLY FROM 'Assets/VerticalSlice/Scenes/NewInputSystemTestScene/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""d2e9bdc0-0dd6-417c-b5cc-423c1ce54ea9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5c8d6814-3464-4f36-873f-4b83cd2ccd79"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""76ae805a-2a5d-40d4-9095-a207265c9839"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6dc83221-ed07-41fa-bc61-a4683b30c879"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6bc80947-514b-4dd5-b7b7-c2e1f1ebbb65"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d04a5312-0cf4-4c16-969d-065f3e01ffe1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f6e2ed09-9dfb-4237-ae77-cd6f4e40d45b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""70271a83-6658-4a28-8796-32aff1428069"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""525bf18b-4e6e-47bb-8959-8adf6d3580e6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dbceb861-c453-4bac-ad09-faad26b80fc1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b3b7c22-f8ea-407b-b067-72f441c85ac3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""id"": ""41554b49-a595-4f64-a551-c639f6f1fd33"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3fbe426d-cf75-4748-9b6d-f75fb12377e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""734de21e-c2d6-4274-b8d9-d1460c0e6c20"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a5a6e59a-f0ed-412e-8047-e23a3568684e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bba865e2-70b0-457c-bc8f-78dcec41aa07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ADS"",
                    ""type"": ""Button"",
                    ""id"": ""2794c5a7-9d71-4f7a-8686-f96a71c91d39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b6bb317c-92fe-40e6-9e81-4a4d66d4cb7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""3a0ea31b-6222-45e2-bde1-90595685fd16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""2fb6340e-ba02-44c7-8381-ec7d9714d734"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Reality"",
                    ""type"": ""Button"",
                    ""id"": ""a6082e80-c8e0-441f-8ddc-cccc18867266"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""e4b64fc0-494f-4c65-81b6-c6371e114c9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""48aa4659-5d1f-4bc0-a3a9-f93223b52702"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9157d199-9098-4df6-8ca5-46ea5cfb338a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cd68a7d-f83d-4e4e-a992-05c64a890000"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bec717a-13b4-405a-b852-c73b516e0b87"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b85c3e-f305-4ff7-be53-231689dffaef"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab844086-453f-49df-8d8c-2f804a5a066c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ADS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab979e62-109f-4df5-b678-1a3a8fdd2471"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b130fb74-bcb4-4168-a923-d16cd0a3c52a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6d082c5-3567-4c90-ac9f-a6d265900eed"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Reality"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd2e6f99-91b5-48bd-8a6e-c0994843a4f9"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard & Mouse"",
            ""id"": ""be6594bb-a118-447a-bb0e-93559fbdfa07"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d430779d-bae4-49d7-80d7-e18bd3bea3ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""4e4cdcd7-6559-4405-9701-efe01f3b999c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dbf2546b-c6db-42cd-ac48-6fcd3d89c707"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""cb2308a2-df35-4f55-96d2-f617dde15ee4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ADS"",
                    ""type"": ""Button"",
                    ""id"": ""6f75a74d-c3ba-45e1-9f37-847b391f27a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4e9f63ca-1e7d-4079-89af-b06f33e9b86e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""d03b51ca-bcc9-4868-99d4-b3dc7cbef1ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""4dc3aaf5-800d-4b27-850f-ab967c89f133"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Reality"",
                    ""type"": ""Button"",
                    ""id"": ""21edaeff-6cb8-4ddd-871f-5b95a280524e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9f19a221-a816-48a9-847e-d835ca4d220c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ea2636ca-f600-47df-a657-75a5bdc0f15f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e91f9fca-54ee-41e6-9be0-5dc13e668d70"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""66f7e13b-befd-46e1-bbdd-1c4d26635fdc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2b3fdfa0-9531-47b2-a5bb-97605b50f132"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""43b3c34e-85f8-4e7d-818c-215d6c96a0f6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85b7c0ec-e9e6-4e2d-926b-b9e99fcb9a8e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e7f10ce-df2d-4f3d-94ab-df7d2f3d7f4c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85aef5f4-9302-47f9-ae66-28ac0ff7abf3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""608de929-03ef-40f0-91c8-b24bc45fbd17"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ADS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0acf1899-dbd9-4e5e-b4f5-6e464c9eb6cc"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a698125f-f4c3-4557-a11b-c3a4cd436a8d"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""049df572-e918-499f-8d13-2c12b4add8cb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Reality"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""c81733c8-5968-4bfe-978c-b3f3c2fa5a95"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""7489184a-3491-4caf-a9c5-bafdda4049c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9280729-79a8-4fef-8dfe-645093a0ffa1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_Move = m_Controller.FindAction("Move", throwIfNotFound: true);
        m_Controller_Rotate = m_Controller.FindAction("Rotate", throwIfNotFound: true);
        m_Controller_Jump = m_Controller.FindAction("Jump", throwIfNotFound: true);
        m_Controller_Dash = m_Controller.FindAction("Dash", throwIfNotFound: true);
        m_Controller_ADS = m_Controller.FindAction("ADS", throwIfNotFound: true);
        m_Controller_Shoot = m_Controller.FindAction("Shoot", throwIfNotFound: true);
        m_Controller_Reload = m_Controller.FindAction("Reload", throwIfNotFound: true);
        m_Controller_SwitchWeapon = m_Controller.FindAction("Switch Weapon", throwIfNotFound: true);
        m_Controller_SwitchReality = m_Controller.FindAction("Switch Reality", throwIfNotFound: true);
        m_Controller_Respawn = m_Controller.FindAction("Respawn", throwIfNotFound: true);
        // Keyboard & Mouse
        m_KeyboardMouse = asset.FindActionMap("Keyboard & Mouse", throwIfNotFound: true);
        m_KeyboardMouse_Move = m_KeyboardMouse.FindAction("Move", throwIfNotFound: true);
        m_KeyboardMouse_Rotate = m_KeyboardMouse.FindAction("Rotate", throwIfNotFound: true);
        m_KeyboardMouse_Jump = m_KeyboardMouse.FindAction("Jump", throwIfNotFound: true);
        m_KeyboardMouse_Dash = m_KeyboardMouse.FindAction("Dash", throwIfNotFound: true);
        m_KeyboardMouse_ADS = m_KeyboardMouse.FindAction("ADS", throwIfNotFound: true);
        m_KeyboardMouse_Shoot = m_KeyboardMouse.FindAction("Shoot", throwIfNotFound: true);
        m_KeyboardMouse_Reload = m_KeyboardMouse.FindAction("Reload", throwIfNotFound: true);
        m_KeyboardMouse_SwitchWeapon = m_KeyboardMouse.FindAction("Switch Weapon", throwIfNotFound: true);
        m_KeyboardMouse_SwitchReality = m_KeyboardMouse.FindAction("Switch Reality", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotate;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Controller
    private readonly InputActionMap m_Controller;
    private IControllerActions m_ControllerActionsCallbackInterface;
    private readonly InputAction m_Controller_Move;
    private readonly InputAction m_Controller_Rotate;
    private readonly InputAction m_Controller_Jump;
    private readonly InputAction m_Controller_Dash;
    private readonly InputAction m_Controller_ADS;
    private readonly InputAction m_Controller_Shoot;
    private readonly InputAction m_Controller_Reload;
    private readonly InputAction m_Controller_SwitchWeapon;
    private readonly InputAction m_Controller_SwitchReality;
    private readonly InputAction m_Controller_Respawn;
    public struct ControllerActions
    {
        private @Controls m_Wrapper;
        public ControllerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controller_Move;
        public InputAction @Rotate => m_Wrapper.m_Controller_Rotate;
        public InputAction @Jump => m_Wrapper.m_Controller_Jump;
        public InputAction @Dash => m_Wrapper.m_Controller_Dash;
        public InputAction @ADS => m_Wrapper.m_Controller_ADS;
        public InputAction @Shoot => m_Wrapper.m_Controller_Shoot;
        public InputAction @Reload => m_Wrapper.m_Controller_Reload;
        public InputAction @SwitchWeapon => m_Wrapper.m_Controller_SwitchWeapon;
        public InputAction @SwitchReality => m_Wrapper.m_Controller_SwitchReality;
        public InputAction @Respawn => m_Wrapper.m_Controller_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRotate;
                @Jump.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnDash;
                @ADS.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnADS;
                @ADS.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnADS;
                @ADS.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnADS;
                @Shoot.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnReload;
                @SwitchWeapon.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchReality.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwitchReality;
                @SwitchReality.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwitchReality;
                @SwitchReality.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSwitchReality;
                @Respawn.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @ADS.started += instance.OnADS;
                @ADS.performed += instance.OnADS;
                @ADS.canceled += instance.OnADS;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @SwitchReality.started += instance.OnSwitchReality;
                @SwitchReality.performed += instance.OnSwitchReality;
                @SwitchReality.canceled += instance.OnSwitchReality;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);

    // Keyboard & Mouse
    private readonly InputActionMap m_KeyboardMouse;
    private IKeyboardMouseActions m_KeyboardMouseActionsCallbackInterface;
    private readonly InputAction m_KeyboardMouse_Move;
    private readonly InputAction m_KeyboardMouse_Rotate;
    private readonly InputAction m_KeyboardMouse_Jump;
    private readonly InputAction m_KeyboardMouse_Dash;
    private readonly InputAction m_KeyboardMouse_ADS;
    private readonly InputAction m_KeyboardMouse_Shoot;
    private readonly InputAction m_KeyboardMouse_Reload;
    private readonly InputAction m_KeyboardMouse_SwitchWeapon;
    private readonly InputAction m_KeyboardMouse_SwitchReality;
    public struct KeyboardMouseActions
    {
        private @Controls m_Wrapper;
        public KeyboardMouseActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_KeyboardMouse_Move;
        public InputAction @Rotate => m_Wrapper.m_KeyboardMouse_Rotate;
        public InputAction @Jump => m_Wrapper.m_KeyboardMouse_Jump;
        public InputAction @Dash => m_Wrapper.m_KeyboardMouse_Dash;
        public InputAction @ADS => m_Wrapper.m_KeyboardMouse_ADS;
        public InputAction @Shoot => m_Wrapper.m_KeyboardMouse_Shoot;
        public InputAction @Reload => m_Wrapper.m_KeyboardMouse_Reload;
        public InputAction @SwitchWeapon => m_Wrapper.m_KeyboardMouse_SwitchWeapon;
        public InputAction @SwitchReality => m_Wrapper.m_KeyboardMouse_SwitchReality;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardMouseActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnRotate;
                @Jump.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnDash;
                @ADS.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnADS;
                @ADS.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnADS;
                @ADS.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnADS;
                @Shoot.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnReload;
                @SwitchWeapon.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSwitchWeapon;
                @SwitchReality.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSwitchReality;
                @SwitchReality.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSwitchReality;
                @SwitchReality.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnSwitchReality;
            }
            m_Wrapper.m_KeyboardMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @ADS.started += instance.OnADS;
                @ADS.performed += instance.OnADS;
                @ADS.canceled += instance.OnADS;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @SwitchReality.started += instance.OnSwitchReality;
                @SwitchReality.performed += instance.OnSwitchReality;
                @SwitchReality.canceled += instance.OnSwitchReality;
            }
        }
    }
    public KeyboardMouseActions @KeyboardMouse => new KeyboardMouseActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnADS(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnSwitchReality(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
    public interface IKeyboardMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnADS(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnSwitchReality(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
