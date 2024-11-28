namespace GameManager
{
    public abstract class GameEvent
    {
        public delegate void UnlockingDoor();
        public delegate void ModifyPoint(int point);
        public delegate void GameStart();
    }
}
