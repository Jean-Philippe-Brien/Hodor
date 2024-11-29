using System;
using Sound;
using UnityEngine;

namespace Coin
{
    [Serializable]
    public struct CoinInfo
    {
        [SerializeField, Min(0)] private int coinValue;
        [SerializeField] private SoundEnum.SoundName takeCoinSound;
        [SerializeField] private Coin coinPrefab;

        public int CoinValue => coinValue;
        public SoundEnum.SoundName TakeCoinSound => takeCoinSound;
        public Coin CoinPrefab => coinPrefab;
    }
}
