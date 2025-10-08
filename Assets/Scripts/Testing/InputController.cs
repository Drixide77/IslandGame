using UnityEngine;
using UnityEngine.InputSystem;

namespace IslandGame.Testing
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputController : MonoBehaviour
    {
        [Header("Input Actions")]
        [SerializeField] private InputActionReference leftClickInputAction;
        
        private PlayerInput _playerInput;
        private Camera _mainCamera;

        void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.actions.Enable();
            InputAction leftClick = _playerInput.actions.FindAction(leftClickInputAction.action.name);
            leftClick.performed += OnMouseClicked;
            
            _mainCamera = Camera.main;
        }
        
        void OnDestroy()
        {
            if (_playerInput != null)
            {
                InputAction leftClick = _playerInput.actions["LeftClick"];
                leftClick.performed -= OnMouseClicked;
            }
        }

        private void OnMouseClicked(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Probably smarter to use a layer in the future
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<IClickable2D>()?.OnClicked();
            }
        }
    }
}