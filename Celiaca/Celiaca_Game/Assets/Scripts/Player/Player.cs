// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Playerr"",
            ""id"": ""c27edbd3-0bb2-48f3-9197-ab0c889f96b5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fa0dd8aa-8344-4867-8555-6d337badbe4a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""d362abe6-06e4-460c-a2ad-7340f54449c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Put"",
                    ""type"": ""Button"",
                    ""id"": ""9caa97cd-87a1-4e88-8ac6-c359732af460"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98cb08c9-86f3-4120-baea-bcb5d70dc5ad"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49b3215d-be37-43ee-82f0-998978ead05e"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Put"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""move"",
                    ""id"": ""0505c080-5065-41a2-90f3-2159cdae0934"",
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
                    ""id"": ""cd93aec5-8c4d-4eae-ac97-28eb2f6508ef"",
                    ""path"": ""<DualShockGamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cd5a0e80-5677-47d0-8947-0bacebd3d000"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fff0ddad-2827-4ec6-9ac8-a3681bc024cc"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3d3ed3e7-c6db-4894-89c2-64660edd8866"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Playerr
        m_Playerr = asset.FindActionMap("Playerr", throwIfNotFound: true);
        m_Playerr_Move = m_Playerr.FindAction("Move", throwIfNotFound: true);
        m_Playerr_Grab = m_Playerr.FindAction("Grab", throwIfNotFound: true);
        m_Playerr_Put = m_Playerr.FindAction("Put", throwIfNotFound: true);
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

    // Playerr
    private readonly InputActionMap m_Playerr;
    private IPlayerrActions m_PlayerrActionsCallbackInterface;
    private readonly InputAction m_Playerr_Move;
    private readonly InputAction m_Playerr_Grab;
    private readonly InputAction m_Playerr_Put;
    public struct PlayerrActions
    {
        private @Player m_Wrapper;
        public PlayerrActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Playerr_Move;
        public InputAction @Grab => m_Wrapper.m_Playerr_Grab;
        public InputAction @Put => m_Wrapper.m_Playerr_Put;
        public InputActionMap Get() { return m_Wrapper.m_Playerr; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerrActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerrActions instance)
        {
            if (m_Wrapper.m_PlayerrActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnMove;
                @Grab.started -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnGrab;
                @Put.started -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnPut;
                @Put.performed -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnPut;
                @Put.canceled -= m_Wrapper.m_PlayerrActionsCallbackInterface.OnPut;
            }
            m_Wrapper.m_PlayerrActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Put.started += instance.OnPut;
                @Put.performed += instance.OnPut;
                @Put.canceled += instance.OnPut;
            }
        }
    }
    public PlayerrActions @Playerr => new PlayerrActions(this);
    public interface IPlayerrActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnPut(InputAction.CallbackContext context);
    }
}
