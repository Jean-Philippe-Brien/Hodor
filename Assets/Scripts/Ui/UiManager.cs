using GameCore;
using Level;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ui
{
    public class UiManager : BaseManager<UiManager>
    {
         [SerializeField] private EndScreen endScreen;
         [SerializeField] private PauseScreen pauseScreen;
         [SerializeField] private GameScreen gameScreen;
         [SerializeField] private InputAction pauseGameCommand;
         
         private UiScreen _currentScreen;

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnPauseGame += OnPauseGame;
                GameManager.Instance.OnResumeGame += OnResumeGame;
            }
            else
            {
                Debug.LogError("GameManager instance is not available.");
            }

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnExitLevel += OnExitLevel;
            }
            else
            {
                Debug.LogError("LevelManager instance is not available.");
            }

            pauseGameCommand.performed += HandlePauseGameCommand;
            
            OnChangeScreen(UiScreen.GameScreen);
        }

        private void OnEnable()
        {
            pauseGameCommand.Enable();
        }
        
        private void OnDisable()
        {
            pauseGameCommand.Disable();
        }
        
        private void HandlePauseGameCommand(InputAction.CallbackContext obj)
        {
            if (GameManager.Instance == null) return;

            var isGamePaused = !GameManager.Instance.IsGamePause;

            if(isGamePaused)
                OnPauseGame();
            else
                OnResumeGame();
        }

        private void OnChangeScreen(UiScreen newScreen)
        {
            if (_currentScreen == newScreen) return; // Avoid unnecessary changes
            _currentScreen = newScreen;

            endScreen.gameObject.SetActive(newScreen == UiScreen.EndScreen);
            pauseScreen.gameObject.SetActive(newScreen == UiScreen.PauseScreen);
            gameScreen.gameObject.SetActive(newScreen == UiScreen.GameScreen);
        }

        private void OnPauseGame()
        {
            GameManager.Instance.PauseGame();
            OnChangeScreen(UiScreen.PauseScreen);
        }

        private void OnResumeGame()
        {
            GameManager.Instance.ResumeGame();
            OnChangeScreen(UiScreen.GameScreen);
        }
        
        private void OnExitLevel(bool success)
        {
            GameManager.Instance.PauseGame();
            endScreen.SetMessage(success);
            OnChangeScreen(UiScreen.EndScreen);
        }

        private void OnDestroy()
        {
            pauseGameCommand.performed -= HandlePauseGameCommand;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnPauseGame -= OnPauseGame;
                GameManager.Instance.OnResumeGame -= OnResumeGame;
            }

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnExitLevel -= OnExitLevel;
            }
        }
    }
}
