using System.Collections.Generic;
using GameCore;
using Level;
using Sound;
using UnityEngine;

namespace Coin
{
    public class CoinManager : BaseManager<CoinManager>
    {
        [SerializeField, Min(0)] private int coinToDisplayAtSameTime = 3;
        [SerializeField] private Transform coinsContainer;
        [SerializeField] private CoinsData coinsData;
        
        private readonly List<Coin> _coins = new List<Coin>();

        private void Start()
        {
            if (coinsData == null || coinsContainer == null)
            {
                Debug.LogError("CoinsData or CoinsContainer is not assigned!");
                return;
            }
            
            FillCoinList();
        }

        public void OnCoinCollected(Coin coin)
        {
            GameManager.Instance.AddPoint(coin.CoinInfo.CoinValue);
            SoundManager.Instance.PlaySoundOneShot(coin.CoinInfo.TakeCoinSound);
            
            RemoveCoinFromList(coin);
            FillCoinList();
        }

        private void RemoveCoinFromList(Coin coin)
        {
            if (!_coins.Contains(coin)) return;
            
            _coins.Remove(coin);
        }

        private void FillCoinList()
        {
            if(coinsData.coins.Count == 0) return;
        
            while (_coins.Count < coinToDisplayAtSameTime)
            {
                Coin coin = CreateCoin(coinsData.coins[Random.Range(0, coinsData.coins.Count)]);
                
                if(coin == null) continue;
                
                _coins.Add(coin);
            }
        }

        private Coin CreateCoin(CoinInfo coinInfo)
        {
            if (coinInfo.CoinPrefab == null)
            {
                Debug.LogWarning("CoinInfo or CoinPrefab is missing!");
                return null;
            }
            
            Coin coin = Instantiate(coinInfo.CoinPrefab, coinsContainer).GetComponent<Coin>();
            Bounds levelLimit = LevelManager.Instance.GetActualLevelBounds();
            
            coin.Initialize(coinInfo);
            coin.transform.position = new Vector3(Random.Range(levelLimit.min.x, levelLimit.max.x), 1.5f, Random.Range(levelLimit.min.z, levelLimit.max.z));

            return coin;
        }
    }
}
