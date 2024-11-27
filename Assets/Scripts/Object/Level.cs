using UnityEngine;

namespace Object
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Collider LevelLimit;
        [SerializeField] private int pointToUnlockLevel;
        
        public int PointToUnlockLevel => pointToUnlockLevel;

        public Bounds GetLevelLimitBounds()
        {
            return LevelLimit.bounds;
        }
    }
}