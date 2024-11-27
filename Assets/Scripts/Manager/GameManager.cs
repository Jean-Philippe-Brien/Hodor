using Delegate;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
    
        public static event GameEvent.UnlockingDoor OnUnlockingDoor;
        public static event GameEvent.ModifyPoint OnModifyPoint;
        public static event GameEvent.GameStart OnGameStart;
        
        public float Timer => timer;

        private float timer = 0;
        private int point = 0;
        private bool updateTimer;

        public int Point
        {
            get => point;
            set
            {
                if (value >= 0)
                {
                    point = value;
                    OnModifyPoint?.Invoke(point);
                }

                if (value >= LevelManager.Instance.ActualLevel.PointToUnlockLevel)
                {
                    OnUnlockingDoor?.Invoke();
                }
            }
        }

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
            updateTimer = true;
            LevelManager.OnEndLevel += OnEndLevel;
            OnGameStart?.Invoke();
        }

        private void OnEndLevel()
        {
            updateTimer = false;
        }

        private void Update()
        {
            if(updateTimer)
                UpdateTimer();
        }

        private void UpdateTimer()
        {
            timer += Time.deltaTime;
        }
    }
}
