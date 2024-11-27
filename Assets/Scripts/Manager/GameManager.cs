using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public delegate void UnlockingDoor();
    public delegate void ModifyPoint(int point);
    public static UnlockingDoor OnUnlockingDoor;
    public static ModifyPoint OnModifyPoint;
    public int PointToUnlockLevel;

    private float timer = 0;
    private int point = 0;

    public float Timer
    {
        get => timer;
        set => timer = value;
    }

    public int Point
    {
        get => point;
        set
        {
            if (value >= 0)
            {
                point = value;
                OnModifyPoint?.Invoke(point);
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

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
