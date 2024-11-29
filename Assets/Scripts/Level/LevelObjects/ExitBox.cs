using UnityEngine;

namespace Level.LevelObjects
{
    public class ExitBox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.ExitLevel();
            }
            else
            {
                Debug.LogError("LevelManager instance is not available. Cannot trigger ExitLevel.");
            }
        }
    }
}
