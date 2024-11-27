using Object;
using Struct;

namespace Delegate
{
    public class GameEvent
    {
        public delegate void UnlockingDoor();
        public delegate void ModifyPoint(int point);
        public delegate void CoinLoot(Coin coin);
        public delegate void GameStart();
        public delegate void StartLevel();

        public delegate void EndLevel(EndLevelInfo endLevelInfo);
        public delegate void ExitLevelBoxPass();
    }
}
