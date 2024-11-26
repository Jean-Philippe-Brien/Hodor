using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float rotationSpeed;
    public float jumpForce;
    public InputAction directionAction;
    public InputAction jumpAction;
    
    private Rigidbody _rigidbody;
    

    private void Awake()
    {
        jumpAction.performed += OnJump;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        directionAction.Enable();
        
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        directionAction.Disable();
        jumpAction.Disable();
    }

    private void FixedUpdate()
    {
        ApplyRotation();
        ApplyLinearMovement();
    }
    
    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    private Vector2 GetDirectionPressed()
    {
        return directionAction.ReadValue<Vector2>();
    }

    private void ApplyLinearMovement()
    {
        var direction = transform.forward * GetDirectionPressed().y;
        
        direction.y = 0;
        direction = direction.normalized;

        if (_rigidbody.linearVelocity.magnitude < maxSpeed)
        {
            _rigidbody.AddForce(direction * acceleration);
        }

    }

    private void ApplyRotation()
    {
        _rigidbody.angularVelocity = Vector3.up * (rotationSpeed * GetDirectionPressed().x);
    }
}
