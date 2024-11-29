using GameCore;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Ui
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private Button button;
        
        public void Awake()
        {
            message.text = $"Congrats you complete the level\nTime: {GameManager.Instance.Timer:F2}\nPoint: {GameManager.Instance.Point}";
        }

        private void Start()
        {
            button.onClick.AddListener(GameManager.Instance.RestartScene);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(GameManager.Instance.RestartScene);
        }
    }
}
