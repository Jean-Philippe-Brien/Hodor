using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Collider levelLimit;
        [SerializeField, Min(1)] private int coinToFinishLevel = 10;

        public int CoinToFinishLevel => coinToFinishLevel;

        private void Awake()
        {
            if (levelLimit == null)
            {
                Debug.LogError($"LevelLimit is not assigned in {name}. Please assign a collider in the inspector.");
            }
        }

        public Bounds GetLevelLimitBounds()
        {
            if (levelLimit == null)
            {
                Debug.LogWarning("LevelLimit is not assigned. Returning an empty Bounds.");
                return new Bounds();
            }

            return levelLimit.bounds;
        }
    }
}
