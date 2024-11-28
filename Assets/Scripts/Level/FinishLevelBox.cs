using UnityEngine;

namespace Level
{
    public class FinishLevelBox : MonoBehaviour
    {
        public static event LevelEvent.ExitLevelBoxPass OnExitLevelBoxPass;
        private void OnTriggerEnter(Collider other)
        {
            OnExitLevelBoxPass?.Invoke();
        }
    }
}
