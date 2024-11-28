using GameCore;
using UnityEngine;

namespace Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animation animationComponent;
        private DoorState state = DoorState.Idle;

        public DoorState State
        {
            get => state;
            set
            {
                if(state == value) return;
            
                state = value;
                OnStateChange();
            } 
        }

        private void Start()
        {
            
            GameManager.OnUnlockingDoor += () => OnUnlockDoor(DoorState.DoorOpen);
        }

        private void OnUnlockDoor(DoorState stateChoose)
        {
            State = stateChoose;
        }
    
        private void OnStateChange()
        {
            animationComponent.Play(State.ToString());
        }
    }
    
    public enum DoorState
    {
        DoorOpen,
        DoorClose,
        Idle,
    }
}
