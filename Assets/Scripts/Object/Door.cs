using Manager;
using UnityEngine;

namespace Object
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animation animationComponent;
        private Enum.DoorState state = Enum.DoorState.Idle;

        public Enum.DoorState State
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
            GameManager.OnUnlockingDoor += () => OnUnlockDoor(Enum.DoorState.DoorOpen);
        }

        private void OnUnlockDoor(Enum.DoorState stateChoose)
        {
            State = stateChoose;
        }
    
        private void OnStateChange()
        {
            animationComponent.Play(State.ToString());
        }
    }
}
