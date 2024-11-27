using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObject/CoinData")]
public class CoinData : ScriptableObject
{
    
    [SerializeField] private int coinValue;
    [SerializeField] private AudioClip takeCoinSound;
    [SerializeField] private GameObject coinPrefab;

    public int CoinValue => coinValue;

    public AudioClip TakeCoinSound => takeCoinSound;

    public GameObject CoinPrefab => coinPrefab;
}
