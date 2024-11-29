namespace Level
{
    public static class LevelEvent
    {
        public delegate void StartLevel();
        public delegate void ExitLevel(bool success);
        public delegate void LevelCompleted();
    }
}
