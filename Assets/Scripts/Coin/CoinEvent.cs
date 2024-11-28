namespace Coin
{
    public abstract class CoinEvent
    {
        public delegate void CoinLoot(Coin coin);
        public delegate void ModifyCoinCollected(int point);
    }
}
