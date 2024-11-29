using GameCore;
using Level;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private TMP_Text pointText;
        [SerializeField] private TMP_Text timerText;

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnModifyPoint += OnModifyPoint;
            }

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnLevelCompleted += OnLevelCompleted;
            }
        }

        private void Update()
        {
            timerText.text = $"Timer: {GameManager.Instance.Timer:F2}";
        }
        
        private void OnLevelCompleted()
        {
            messageText.text = "DOOR UNLOCK";
        }

        private void OnModifyPoint(int point)
        {
            pointText.text = $"points: {point}";
        }

        private void OnDestroy()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnModifyPoint -= OnModifyPoint;
            }

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnLevelCompleted -= OnLevelCompleted;
            }
        }
    }
}