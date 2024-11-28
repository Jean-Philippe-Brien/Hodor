using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Collider levelLimit;
        [SerializeField] private int pointToUnlockLevel;
        
        public int PointToUnlockLevel => pointToUnlockLevel;

        public Bounds GetLevelLimitBounds()
        {
            return levelLimit.bounds;
        }
    }
}
