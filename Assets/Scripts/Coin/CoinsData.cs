using System.Collections.Generic;
using UnityEngine;

namespace Coin
{
    [CreateAssetMenu(fileName = "CoinsData", menuName = "ScriptableObject/CoinsData")]
    public class CoinsData : ScriptableObject
    {
        public List<CoinInfo> coins;
    }
}
