using UnityEngine;

namespace Level
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animation animationComponent;
        private DoorState _state = DoorState.Idle;
        
        private void Start()
        {
            LevelManager.Instance.OnLevelCompleted += OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
            _state = DoorState.DoorOpen;
            animationComponent.Play(_state.ToString());
        }

        private void OnDestroy()
        {
            LevelManager.Instance.OnLevelCompleted -= OnLevelCompleted;
        }
    }
    
    public enum DoorState
    {
        DoorOpen,
        DoorClose,
        Idle,
    }
}
