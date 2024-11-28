using Coin;
using Level;
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
    
        public static event GameEvent.UnlockingDoor OnUnlockingDoor;
        public static event LevelEvent.EndLevel OnEndLevel;
        
        public float Timer => timer;

        private float timer;
        private int point;
        private bool updateTimer;

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
            FinishLevelBox.OnExitLevelBoxPass += OnExitLevelBoxPass;
            CoinManager.Instance.OnModifyCoinCollected += ModifyPointCollected;
        }

        private void ModifyPointCollected(int coinCollected)
        {
            if (coinCollected < LevelManager.Instance.ActualLevel.PointToUnlockLevel) return;
            
            OnUnlockingDoor?.Invoke();
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
        
        private void OnExitLevelBoxPass()
        {
            OnEndLevel?.Invoke(new EndLevelInfo(CoinManager.Instance.CoinCollected, timer));
        }
    }
}
