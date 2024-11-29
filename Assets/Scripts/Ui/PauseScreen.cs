using GameCore;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button restartButton;

        private void Start()
        {
            if (GameManager.Instance == null)
            {
                Debug.LogError("GameManager instance is not available. Buttons will not function correctly.");
                return;
            }
            
            if (resumeButton != null)
                resumeButton.onClick.AddListener(GameManager.Instance.ResumeGame);
            else
                Debug.LogError("Resume Button is not assigned in PauseScreen.");

            if (restartButton != null)
                restartButton.onClick.AddListener(GameManager.Instance.RestartScene);
            else
                Debug.LogError("Restart Button is not assigned in PauseScreen.");

            if (quitButton != null)
                quitButton.onClick.AddListener(QuitGame);
            else
                Debug.LogError("Quit Button is not assigned in PauseScreen.");
        }

        private void OnDestroy()
        {
            if (resumeButton != null)
                resumeButton.onClick.RemoveListener(GameManager.Instance.ResumeGame);

            if (restartButton != null)
                restartButton.onClick.RemoveListener(GameManager.Instance.RestartScene);

            if (quitButton != null)
                quitButton.onClick.RemoveListener(QuitGame);
        }
        
        private void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}
