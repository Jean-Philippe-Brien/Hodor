using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Object
{
    public class HodorUi : MonoBehaviour
    {
         private TextMeshProUGUI messageText;
         private TextMeshProUGUI point;
         private TextMeshProUGUI timer;

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
