using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class GameManager : BaseManager<GameManager>
    {
        public event GameEvent.ModifyPoint OnModifyPoint;
        public event GameEvent.PauseGame OnPauseGame;
        public event GameEvent.ResumeGame OnResumeGame;
        
        //We can use a system controlling timeScale instead of just a timer
        public float Timer { get; private set; }
        public int Point { get; private set; }
        public bool IsGamePause { get; private set; }

        private void Update()
        {
            if(!IsGamePause)
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
        
        public void AddPoint(int point)
        {
            Point += point;
            OnModifyPoint?.Invoke(Point);
        }

        public void PauseGame()
        {
            if (IsGamePause) return;
            
            IsGamePause = true;
            OnPauseGame?.Invoke();
        }

        public void ResumeGame()
        {
            if (!IsGamePause) return;
            
            IsGamePause = false;
            OnResumeGame?.Invoke();
        }

        public void QuitGame()
        {
            Debug.Log("Quitting the game...");
            Application.Quit();
        }
    }
}
