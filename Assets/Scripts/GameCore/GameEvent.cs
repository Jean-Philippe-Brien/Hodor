namespace GameCore
{
    public abstract class GameEvent
    {
        public delegate void ModifyPoint(int point);
        public delegate void PauseGame();
        public delegate void ResumeGame();
    }
}
