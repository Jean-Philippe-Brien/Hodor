using UnityEngine;

namespace Object
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Collider LevelLimit;

        public Bounds GetLevelLimitBounds()
        {
            return LevelLimit.bounds;
        }
    }
}