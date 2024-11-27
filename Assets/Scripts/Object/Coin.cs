using Delegate;
using UnityEngine;

namespace Object
{
[RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        public static event GameEvent.OnCoinLoot OnCoinCollected;
    
        private int coinValue;
        private Enum.SoundName coinCollectedSound;

        public int CoinValue => coinValue;

        public Enum.SoundName CoinCollectedSound => coinCollectedSound;

        public void Initialize(int coinValue, Enum.SoundName coinCollectedSound)
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
