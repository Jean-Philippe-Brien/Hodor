using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObject/CoinData")]
    public class CoinData : ScriptableObject
    {
    
        [SerializeField] private int coinValue;
        [SerializeField] private Enum.SoundName takeCoinSound;
        [SerializeField] private GameObject coinPrefab;

        public int CoinValue => coinValue;

        public Enum.SoundName TakeCoinSound => takeCoinSound;

        public GameObject CoinPrefab => coinPrefab;
    }
}
