using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class GameManager : BaseManager<GameManager>
    {
        public event GameEvent.ModifyPoint OnModifyPoint;
        public event GameEvent.PauseGame OnPauseGame;
        public event GameEvent.ResumeGame OnResumeGame;
        
        private bool _isGamePause;
        
        public float Timer { get; private set; }
        public int Point { get; private set; }

        public void AddPoint(int point)
        {
            Point += point;
            OnModifyPoint?.Invoke(Point);
        }

        private void Update()
        {
            if(!_isGamePause)
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

        public bool TogglePauseGame()
        {
            _isGamePause = !_isGamePause;
            
            if(_isGamePause)
                PauseGame();
            else
                ResumeGame();

            return _isGamePause;
        }

        public void PauseGame()
        {
            if (_isGamePause) return;
            
            _isGamePause = true;
            OnPauseGame?.Invoke();
        }

        public void ResumeGame()
        {
            if (!_isGamePause) return;
            
            _isGamePause = false;
            OnResumeGame?.Invoke();
        }

        public void QuitGame()
        {
            Debug.Log("Quitting the game...");
            Application.Quit();
        }
    }
}
