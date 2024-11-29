using System.Globalization;
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
        [SerializeField] private TMP_Text maxTimeText;

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnModifyPoint += OnModifyPoint;
            }

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnLevelCompleted += OnLevelCompleted;
                SetMaxTimeText();
            }
        }

        private void Update()
        {
            timerText.text = $"Timer: {GameManager.Instance.Timer:F2}";
        }

        private void SetMaxTimeText()
        {
            maxTimeText.text = LevelManager.Instance.GetActualLevelMaxTimeToComplete().ToString(CultureInfo.InvariantCulture);
        }
        private void OnLevelCompleted()
        {
            messageText.text = "DOOR UNLOCK";
        }

        private void OnModifyPoint(int point)
        {
            pointText.text = $"Points: {point}";
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