using UnityEngine;

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
            OnStatChange();
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
    
    private void OnStatChange()
    {
        animationComponent.Play(state.ToString());
        Debug.Log(state.ToString());
    }
}
