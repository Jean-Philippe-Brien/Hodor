using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        public static event LevelEvent.StartLevel OnStartLevel;
        public static event LevelEvent.EndLevel OnEndLevel;
        public Level ActualLevel;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"{Instance.gameObject.name} conflict with: {gameObject.name} Managers Cannot be duplicated");
            }

            Instance = this;
        }

        private void Start()
        {
            FinishLevelBox.OnExitLevelBoxPass += OnExitLevelBoxPass;
            OnStartLevel?.Invoke();
        }

        private void OnExitLevelBoxPass()
        {
            OnEndLevel?.Invoke(new EndLevelInfo(GameManager.GameManager.Instance.Point, GameManager.GameManager.Instance.Timer));
        }
    }
}
