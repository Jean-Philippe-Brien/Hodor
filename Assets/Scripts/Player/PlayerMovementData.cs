using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData")]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField]private float maxSpeed = 5f;
        [SerializeField]private float acceleration = 10f;
        [SerializeField]private float rotationSpeed = 5f;
        [SerializeField]private float jumpForce = 7f;
        [SerializeField]private InputAction directionAction;
        [SerializeField]private InputAction jumpAction;

        public float MaxSpeed => maxSpeed;

        public float Acceleration => acceleration;

        public float RotationSpeed => rotationSpeed;

        public float JumpForce => jumpForce;

        public InputAction DirectionAction => directionAction;

        public InputAction JumpAction => jumpAction;
    }
}