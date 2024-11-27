using Manager;
using TMPro;
using UnityEngine;

namespace Object
{
    public class HodorUi : MonoBehaviour
    {
         [SerializeField] private TextMeshProUGUI messageText;
         [SerializeField] private TextMeshProUGUI point;
         [SerializeField] private TextMeshProUGUI timer;

        private void Awake()
        {
            GameManager.OnModifyPoint += OnPointChanged;
            GameManager.OnUnlockingDoor += OnUnlockingDoor;
        }

        private void Update()
        {
            timer.text = $"Timer: {GameManager.Instance.Timer}";
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
