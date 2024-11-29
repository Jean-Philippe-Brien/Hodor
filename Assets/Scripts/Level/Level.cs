using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Collider levelLimit;
        [SerializeField, Min(1)] private int coinToFinishLevel;
        
        public int CoinToFinishLevel => coinToFinishLevel;

        public Bounds GetLevelLimitBounds()
        {
            return levelLimit.bounds;
        }
    }
}
