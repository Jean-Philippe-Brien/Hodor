using System.Collections.Generic;
using System.Linq;
using Object;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager
{
    public class CoinManager : MonoBehaviour
    {
        public int CoinToDisplayAtsameTime = 3;
    
        [SerializeField] private Transform coinsContainer;
        private List<Coin> coins = new List<Coin>();
        private List<CoinData> coinDatas = new List<CoinData>();

        private void Awake()
        {
            coinDatas = Resources.LoadAll<CoinData>("ScriptableObject/coins").ToList();
        }

        private void Start()
        {
            Coin.OnCoinCollected += OnCoinCollected;
            FillCoinList();
        }

        private void OnCoinCollected(Coin coin)
        {
            SoundManager.Instance.PlaySoundOneShot(coin.CoinCollectedSound);
            GameManager.Instance.Point += coin.CoinValue;
            RemoveCoinFromList(coin);
            FillCoinList();
        }

        private void RemoveCoinFromList(Coin coin)
        {
            if (coins.Contains(coin))
            {
                coins.Remove(coin);
            }
        }

        private void FillCoinList()
        {
            if(coinDatas.Count == 0) return;
        
            while (coins.Count < CoinToDisplayAtsameTime)
            {
                coins.Add(CreateCoin(coinDatas[Random.Range(0, coinDatas.Count - 1)]));
            }
        }

        private Coin CreateCoin(CoinData data)
        {
            var coin = Instantiate(data.CoinPrefab, coinsContainer).GetComponent<Coin>();
            coin.Initialize(data.CoinValue, data.TakeCoinSound);
            //Magic Number !!!!!! update after level script
            coin.transform.position = new Vector3(Random.Range(-10, 10), 1.5f, Random.Range(-10, 10));

            return coin;
        }
    }
}
