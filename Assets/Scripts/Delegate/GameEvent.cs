using Object;

namespace Delegate
{
    public class GameEvent
    {
        public delegate void UnlockingDoor();
        public delegate void ModifyPoint(int point);
        public delegate void OnCoinLoot(Coin coin);
    }
}
