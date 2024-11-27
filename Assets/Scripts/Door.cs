using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Door : MonoBehaviour
{
    public enum DoorState
    {
        DoorOpen,
        DoorClose,
        Idle
    }

    private DoorState state = DoorState.Idle;

    public DoorState State
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
        GameManager.OnUnlockingDoor += () => OnUnlockDoor(DoorState.DoorOpen);
    }

    private void OnUnlockDoor(DoorState stateChoose)
    {
        State = stateChoose;
    }
    
    private void OnStatChange()
    {
        animationComponent.Play(state.ToString());
        Debug.Log(state.ToString());
    }
}
