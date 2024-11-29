using GameCore;
using Level;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class HodorUi : MonoBehaviour
    {
         [SerializeField] private TextMeshProUGUI messageText;
         [SerializeField] private TextMeshProUGUI pointText;
         [SerializeField] private TextMeshProUGUI timerText;
         [SerializeField] private EndScreen endScreen;

        private void Start()
        {
            LevelManager.Instance.OnLevelCompleted += OnLevelCompleted;
            LevelManager.Instance.OnExitLevel += OnExitLevel;
            GameManager.Instance.OnModifyPoint += OnModifyPoint;
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
        
        private void OnExitLevel()
        {
            endScreen.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            LevelManager.Instance.OnLevelCompleted -= OnLevelCompleted;
            LevelManager.Instance.OnExitLevel -= OnExitLevel;
            GameManager.Instance.OnModifyPoint -= OnModifyPoint;
        }
    }
}
