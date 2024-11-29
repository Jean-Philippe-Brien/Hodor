using UnityEngine;

namespace Level
{
    public class ExitBox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            LevelManager.Instance.ExitLevel();
        }
    }
}
