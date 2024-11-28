using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerData data;
        private Rigidbody rigidbody;
        [SerializeField] private GroundDetection groundDetection;

        private void Awake()
        {
            data = Resources.Load<PlayerData>("ScriptableObject/PlayerData");
            data.JumpAction.performed += OnJump;
            rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            data.DirectionAction.Enable();
            data.JumpAction.Enable();
        }

        private void OnDisable()
        {
            data.DirectionAction.Disable();
            data.JumpAction.Disable();
        }

        private void FixedUpdate()
        {
            ApplyRotation();
            ApplyLinearMovement();
        }
    
        private void OnJump(InputAction.CallbackContext context)
        {
            if (!groundDetection.isGrounded) return;
            
            rigidbody.AddForce(Vector3.up * data.JumpForce, ForceMode.VelocityChange);
        }

        private Vector2 GetDirectionPressed()
        {
            return data.DirectionAction.ReadValue<Vector2>();
        }

        private void ApplyLinearMovement()
        {
            var direction = transform.forward * GetDirectionPressed().y;
        
            direction.y = 0;
            direction = direction.normalized;

            if (rigidbody.linearVelocity.magnitude < data.MaxSpeed)
            {
                rigidbody.AddForce(direction * data.Acceleration);
            }

        }

        private void ApplyRotation()
        {
            rigidbody.angularVelocity = Vector3.up * (data.RotationSpeed * GetDirectionPressed().x);
        }
    }
}
