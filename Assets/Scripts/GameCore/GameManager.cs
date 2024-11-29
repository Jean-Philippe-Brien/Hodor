using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class GameManager : BaseManager<GameManager>
    {
        public event GameEvent.ModifyPoint OnModifyPoint;
        
        private bool _updateTimer;
        
        public float Timer { get; private set; }
        public int Point { get; private set; }

        public void AddPoint(int point)
        {
            Point += point;
            OnModifyPoint?.Invoke(Point);
        }
        
        private void Start()
        {
            _updateTimer = true;
        }

        private void Update()
        {
            if(_updateTimer)
                UpdateTimer();
        }

        private void UpdateTimer()
        {
            Timer += Time.deltaTime;
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
