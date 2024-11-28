using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        public Level ActualLevel;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"{Instance.gameObject.name} conflict with: {gameObject.name} Managers Cannot be duplicated");
            }

            Instance = this;
        }
    }
}
