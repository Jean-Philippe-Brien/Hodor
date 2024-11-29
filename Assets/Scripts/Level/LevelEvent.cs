namespace Level
{
    public abstract class LevelEvent
    {
        public delegate void StartLevel();
        public delegate void ExitLevel();
        public delegate void LevelCompleted();
    }
}
