using Manager;
using Struct;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Object
{
    public class HodorUi : MonoBehaviour
    {
         [SerializeField] private TextMeshProUGUI messageText;
         [SerializeField] private TextMeshProUGUI point;
         [SerializeField] private TextMeshProUGUI timer;
         [SerializeField] private Transform endScreen;
         [SerializeField] private TextMeshProUGUI endMessage;
         [SerializeField] private Button restartButton;

        private void Start()
        {
            endScreen.gameObject.SetActive(false);
            GameManager.OnModifyPoint += OnPointChanged;
            GameManager.OnUnlockingDoor += OnUnlockingDoor;
            LevelManager.OnEndLevel += OnEndLevel;
        }

        private void Update()
        {
            timer.text = $"Timer: {GameManager.Instance.Timer:F2}";
        }

        private void OnUnlockingDoor()
        {
            messageText.text = "DOOR UNLOCK";
        }

        private void OnPointChanged(int point)
        {
            this.point.text = $"points: {point}";
        }
        
        private void OnEndLevel(EndLevelInfo endLevelInfo)
        {
            endMessage.text = $"Congrats you complete the level\\n\nTime: {endLevelInfo.TimeToFinish:F2}\\n \nPoint: {endLevelInfo.Point}"; 
            endScreen.gameObject.SetActive(true);
        }
    }
}
