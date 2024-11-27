using Manager;
using TMPro;
using UnityEngine;

namespace Object
{
    public class HodorUi : MonoBehaviour
    {
        public TextMeshProUGUI MessageText;
        public TextMeshProUGUI Point;
        public TextMeshProUGUI Timer;

        private void Awake()
        {
            GameManager.OnModifyPoint += OnPointChanged;
            GameManager.OnUnlockingDoor += OnUnlockingDoor;
        }

        private void Update()
        {
            Timer.text = $"Timer: {GameManager.Instance.Timer}";
        }

        private void OnUnlockingDoor()
        {
            MessageText.text = "DOOR UNLOCK";
        }

        private void OnPointChanged(int point)
        {
            Point.text = $"points: {point}";
        }
    }
}
