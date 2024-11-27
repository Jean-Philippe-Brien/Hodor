using System;
using UnityEngine;

namespace Player
{
    public class GroundDetection : MonoBehaviour
    {
        public bool isGrounded = true;
        private void OnTriggerEnter(Collider other)
        {
            isGrounded = true;
        }

        private void OnTriggerExit(Collider other)
        {
            isGrounded = false;
        }
    }
}
