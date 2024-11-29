using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GroundDetection groundDetection;
        [SerializeField] private PlayerMovementData playerMovementData;
        
        private Rigidbody rigidbodyComponent;

        private void Awake()
        {
            playerMovementData.JumpAction.performed += OnJump;
            rigidbodyComponent = GetComponent<Rigidbody>();
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
            if (!groundDetection.isGrounded) return;
            
            rigidbodyComponent.AddForce(Vector3.up * playerMovementData.JumpForce, ForceMode.VelocityChange);
        }

        private Vector2 GetDirectionPressed()
        {
            return playerMovementData.DirectionAction.ReadValue<Vector2>();
        }

        private void ApplyLinearMovement()
        {
            var direction = transform.forward * GetDirectionPressed().y;
        
            direction.y = 0;
            direction = direction.normalized;

            if (rigidbodyComponent.linearVelocity.magnitude < playerMovementData.MaxSpeed)
            {
                rigidbodyComponent.AddForce(direction * playerMovementData.Acceleration);
            }

        }

        private void ApplyRotation()
        {
            rigidbodyComponent.angularVelocity = Vector3.up * (playerMovementData.RotationSpeed * GetDirectionPressed().x);
        }

        private void OnDestroy()
        {
            playerMovementData.JumpAction.performed -= OnJump;
        }
    }
}
