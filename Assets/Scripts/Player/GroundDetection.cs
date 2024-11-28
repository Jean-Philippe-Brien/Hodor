using UnityEngine;

namespace Player
{
    public class GroundDetection : MonoBehaviour
    {
        public bool isGrounded = true;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
                isGrounded = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
                isGrounded = false;
        }
    }
}
