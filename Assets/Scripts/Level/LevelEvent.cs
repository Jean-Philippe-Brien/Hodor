namespace Level
{
    public abstract class LevelEvent
    {
        public delegate void StartLevel();
        public delegate void EndLevel(EndLevelInfo endLevelInfo);
        public delegate void ExitLevelBoxPass();
    }
}
