// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Menu/Input/MenuInputAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MenuInputAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuInputAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuInputAsset"",
    ""maps"": [
        {
            ""name"": ""MenuNav"",
            ""id"": ""445ef7c3-2be8-416a-b2fb-11f9da56951f"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""ba7a2fc8-e6d8-4965-a940-0ec06d3eaed4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""51ec443f-b98d-402f-b52d-f107786e92ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""280a81e6-f21f-4280-95c9-a1ab6720dda1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""01de85a5-c8a6-4b60-be36-ced126b80d70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9a5115b8-abd5-4e1d-91f1-e350dfdcff50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""f625dc94-2358-49a7-947c-6521eca628ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""164314ca-9ccd-4cd3-9d4a-d65e0015776e"",
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
                    ""id"": ""32eefaa1-2890-4201-9f73-1cd3a085af21"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb6211ad-f246-4ee5-951b-cbf34568ba55"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf83f810-7f9a-45b6-b45c-420cf08182bb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ba913ab-80ae-4fbb-a83a-36ace698f740"",
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
                    ""id"": ""d6d48a5f-0828-46b3-9d97-d28f1d052b3f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b82c181-3428-4ef9-a430-9def3e7106fc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bfe383e-12ed-4df3-bffe-1ccd61beae30"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba5d77d2-8918-4be3-92dc-46d94468d4de"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a56573-6cd0-4599-9ade-ca06e12c35a5"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e33ff2f0-0c40-4507-ac51-ae104e7e465c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cda8017d-fd35-4e35-8f00-c6f6f6f9cdd8"",
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
                    ""id"": ""6cc51fda-0dfe-4fdc-b09b-7212a0eb3922"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e346dee0-8235-41f1-bcf6-4f008419ad04"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec222ea5-4e30-459c-8e87-f7ee96e78faf"",
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
                    ""id"": ""ce9d4c41-f543-4254-8698-c8a201deaf34"",
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
                    ""id"": ""64c3e39a-f4af-41bf-b831-e66892694952"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dd6e0d5-89bf-499d-8b02-7a5025f3e7e7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f02f630-2cc4-489b-9465-719d2a5e7745"",
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
                    ""id"": ""fdd71c57-ba78-4733-ae46-45fec0269f17"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a3c477c-4dd2-4034-8f6c-c9c06986cc79"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b3b207e-2187-48ad-abcc-ade04d8bb6f1"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3cbd937-e093-4887-89d2-09609dae7cd0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f22f3412-631c-408a-8296-42af6d6af3b6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MenuNav
        m_MenuNav = asset.FindActionMap("MenuNav", throwIfNotFound: true);
        m_MenuNav_Up = m_MenuNav.FindAction("Up", throwIfNotFound: true);
        m_MenuNav_Down = m_MenuNav.FindAction("Down", throwIfNotFound: true);
        m_MenuNav_Select = m_MenuNav.FindAction("Select", throwIfNotFound: true);
        m_MenuNav_Right = m_MenuNav.FindAction("Right", throwIfNotFound: true);
        m_MenuNav_Left = m_MenuNav.FindAction("Left", throwIfNotFound: true);
        m_MenuNav_Back = m_MenuNav.FindAction("Back", throwIfNotFound: true);
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

    // MenuNav
    private readonly InputActionMap m_MenuNav;
    private IMenuNavActions m_MenuNavActionsCallbackInterface;
    private readonly InputAction m_MenuNav_Up;
    private readonly InputAction m_MenuNav_Down;
    private readonly InputAction m_MenuNav_Select;
    private readonly InputAction m_MenuNav_Right;
    private readonly InputAction m_MenuNav_Left;
    private readonly InputAction m_MenuNav_Back;
    public struct MenuNavActions
    {
        private @MenuInputAsset m_Wrapper;
        public MenuNavActions(@MenuInputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_MenuNav_Up;
        public InputAction @Down => m_Wrapper.m_MenuNav_Down;
        public InputAction @Select => m_Wrapper.m_MenuNav_Select;
        public InputAction @Right => m_Wrapper.m_MenuNav_Right;
        public InputAction @Left => m_Wrapper.m_MenuNav_Left;
        public InputAction @Back => m_Wrapper.m_MenuNav_Back;
        public InputActionMap Get() { return m_Wrapper.m_MenuNav; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuNavActions set) { return set.Get(); }
        public void SetCallbacks(IMenuNavActions instance)
        {
            if (m_Wrapper.m_MenuNavActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnDown;
                @Select.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnSelect;
                @Right.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnLeft;
                @Back.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuNavActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MenuNavActions @MenuNav => new MenuNavActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IMenuNavActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
