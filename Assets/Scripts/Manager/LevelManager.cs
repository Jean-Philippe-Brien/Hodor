using Delegate;
using Object;
using Struct;
using UnityEngine;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        public static event GameEvent.StartLevel OnStartLevel;
        public static event GameEvent.EndLevel OnEndLevel;
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
            OnEndLevel?.Invoke(new EndLevelInfo(GameManager.Instance.Point, GameManager.Instance.Timer));
        }
    }
}