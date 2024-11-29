using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData")]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField]private float maxSpeed;
        [SerializeField]private float acceleration;
        [SerializeField]private float rotationSpeed;
        [SerializeField]private float jumpForce;
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