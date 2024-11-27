using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void OnCoinLoot(Coin coin);
    public static event OnCoinLoot onCoinLoot;
    
    private int coinValue;
    private AudioClip coinOnCollectedAudio;
    
    public void Initialize(int coinValue, AudioClip coinOnCollectedAudio)
    {
        this.coinValue = coinValue;
        this.coinOnCollectedAudio = coinOnCollectedAudio;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        onCoinLoot?.Invoke(this);
        GameManager.Instance.Point += coinValue;
        Destroy(gameObject);
    }
}
