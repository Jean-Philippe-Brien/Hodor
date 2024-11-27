using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public delegate void UnlockingDoor();
    public static UnlockingDoor OnUnlockingDoor;
    public int PointToUnlockLevel;

    private int point = 0;

    public int Point
    {
        get => point;
        set
        {
            if (value >= 0)
            {
                point = value;
                Debug.Log(point);
            }

            if (value >= PointToUnlockLevel)
            {
                OnUnlockingDoor?.Invoke();
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(Instance.name + " conflict with:\n" + this.name + " Managers Cannot be duplicated");
        }

        Instance = this;
    }
}
