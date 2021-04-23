// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""cfd7607f-2cab-479f-8663-3b248f8ce246"",
            ""actions"": [
                {
                    ""name"": ""CharacterMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1d2af109-3a8f-459c-abda-29fe01d06a8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump/Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""dfcedadd-3121-46e6-8c5e-4423d5d34f76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ea55dc15-52a9-4f31-aab0-e4d9ce94f294"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll/Walk Swap"",
                    ""type"": ""Button"",
                    ""id"": ""8e384b30-dccb-45a0-9c4b-f99f5c9ebb4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8047a026-fbc0-4cb0-bb31-814cc06ea5a1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9fc9134c-84da-4295-ab56-bdf91604a055"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f8e4800c-cab0-44d7-8593-7c747b48ac1f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9fb3d512-59cd-4d63-bab6-2798985d1f94"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a46be03e-fe09-4c68-8dfa-5385b716972e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d4c65ad4-8ae1-4a68-95d3-90f43cdc6152"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump/Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b911899-f080-4eed-9cb6-915991966740"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb219e23-6c08-494a-a169-0a2b67fffb0e"",
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
                    ""id"": ""6961c6bc-be6b-4a0b-8470-4f43fddc1e2c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll/Walk Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_CharacterMovement = m_CharacterControls.FindAction("CharacterMovement", throwIfNotFound: true);
        m_CharacterControls_JumpShoot = m_CharacterControls.FindAction("Jump/Shoot", throwIfNotFound: true);
        m_CharacterControls_Pause = m_CharacterControls.FindAction("Pause", throwIfNotFound: true);
        m_CharacterControls_RollWalkSwap = m_CharacterControls.FindAction("Roll/Walk Swap", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_CharacterMovement;
    private readonly InputAction m_CharacterControls_JumpShoot;
    private readonly InputAction m_CharacterControls_Pause;
    private readonly InputAction m_CharacterControls_RollWalkSwap;
    public struct CharacterControlsActions
    {
        private @PlayerControls m_Wrapper;
        public CharacterControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CharacterMovement => m_Wrapper.m_CharacterControls_CharacterMovement;
        public InputAction @JumpShoot => m_Wrapper.m_CharacterControls_JumpShoot;
        public InputAction @Pause => m_Wrapper.m_CharacterControls_Pause;
        public InputAction @RollWalkSwap => m_Wrapper.m_CharacterControls_RollWalkSwap;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @CharacterMovement.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCharacterMovement;
                @CharacterMovement.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCharacterMovement;
                @CharacterMovement.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCharacterMovement;
                @JumpShoot.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpShoot;
                @JumpShoot.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpShoot;
                @JumpShoot.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpShoot;
                @Pause.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @RollWalkSwap.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRollWalkSwap;
                @RollWalkSwap.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRollWalkSwap;
                @RollWalkSwap.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRollWalkSwap;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CharacterMovement.started += instance.OnCharacterMovement;
                @CharacterMovement.performed += instance.OnCharacterMovement;
                @CharacterMovement.canceled += instance.OnCharacterMovement;
                @JumpShoot.started += instance.OnJumpShoot;
                @JumpShoot.performed += instance.OnJumpShoot;
                @JumpShoot.canceled += instance.OnJumpShoot;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @RollWalkSwap.started += instance.OnRollWalkSwap;
                @RollWalkSwap.performed += instance.OnRollWalkSwap;
                @RollWalkSwap.canceled += instance.OnRollWalkSwap;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnCharacterMovement(InputAction.CallbackContext context);
        void OnJumpShoot(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnRollWalkSwap(InputAction.CallbackContext context);
    }
}
