using GameCore;
using UnityEngine;

namespace Level
{
    public class LevelManager : BaseManager<LevelManager>
    {
        public event LevelEvent.LevelCompleted OnLevelCompleted;
        public event LevelEvent.ExitLevel OnExitLevel;
        
        [SerializeField] private Level actualLevel;

        public bool isLevelCompleted { get; private set; }

        private void Start()
        {
            GameManager.Instance.OnModifyPoint += OnModifyPoint;
        }

        public Bounds GetActualLevelBounds()
        {
            return actualLevel.GetLevelLimitBounds();
        }

        private void VerifyIfLevelIsCompleted(int point)
        {
            if (point < actualLevel.CoinToFinishLevel || isLevelCompleted) return;

            isLevelCompleted = true;
            OnLevelCompleted?.Invoke();
        }
        
        public void ExitLevel()
        {
            OnExitLevel?.Invoke();
        }
        
        private void OnModifyPoint(int point)
        {
            VerifyIfLevelIsCompleted(point);
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnModifyPoint -= OnModifyPoint;
        }
    }
}
