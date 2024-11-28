using System.Collections.Generic;
using System.Linq;
using Level;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Coin
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;
        public event CoinEvent.ModifyCoinCollected OnModifyCoinCollected;
        
        [SerializeField] private int coinToDisplayAtsameTime = 3;
        [SerializeField] private Transform coinsContainer;
        [SerializeField] private int coinCollected;
        private List<Coin> coins = new List<Coin>();
        private List<CoinData> coinDatas = new List<CoinData>();
        
        public int CoinCollected
        {
            get => coinCollected;
            set
            {
                if (value >= 0)
                {
                    coinCollected = value;
                    OnModifyCoinCollected?.Invoke(coinCollected);
                }
            }
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"{Instance.gameObject.name} conflict with: {gameObject.name} Managers Cannot be duplicated");
            }

            Instance = this;
            
            coinDatas = Resources.LoadAll<CoinData>("ScriptableObject/coins").ToList();
        }

        private void Start()
        {
            Coin.OnCoinCollected += OnCoinCollected;
            
            FillCoinList();
        }

        private void OnCoinCollected(Coin coin)
        {
            RemoveCoinFromList(coin);
            FillCoinList();
            CoinCollected += coin.CoinValue;
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
        
            while (coins.Count < coinToDisplayAtsameTime)
            {
                coins.Add(CreateCoin(coinDatas[Random.Range(0, coinDatas.Count)]));
            }
        }

        private Coin CreateCoin(CoinData data)
        {
            var coin = Instantiate(data.CoinPrefab, coinsContainer).GetComponent<Coin>();
            var levelLimit = LevelManager.Instance.ActualLevel.GetLevelLimitBounds();
            coin.Initialize(data.CoinValue, data.TakeCoinSound);
            coin.transform.position = new Vector3(Random.Range(levelLimit.min.x, levelLimit.max.x), 1.5f, Random.Range(levelLimit.min.z, levelLimit.max.z));

            return coin;
        }
    }
}
