using GameCore;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GroundDetection groundDetection;
        [SerializeField] private PlayerMovementData playerMovementData;
        
        private Rigidbody _rigidbodyComponent;
        private bool _isGamePaused;

        private void Awake()
        {
            if (playerMovementData == null)
            {
                Debug.LogError("PlayerMovementData is not assigned!", this);
                enabled = false;
                return;
            }
            
            if (groundDetection == null)
            {
                Debug.LogError("GroundDetection is not assigned!", this);
                enabled = false;
                return;
            }
            
            _rigidbodyComponent = GetComponent<Rigidbody>();
            playerMovementData.JumpAction.performed += OnJump;
        }

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnPauseGame += HandlePauseGame;
                GameManager.Instance.OnResumeGame += HandleResumeGame;
            }
            else
            {
                Debug.LogError("GameManager instance is not available. Pause and resume functionality will not work.", this);
            }
        }

        private void OnEnable()
        {
            playerMovementData.DirectionAction.Enable();
            playerMovementData.JumpAction.Enable();
        }

        private void OnDisable()
        {
            playerMovementData.DirectionAction.Disable();
            playerMovementData.JumpAction.Disable();
        }

        private void FixedUpdate()
        {
            if(_isGamePaused) return;
            
            ApplyRotation();
            ApplyLinearMovement();
        }
        
        private void HandleResumeGame()
        {
            _isGamePaused = false;
        }

        private void HandlePauseGame()
        {
            _isGamePaused = true;
        }
    
        private void OnJump(InputAction.CallbackContext context)
        {
            if (!groundDetection.IsGrounded || _isGamePaused) return;
            
            _rigidbodyComponent.AddForce(Vector3.up * playerMovementData.JumpForce, ForceMode.VelocityChange);
        }

        private Vector2 GetDirectionPressed()
        {
            return playerMovementData.DirectionAction.ReadValue<Vector2>();
        }

        private void ApplyLinearMovement()
        {
            var inputDirection = GetDirectionPressed().y;
            var moveDirection = transform.forward * inputDirection;
        
            moveDirection.y = 0;
            moveDirection = moveDirection.normalized;

            if (_rigidbodyComponent.linearVelocity.magnitude < playerMovementData.MaxSpeed)
            {
                _rigidbodyComponent.AddForce(moveDirection * playerMovementData.Acceleration);
            }
        }

        private void ApplyRotation()
        {
            float inputRotation = GetDirectionPressed().x;
            Vector3 torque = Vector3.up * (inputRotation * playerMovementData.RotationSpeed);
            
            _rigidbodyComponent.AddTorque(torque, ForceMode.Acceleration);
        }

        private void OnDestroy()
        {
            if (playerMovementData != null)
            {
                playerMovementData.JumpAction.performed -= OnJump;
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnPauseGame -= HandlePauseGame;
                GameManager.Instance.OnResumeGame -= HandleResumeGame;
            }
        }
    }
}
