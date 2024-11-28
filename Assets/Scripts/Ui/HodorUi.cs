using Coin;
using GameCore;
using Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class HodorUi : MonoBehaviour
    {
         [SerializeField] private TextMeshProUGUI messageText;
         [SerializeField] private TextMeshProUGUI pointText;
         [SerializeField] private TextMeshProUGUI timerText;
         [SerializeField] private Transform endScreen;
         [SerializeField] private TextMeshProUGUI endMessageText;
         [SerializeField] private Button restartButton;

        private void Start()
        {
            endScreen.gameObject.SetActive(false);
            CoinManager.Instance.OnModifyCoinCollected += OnModifyCoinCollected;
            GameManager.OnUnlockingDoor += OnUnlockingDoor;
            GameManager.OnEndLevel += OnEndLevel;
        }

        private void Update()
        {
            timerText.text = $"Timer: {GameManager.Instance.Timer:F2}";
        }

        private void OnUnlockingDoor()
        {
            messageText.text = "DOOR UNLOCK";
        }

        private void OnModifyCoinCollected(int point)
        {
            this.pointText.text = $"points: {point}";
        }
        
        private void OnEndLevel(EndLevelInfo endLevelInfo)
        {
            endMessageText.text = $"Congrats you complete the level\\n\nTime: {endLevelInfo.TimeToFinish:F2}\\n \nPoint: {endLevelInfo.Point}"; 
            endScreen.gameObject.SetActive(true);
        }
    }
}
