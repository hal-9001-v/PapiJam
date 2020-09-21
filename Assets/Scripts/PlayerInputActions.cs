// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""453f4646-168a-4e05-a7f2-7fbdd49c14bd"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""59dc3e11-6d35-43a2-b18e-1e9f95d262b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""18ff8c96-a5d3-4fdc-861b-5757988c1bd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""5984a43a-3209-4ffa-a35b-81a28c08e677"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""4bbe1a51-064b-4c5a-b74b-251aa8f03fec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b88d4b41-1283-474f-8648-e2f1a113550d"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""885385cf-87da-4bc6-8b99-6a1abd66de0d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afb7c432-9be7-4531-aed3-e529f7ba48a5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed022857-eb6a-4e3e-901a-1382daf6ae9e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80123a7b-364f-4464-96c6-76de3e6f57a2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94c78fe4-b664-45a8-af7a-1f8f1f48fec0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac7e3873-4d48-4de0-a322-ba9d46c2e7a3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d3a8d76-fd87-4e14-9f3c-8b4974f558d7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Up = m_Player1.FindAction("Up", throwIfNotFound: true);
        m_Player1_Right = m_Player1.FindAction("Right", throwIfNotFound: true);
        m_Player1_Left = m_Player1.FindAction("Left", throwIfNotFound: true);
        m_Player1_Down = m_Player1.FindAction("Down", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Up;
    private readonly InputAction m_Player1_Right;
    private readonly InputAction m_Player1_Left;
    private readonly InputAction m_Player1_Down;
    public struct Player1Actions
    {
        private @PlayerInputActions m_Wrapper;
        public Player1Actions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Player1_Up;
        public InputAction @Right => m_Wrapper.m_Player1_Right;
        public InputAction @Left => m_Wrapper.m_Player1_Left;
        public InputAction @Down => m_Wrapper.m_Player1_Down;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUp;
                @Right.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeft;
                @Down.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    public interface IPlayer1Actions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
