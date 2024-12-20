using UnityEngine;

namespace Level.LevelObjects
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animation animationComponent;
        private DoorState _state = DoorState.Idle;
        
        private void Start()
        {
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnLevelCompleted += HandleLevelCompleted;
            }
            else
            {
                Debug.LogError("LevelManager instance is not available. Door cannot subscribe to OnLevelCompleted.");
            }
        }

        private void HandleLevelCompleted()
        {
            _state = DoorState.DoorOpen;

            if (animationComponent != null)
            {
                animationComponent.Play(_state.ToString());
            }
            else
            {
                Debug.LogError("Animation component is not assigned. Door cannot play animations.");
            }
        }

        private void OnDestroy()
        {
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.OnLevelCompleted -= HandleLevelCompleted;
            }
        }
    }
    
    public enum DoorState
    {
        DoorOpen,
        DoorClose,
        Idle,
    }
}
