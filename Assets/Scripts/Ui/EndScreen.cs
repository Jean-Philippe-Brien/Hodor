using GameCore;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Ui
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text message;
        [SerializeField] private Button button;
        
        public void Awake()
        {
            message.text = $"Congrats you completed the level\nTime: {GameManager.Instance.Timer:F2}\nPoint: {GameManager.Instance.Point}";
        }

        private void Start()
        {
            button.onClick.AddListener(GameManager.Instance.RestartScene);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(GameManager.Instance.RestartScene);
        }

        public void SetMessage(bool success)
        {
            if (success)
                message.text = $"Congrats you completed the level\nTime: {GameManager.Instance.Timer:F2}\nPoint: {GameManager.Instance.Point}";
            else
                message.text = $"You lost !!\nTime: {GameManager.Instance.Timer:F2}\nPoint: {GameManager.Instance.Point}";
        }
    }
}
