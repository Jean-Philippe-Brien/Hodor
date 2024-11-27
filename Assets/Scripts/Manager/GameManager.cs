using Delegate;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
    
        public static event GameEvent.UnlockingDoor OnUnlockingDoor;
        public static event GameEvent.ModifyPoint OnModifyPoint;
        public int PointToUnlockLevel;

        private float timer = 0;
        private int point = 0;

        public float Timer => timer;

        public int Point
        {
            get => point;
            set
            {
                if (value >= 0)
                {
                    point = value;
                    OnModifyPoint?.Invoke(point);
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
                Debug.LogError($"{Instance.gameObject.name} conflict with: {gameObject.name} Managers Cannot be duplicated");
            }

            Instance = this;
        }

        private void Update()
        {
            timer += Time.deltaTime;
        }
    }
}
