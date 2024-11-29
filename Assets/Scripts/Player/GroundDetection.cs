using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class GroundDetection : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            var colliderComponent = GetComponent<Collider>();
            
            if (colliderComponent.isTrigger) return;
            
            colliderComponent.isTrigger = true;
            Debug.LogWarning($"{name}'s collider was not set as trigger. It has been updated automatically.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsGroundLayer(other.gameObject.layer))
            {
                IsGrounded = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsGroundLayer(other.gameObject.layer))
            {
                IsGrounded = false;
            }
        }

        private bool IsGroundLayer(int layer)
        {
            return layer == LayerMask.NameToLayer("Ground");
        }
    }
}
