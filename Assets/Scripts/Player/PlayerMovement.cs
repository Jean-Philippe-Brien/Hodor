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
            ApplyRotation();
            ApplyLinearMovement();
        }
    
        private void OnJump(InputAction.CallbackContext context)
        {
            if (!groundDetection.IsGrounded) return;
            
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
            var inputRotation = GetDirectionPressed().x;
            
            _rigidbodyComponent.angularVelocity = Vector3.up * (playerMovementData.RotationSpeed * inputRotation);
        }

        private void OnDestroy()
        {
            playerMovementData.JumpAction.performed -= OnJump;
        }
    }
}
