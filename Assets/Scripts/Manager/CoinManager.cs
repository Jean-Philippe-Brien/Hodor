using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour
{
    public Transform coinsContainer;
    public int maxCoinDisplay = 3;
    
    private List<Coin> _coins = new List<Coin>();
    private List<CoinData> _coinDatas = new List<CoinData>();

    private void Awake()
    {
        _coinDatas = Resources.LoadAll<CoinData>("ScriptableObject/coins").ToList();
    }

    private void Start()
    {
        Coin.onCoinLoot += OnCoinCollected;
        FillCoinList();
    }

    private void OnCoinCollected(Coin coin)
    {
        RemoveCoinFromList(coin);
        FillCoinList();
    }

    private void RemoveCoinFromList(Coin coin)
    {
        if (_coins.Contains(coin))
        {
            _coins.Remove(coin);
        }
    }

    private void FillCoinList()
    {
        if(_coinDatas.Count == 0) return;
        
        while (_coins.Count < maxCoinDisplay)
        {
            _coins.Add(CreateCoin(_coinDatas[Random.Range(0, _coinDatas.Count - 1)]));
        }
    }

    private Coin CreateCoin(CoinData data)
    {
        var coin = Instantiate(data.CoinPrefab, coinsContainer).GetComponent<Coin>();
        coin.playsound();
        coin.Initialize(data.CoinValue, data.TakeCoinSound);
        //Magic Number !!!!!! update after level script
        coin.transform.position = new Vector3(Random.Range(-10, 10), 1.5f, Random.Range(-10, 10));

        return coin;
    }
}
