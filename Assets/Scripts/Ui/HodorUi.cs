using Manager;
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
         [SerializeField] private TextMeshProUGUI endMessage;
         [SerializeField] private Button restartButton;

        private void Start()
        {
            GameManager.OnModifyPoint += OnPointChanged;
            GameManager.OnUnlockingDoor += OnUnlockingDoor;
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
    }
}
