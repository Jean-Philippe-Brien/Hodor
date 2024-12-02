using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        public CoinInfo CoinInfo { get; private set; }
        
        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        public void Initialize(CoinInfo coinInfo)
        {
            CoinInfo = coinInfo;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            CoinManager.Instance.OnCoinCollected(this);
            Destroy(gameObject);
        }
    }
}
