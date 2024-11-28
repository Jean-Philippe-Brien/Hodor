using Sound;
using UnityEngine;

namespace Coin
{
[RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        public static event CoinEvent.CoinLoot OnCoinCollected;
    
        private int coinValue;
        private SoundEnum.SoundName coinCollectedSound;

        public int CoinValue => coinValue;

        public SoundEnum.SoundName CoinCollectedSound => coinCollectedSound;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        public void Initialize(int coinValue, SoundEnum.SoundName coinCollectedSound)
        {
            this.coinValue = coinValue;
            this.coinCollectedSound = coinCollectedSound;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
