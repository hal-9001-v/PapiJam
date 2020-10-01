// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInputActions.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""93d44fc2-a282-4b17-890b-f62f9d0a99d6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6f048ebe-9b6e-444d-8b1d-6f3376d3091c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eb49f448-6ffd-49b9-8676-604216a8ef94"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""885f8283-1305-4f5e-821a-d02477dc503a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""cd8d110d-1c82-417c-a3a5-5478dcfda6ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gas"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a82dc716-c765-49d7-917e-bcd02aadf1b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a0865784-61a5-4bed-92d0-6e3d8f9d875f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Limit"",
                    ""type"": ""Button"",
                    ""id"": ""4e4c73d5-92f6-4990-815d-1e6522d7dfad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""45e58dc5-67a1-49b1-a57f-f1fe2d1f59ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""9c96d796-f20c-4b3e-a348-08a2b4144800"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""4810cac6-3a00-46be-b141-353c9a878402"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""34985d03-d011-413b-9cd9-94fe9056e5ab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c75217a-42aa-452a-b073-dccac2f86940"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4ebe6010-67c0-47b6-8aa9-3655f48d70aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27cedcf3-b52a-4a0c-9072-8d40ed1cb6e9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""9f331ae4-d62c-4311-9144-f10e04e240e9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""62fb2c2b-4176-4935-8908-9eaf99709ba3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""254f779b-e9d3-4aec-ad8b-fb49b4167b76"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1731c2b8-16e5-4360-b0ba-74582692a15b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ec6eda11-87e7-4cde-9057-88abeb643608"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ada295b6-5191-485c-ba51-8ea3d6a01112"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75ed6901-da85-485f-9731-2686850f727a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0853cc91-128f-4157-837b-3ebf53a21370"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4229eada-7dda-4e30-86b7-349b120c1ec4"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5599eaa4-1805-4f7b-8153-de2c7711bfac"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b66b017-521d-4e15-9a90-875c6bf2ff13"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""5de92fc7-ed94-4c47-bb63-79d6245fe1ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""59e41712-e048-4aef-b904-1f9ff73da8eb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""039d2fc1-d27b-49de-859b-50387345223b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a8407f9-2fd1-4a9c-b42f-3860ff49a866"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f3e2bf1-4bad-4b5a-aff7-5a46cfa5ff40"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""JoyStick"",
                    ""id"": ""6e3c7d90-9553-4658-b018-ad2428074c73"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2d141620-10f5-4f25-9fc6-6d18b42196f5"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d2ce7b0d-0bde-49da-8047-a9c096405f8b"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a4efbac-ebd9-4421-aa9b-23bc59bf708f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d53d5157-6265-4d71-82ea-5db74cbcf841"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1f1aae9f-b7a7-4a30-8874-a937eddb51d2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9550fffa-3d1d-4826-a623-c5c8d2c53660"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05f8d2f7-7dde-4b87-8319-6d8c5d4f464b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Limit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df0df821-d444-46a5-8b7a-ff5b578554de"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Limit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc41b0f1-3d4c-4970-bc8b-6f4c5d6ba6c4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df50d2b2-4131-413c-a7e4-024730004bed"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95fc8db1-2cb4-4aca-b051-410841c3e075"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd835b25-7834-4d95-9a14-d72120b37d34"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3463351a-2755-4ef0-a303-94b918fb7dfc"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45b8289f-c32e-467a-85f6-c5418123ea1e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7974aff1-bf20-4268-b0d3-4bd66daf720a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3367b34-fdec-4db1-bfa2-c2d11d04d5af"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5aa87c1-e5b9-4822-982a-54d6ec10ce50"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""1d28a351-c5b4-4ad6-ac28-a6c17ec7c970"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""8b9c9dd0-486b-4121-af63-b7be68f09976"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""00a9863a-d645-4831-bb4a-94db2cdd443f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""cf945b74-8a92-474b-99b4-b1d20064ef6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""16fe9fa0-a606-401e-9eb7-473bed649611"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""6cf839b0-3004-48c3-868a-abe4f99c0e5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""c50534bd-fd8f-4a17-a4ec-1ba95ef33b04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a1c0039-cde5-4492-ace8-a506dac243d7"",
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
                    ""id"": ""11a85861-7995-422f-8040-c70340f47e12"",
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
                    ""id"": ""d842e867-2d82-4187-b8aa-809b2a124b7e"",
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
                    ""id"": ""c0abc7c5-5d73-44ae-ace5-467e1801a230"",
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
                    ""id"": ""d7768bec-9af2-4f85-bae0-e320a653f472"",
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
                    ""id"": ""bf8a2656-12dc-4cef-93b1-f2cb575c4312"",
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
                    ""id"": ""c1e410fb-7a38-41c5-bdb3-6d372eb5f3fd"",
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
                    ""id"": ""fd1deb75-6729-42da-8400-9bc7759511f0"",
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
                    ""id"": ""043e5103-02d5-44e5-bb8e-73b56a9998a1"",
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
                    ""id"": ""64fe296e-2875-4d6a-84d7-343eb029cbf6"",
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
                    ""id"": ""81c9d12e-69cf-4def-a3e4-db0a0fe2ad25"",
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
                    ""id"": ""11cb3c4a-fe5e-4bea-8b32-afdc8651f26e"",
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
                    ""id"": ""3763d0a5-adcc-45ac-b44b-73fb1d1fc25a"",
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
                    ""id"": ""c315bcbc-54c2-4f34-8691-8bd950b24b76"",
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
                    ""id"": ""0f934efa-6674-4be6-9b10-eefc82e2dcb1"",
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
                    ""id"": ""1502e02c-b242-4a84-a0a0-7b46f8b005e3"",
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
                    ""id"": ""86437209-b7ad-4977-b044-bf967510b1fe"",
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
                    ""id"": ""e114d77a-1411-4903-854f-0221e6ae55e0"",
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
                    ""id"": ""7e84c513-2463-46ea-84b9-1b69f23e51c2"",
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
                    ""id"": ""631bd784-0250-4f32-9226-6584e2742ead"",
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
                    ""id"": ""ae0c5145-e4ac-4e4e-9945-78b233d91992"",
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
                    ""id"": ""9e896666-6ac0-4af4-a5dc-b8d57684a254"",
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
                    ""id"": ""4e6348e7-a222-402d-a45c-a8556a76bebf"",
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
                    ""id"": ""bb6ed497-efd0-4ade-a2cb-0e52854878d7"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""All"",
            ""id"": ""8899b1e5-3f09-4233-85b1-22fbbb685cf2"",
            ""actions"": [
                {
                    ""name"": ""Limit"",
                    ""type"": ""Button"",
                    ""id"": ""3abdf6fd-f768-4487-a6f6-b76c9318b79e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""e96f5478-95ed-411a-8180-2b290a9c4fba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4ab24e4e-d404-42fb-9545-3eaaf458ac07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d613cd79-8349-4e28-808a-71fb6bb5ddb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gas"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6a448bd1-d8a7-45a0-a94f-de0e404fe017"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""fe5401be-b262-4994-b661-d4f5030fa968"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""ff256fa5-08c4-4f93-b80d-1ef6d5ab64e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""936ed2fc-5f91-4d71-8ee2-d379672ddf97"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""89a72725-e312-4b94-b1cb-ef43e9e24446"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""2a761660-9360-4df0-bf8e-0d862e7923ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""09907430-1fd8-44ab-802e-e7f7a73fcf5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""ecdd73e7-d196-4d3c-8a3c-be01ea75239b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""efebc4c4-efb3-41e4-8a55-5a78fd776698"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""7d159c0d-9e65-4af4-89d2-3a9e55aabecd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""f53f6a10-f650-4d5e-bf45-a984949307c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""5bada6f9-f17b-48c7-be88-56de806eafbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a2fbe817-1e4f-44ec-929d-9ffcc4a897dc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""60bc2534-e8a6-4986-be76-bd1fa32bdd13"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""12ca07f7-5e8f-4dcb-ad5b-34f61be340fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d8ede022-93d3-45e6-9aa0-feb19a8b64f8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6eda7f95-bc08-4bf9-9012-e81b7a83cbd1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""6f0fd7db-13d6-4be0-963a-adc8dfba9ae5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4698314-fff1-44fb-b1f3-2051e2d3b52d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6f904968-74e8-4d46-aabd-cc4167ffc09b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5042e8ed-9b53-44af-9f4e-42db9c1e16fc"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5f5674a5-98b9-48d4-81b4-8e6e27e1a128"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""f720f72f-07f4-4164-af46-7a35962c3503"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9a5af4c9-6121-4100-a57d-f5a8915b19cc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5b824fb0-59ad-467e-af49-cc3ae2a7778d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""544a19d0-d695-44f6-af5d-da99fd7d958c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""54b76b85-d68f-4d42-8899-aff7a9a518e8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""JoyStick"",
                    ""id"": ""daf8ecda-baa6-4bb8-8c1e-674c88c12f39"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""982e2b2c-a7af-48fc-9abe-e34f3522d5c0"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e5b1e03c-34d8-466f-81a9-4664d808eed5"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ee1c66e-4706-4f78-9fa0-ede5313ad3f3"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a78e43b4-a35d-465c-b4f3-5a28e33a451b"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""531d3945-fd49-4d67-8e3e-0c15690e0522"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50451cdc-bf44-4814-b599-6b10b7e5bb91"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23d2518c-7846-4c61-8414-7fa8944b15d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""875303cf-5412-4e1b-90e5-7c2bb8374b70"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9e72cbe-557d-408d-8e0e-afeae6c481e5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6ef8ca4-d1fc-4aea-857a-415db96887ab"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e282cf19-fef0-4d67-81c3-ecbb077a01b0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9069fd2-9f45-40a9-bf81-b14de6b08f56"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""383df741-0914-4e5f-a78f-e30f447926c8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Limit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44c2f4fc-eaf8-4f80-9ba5-3826a345aa44"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Limit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""208a6dc1-7777-4e4f-afb3-41c295899f36"",
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
                    ""id"": ""f153c98c-0776-436f-bb4c-bc41d761a31d"",
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
                    ""id"": ""002a4811-767e-4288-94fc-9fbdfdbaa210"",
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
                    ""id"": ""bdb40ad7-2054-4c94-858b-7892cea8c0fc"",
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
                    ""id"": ""d7a9731e-a048-498a-9df3-fe347885e205"",
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
                    ""id"": ""75fc8a93-80c4-4dce-81f4-2bd347b8d4d4"",
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
                    ""id"": ""fdc3af8e-4917-48e7-9fef-7ee69466fa2b"",
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
                    ""id"": ""dec6fa32-a107-46e1-80c8-56e2668c2d0f"",
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
                    ""id"": ""9cbc969c-22c2-4118-b16c-2e0e8bac6671"",
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
                    ""id"": ""48a2dca7-1e0b-4051-91bc-b455c24ef680"",
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
                    ""id"": ""82d3ee37-5a76-437c-8883-5b8779fb47ff"",
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
                    ""id"": ""50d9b6d8-851f-428e-a73a-d65d7ca52348"",
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
                    ""id"": ""adb51b7c-e593-4cb1-b88b-48ba18a06e0c"",
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
                    ""id"": ""37511a5d-de72-422e-9a93-7662022cf537"",
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
                    ""id"": ""7ed04fb1-debc-41aa-a216-01ca8ceed71a"",
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
                    ""id"": ""30523188-8920-4e19-bea4-96feb2214a20"",
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
                    ""id"": ""8e554762-f788-4095-b2bd-8325ac88bcc4"",
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
                    ""id"": ""eafceea8-0590-422b-96b0-385d2e7f7912"",
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
                    ""id"": ""bc35839a-edfb-4c31-879b-55480e7b28cc"",
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
                    ""id"": ""4c709db6-b378-482a-95d9-74a5ddd3ed0f"",
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
                    ""id"": ""cce95efe-fc0d-4f89-9915-2a05793f2a5c"",
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
                    ""id"": ""398dacf9-f3d5-45ac-9fd0-2773339f5d07"",
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
                    ""id"": ""91593c86-d787-4e62-9e7b-e181ea61dc05"",
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
                    ""id"": ""5d9ba233-3000-4e39-9f2a-91fc2622e6c2"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bd947e8-4f22-4e11-bc01-630ace39c065"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": ""Hold(duration=1.5,pressPoint=1.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""311066ca-6af5-4226-8358-4750476ec68a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a111ddb8-09e8-49f2-a2b7-25994fae452e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d889576-e5fd-4236-8434-f3fc9fe0908e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcb1b03c-e13d-4dfd-8b87-0191d18f8a7e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b570a116-1dbb-4a3d-8033-d90d24723428"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbe442c6-dbf5-48a7-a333-e6c206464e72"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Melee = m_Player.FindAction("Melee", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Gas = m_Player.FindAction("Gas", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Limit = m_Player.FindAction("Limit", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Exit = m_Player.FindAction("Exit", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Up = m_Menu.FindAction("Up", throwIfNotFound: true);
        m_Menu_Down = m_Menu.FindAction("Down", throwIfNotFound: true);
        m_Menu_Select = m_Menu.FindAction("Select", throwIfNotFound: true);
        m_Menu_Right = m_Menu.FindAction("Right", throwIfNotFound: true);
        m_Menu_Left = m_Menu.FindAction("Left", throwIfNotFound: true);
        m_Menu_Back = m_Menu.FindAction("Back", throwIfNotFound: true);
        // All
        m_All = asset.FindActionMap("All", throwIfNotFound: true);
        m_All_Limit = m_All.FindAction("Limit", throwIfNotFound: true);
        m_All_Exit = m_All.FindAction("Exit", throwIfNotFound: true);
        m_All_Pause = m_All.FindAction("Pause", throwIfNotFound: true);
        m_All_Shoot = m_All.FindAction("Shoot", throwIfNotFound: true);
        m_All_Gas = m_All.FindAction("Gas", throwIfNotFound: true);
        m_All_Dash = m_All.FindAction("Dash", throwIfNotFound: true);
        m_All_Melee = m_All.FindAction("Melee", throwIfNotFound: true);
        m_All_Aim = m_All.FindAction("Aim", throwIfNotFound: true);
        m_All_Movement = m_All.FindAction("Movement", throwIfNotFound: true);
        m_All_Back = m_All.FindAction("Back", throwIfNotFound: true);
        m_All_Left = m_All.FindAction("Left", throwIfNotFound: true);
        m_All_Right = m_All.FindAction("Right", throwIfNotFound: true);
        m_All_Select = m_All.FindAction("Select", throwIfNotFound: true);
        m_All_Down = m_All.FindAction("Down", throwIfNotFound: true);
        m_All_Up = m_All.FindAction("Up", throwIfNotFound: true);
        m_All_Quit = m_All.FindAction("Quit", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Melee;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Gas;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Limit;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Exit;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Melee => m_Wrapper.m_Player_Melee;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Gas => m_Wrapper.m_Player_Gas;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Limit => m_Wrapper.m_Player_Limit;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Exit => m_Wrapper.m_Player_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Melee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Gas.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGas;
                @Gas.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGas;
                @Gas.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGas;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Limit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLimit;
                @Limit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLimit;
                @Limit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLimit;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Exit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Gas.started += instance.OnGas;
                @Gas.performed += instance.OnGas;
                @Gas.canceled += instance.OnGas;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Limit.started += instance.OnLimit;
                @Limit.performed += instance.OnLimit;
                @Limit.canceled += instance.OnLimit;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Up;
    private readonly InputAction m_Menu_Down;
    private readonly InputAction m_Menu_Select;
    private readonly InputAction m_Menu_Right;
    private readonly InputAction m_Menu_Left;
    private readonly InputAction m_Menu_Back;
    public struct MenuActions
    {
        private @PlayerInputActions m_Wrapper;
        public MenuActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Menu_Up;
        public InputAction @Down => m_Wrapper.m_Menu_Down;
        public InputAction @Select => m_Wrapper.m_Menu_Select;
        public InputAction @Right => m_Wrapper.m_Menu_Right;
        public InputAction @Left => m_Wrapper.m_Menu_Left;
        public InputAction @Back => m_Wrapper.m_Menu_Back;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnDown;
                @Select.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Right.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                @Back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
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
    public MenuActions @Menu => new MenuActions(this);

    // All
    private readonly InputActionMap m_All;
    private IAllActions m_AllActionsCallbackInterface;
    private readonly InputAction m_All_Limit;
    private readonly InputAction m_All_Exit;
    private readonly InputAction m_All_Pause;
    private readonly InputAction m_All_Shoot;
    private readonly InputAction m_All_Gas;
    private readonly InputAction m_All_Dash;
    private readonly InputAction m_All_Melee;
    private readonly InputAction m_All_Aim;
    private readonly InputAction m_All_Movement;
    private readonly InputAction m_All_Back;
    private readonly InputAction m_All_Left;
    private readonly InputAction m_All_Right;
    private readonly InputAction m_All_Select;
    private readonly InputAction m_All_Down;
    private readonly InputAction m_All_Up;
    private readonly InputAction m_All_Quit;
    public struct AllActions
    {
        private @PlayerInputActions m_Wrapper;
        public AllActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Limit => m_Wrapper.m_All_Limit;
        public InputAction @Exit => m_Wrapper.m_All_Exit;
        public InputAction @Pause => m_Wrapper.m_All_Pause;
        public InputAction @Shoot => m_Wrapper.m_All_Shoot;
        public InputAction @Gas => m_Wrapper.m_All_Gas;
        public InputAction @Dash => m_Wrapper.m_All_Dash;
        public InputAction @Melee => m_Wrapper.m_All_Melee;
        public InputAction @Aim => m_Wrapper.m_All_Aim;
        public InputAction @Movement => m_Wrapper.m_All_Movement;
        public InputAction @Back => m_Wrapper.m_All_Back;
        public InputAction @Left => m_Wrapper.m_All_Left;
        public InputAction @Right => m_Wrapper.m_All_Right;
        public InputAction @Select => m_Wrapper.m_All_Select;
        public InputAction @Down => m_Wrapper.m_All_Down;
        public InputAction @Up => m_Wrapper.m_All_Up;
        public InputAction @Quit => m_Wrapper.m_All_Quit;
        public InputActionMap Get() { return m_Wrapper.m_All; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AllActions set) { return set.Get(); }
        public void SetCallbacks(IAllActions instance)
        {
            if (m_Wrapper.m_AllActionsCallbackInterface != null)
            {
                @Limit.started -= m_Wrapper.m_AllActionsCallbackInterface.OnLimit;
                @Limit.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnLimit;
                @Limit.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnLimit;
                @Exit.started -= m_Wrapper.m_AllActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnExit;
                @Pause.started -= m_Wrapper.m_AllActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnPause;
                @Shoot.started -= m_Wrapper.m_AllActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnShoot;
                @Gas.started -= m_Wrapper.m_AllActionsCallbackInterface.OnGas;
                @Gas.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnGas;
                @Gas.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnGas;
                @Dash.started -= m_Wrapper.m_AllActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnDash;
                @Melee.started -= m_Wrapper.m_AllActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnMelee;
                @Aim.started -= m_Wrapper.m_AllActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnAim;
                @Movement.started -= m_Wrapper.m_AllActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnMovement;
                @Back.started -= m_Wrapper.m_AllActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnBack;
                @Left.started -= m_Wrapper.m_AllActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_AllActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnRight;
                @Select.started -= m_Wrapper.m_AllActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnSelect;
                @Down.started -= m_Wrapper.m_AllActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_AllActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnUp;
                @Quit.started -= m_Wrapper.m_AllActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_AllActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_AllActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_AllActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Limit.started += instance.OnLimit;
                @Limit.performed += instance.OnLimit;
                @Limit.canceled += instance.OnLimit;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Gas.started += instance.OnGas;
                @Gas.performed += instance.OnGas;
                @Gas.canceled += instance.OnGas;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public AllActions @All => new AllActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnGas(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnLimit(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IAllActions
    {
        void OnLimit(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnGas(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
