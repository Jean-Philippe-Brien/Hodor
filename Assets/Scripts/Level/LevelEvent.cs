namespace Level
{
    public static class LevelEvent
    {
        public delegate void StartLevel();
        public delegate void ExitLevel();
        public delegate void LevelCompleted();
    }
}
