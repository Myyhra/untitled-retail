using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace CoreScripts
{
    public struct MoveInput
    {
        public Vector2 move;
        public bool jump;
        public bool interact;
    }
    public struct LookInput
    {
        public Vector2 lookMove;
        public bool leftClick;
        public bool rightClick;
    }
    
    public enum ActionMap
    {
        Player,
        UI
    }
    public class Player_Input : MonoBehaviour
    {
        public static Player_Input Instance { get; private set; }

        
        [Header("Input Configuration")]
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private ActionMap startingActionMap = ActionMap.Player;

        private InputActionMap playerActionMap, uiActionMap;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _interactAction;
        private InputAction _lookAction;
        private InputAction _LeftMouseAction;
        private InputAction _RightMouseAction;
        private InputAction _escapeAction;

        // Current inputs (updated via events and polling)
        public MoveInput moveInput { get; private set; }
        public LookInput lookInput { get; private set; }
        public ActionMap currentActionMap { get; private set; }

        //Public Events
        public event Action<InputAction.CallbackContext> OnJump;
        public event Action<InputAction.CallbackContext> OnInteract;
        public event Action<InputAction.CallbackContext> OnLeftClick, OnRightClick;
        public event Action<InputAction.CallbackContext> OnEscape;

        /* [Header("Can Move?")]
        [Tooltip("Usually used during Pause in game")] */
        // public bool canMove = true; using as a global reference for pausing


        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (inputActionAsset == null)
            {
                Debug.LogError("Input Action Asset not assigned");
                return;
            }

            //load action maps
            playerActionMap = inputActionAsset.FindActionMap("Player");
            uiActionMap = inputActionAsset.FindActionMap("UI");

            if (playerActionMap == null || uiActionMap == null)
            {
                Debug.LogError("Action maps 'Player' and 'UI' not found in InputActionAsset!");
                return;
            }


            _moveAction = playerActionMap.FindAction("Move");
            _jumpAction = playerActionMap.FindAction("Jump");
            _interactAction = playerActionMap.FindAction("Interact");
            _lookAction = playerActionMap.FindAction("Look");
            _LeftMouseAction = playerActionMap.FindAction("LeftClick");
            _RightMouseAction = playerActionMap.FindAction("RightClick");
            _escapeAction = playerActionMap.FindAction("Escape");

            //action validation
            if (_moveAction == null || _jumpAction == null || _interactAction == null || _lookAction == null || _LeftMouseAction == null || _RightMouseAction == null)
            {
                Debug.LogError("An Action can not be found in action maps");
                return;
            }

            SwitchActionMap(startingActionMap);

            _jumpAction.performed += OnJumpPerformed;
            _interactAction.performed += OnInteractPerformed;
            _LeftMouseAction.performed += OnLeftMousePerformed;
            _RightMouseAction.performed += OnRightMousePerformed;
            _escapeAction.performed += OnEscapePerformed;

        }
        void Start()
        {
            
        }
        void OnEnable()
        {
            GetCurrentActionMap()?.Enable();
        }
        
        void OnDisable()
        {
            GetCurrentActionMap()?.Disable();
        }

        void Update()
        {
            ReadCharacterInput();
            ReadMouseInput();
        }

        public void SwitchActionMap(ActionMap newMap)
        {
            GetCurrentActionMap()?.Disable();

            currentActionMap = newMap;

            GetCurrentActionMap().Enable();
            Debug.Log($"Current Action Map: {currentActionMap}");
        }
        private InputActionMap GetCurrentActionMap()
        {
            return currentActionMap == ActionMap.Player ? playerActionMap : uiActionMap;
        }

        void ReadCharacterInput()
        {
            if (currentActionMap != ActionMap.Player) return;
            moveInput = new MoveInput()
            {
                move = _moveAction.ReadValue<Vector2>(),
                jump = _jumpAction.WasPressedThisFrame(),
                interact = _interactAction.IsPressed()
            };
        }

        void ReadMouseInput()
        {
            if (currentActionMap != ActionMap.Player) return;

            lookInput = new LookInput
            {
                lookMove = _lookAction.ReadValue<Vector2>(),
                leftClick = _LeftMouseAction.IsPressed(),
                rightClick = _RightMouseAction.IsPressed(),
            };
        }


        //Event Handlers
        private void OnJumpPerformed(InputAction.CallbackContext ctx)
        {
            OnJump?.Invoke(ctx);
        }
        private void OnInteractPerformed(InputAction.CallbackContext ctx)
        {
            OnInteract?.Invoke(ctx);
        }
        private void OnLeftMousePerformed(InputAction.CallbackContext ctx)
        {
            OnLeftClick?.Invoke(ctx);
        }
        private void OnRightMousePerformed(InputAction.CallbackContext ctx)
        {
            OnRightClick?.Invoke(ctx);
        }
        private void OnEscapePerformed(InputAction.CallbackContext ctx)
        {
            OnEscape?.Invoke(ctx);
        }



    }
}