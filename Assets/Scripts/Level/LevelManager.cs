using System;
using GameCore;
using UnityEngine;

namespace Level
{
    public class LevelManager : BaseManager<LevelManager>
    {
        public event LevelEvent.LevelCompleted OnLevelCompleted;
        public event LevelEvent.ExitLevel OnExitLevel;
        
        [SerializeField] private Level actualLevel;

        private bool _isLevelCompleted;

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnModifyPoint += OnModifyPoint;
            }
            else
            {
                Debug.LogError("GameManager instance is not available. LevelManager cannot track points.");
            }

            if (actualLevel == null)
            {
                Debug.LogError("ActualLevel is not assigned in LevelManager.");
            }
        }

        private void Update()
        {
            if(GameManager.Instance.Timer < actualLevel.MaxTimeToComplete ) return;
            
            OnTimeOut();
        }

        public void OnTimeOut()
        {
            OnExitLevel?.Invoke(false);
        }

        public Bounds GetActualLevelBounds()
        {
            if (actualLevel == null)
            {
                Debug.LogWarning("ActualLevel is not assigned. Returning default Bounds.");
                return new Bounds();
            }
            
            return actualLevel.GetLevelLimitBounds();
        }

        public float GetActualLevelMaxTimeToComplete()
        {
            return actualLevel.MaxTimeToComplete;
        }

        private void VerifyIfLevelIsCompleted(int point)
        {
            if (actualLevel == null)
            {
                Debug.LogWarning("Cannot verify level completion. ActualLevel is not assigned.");
                return;
            }

            if (point >= actualLevel.CoinToFinishLevel && !_isLevelCompleted)
            {
                _isLevelCompleted = true;
                OnLevelCompleted?.Invoke();
            }
        }
        
        public void ExitLevel()
        {
            if (!_isLevelCompleted)
            {
                Debug.LogWarning("Level is not completed yet, but ExitLevel was invoked.");
            }
            
            OnExitLevel?.Invoke(true);
        }
        
        private void OnModifyPoint(int point)
        {
            VerifyIfLevelIsCompleted(point);
        }

        private void OnDestroy()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnModifyPoint -= OnModifyPoint;
            }
        }
    }
}
