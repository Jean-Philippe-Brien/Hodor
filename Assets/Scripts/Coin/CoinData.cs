using Sound;
using UnityEngine;

namespace Coin
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObject/CoinData")]
    public class CoinData : ScriptableObject
    {
    
        [SerializeField] private int coinValue;
        [SerializeField] private SoundEnum.SoundName takeCoinSound;
        [SerializeField] private GameObject coinPrefab;

        public int CoinValue => coinValue;

        public SoundEnum.SoundName TakeCoinSound => takeCoinSound;

        public GameObject CoinPrefab => coinPrefab;
    }
}
