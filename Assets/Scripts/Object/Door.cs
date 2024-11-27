using Manager;
using UnityEngine;

namespace Object
{
    [RequireComponent(typeof(Animation))]
    public class Door : MonoBehaviour
    {

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

        private Animation animationComponent;

        private void Awake()
        {
            animationComponent = GetComponent<Animation>();
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
