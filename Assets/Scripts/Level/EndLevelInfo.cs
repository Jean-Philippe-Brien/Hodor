namespace Level
{
    public struct EndLevelInfo
    {
        public readonly int Point;
        public readonly float TimeToFinish;

        public EndLevelInfo(int point, float timeToFinish)
        {
            Point = point;
            TimeToFinish = timeToFinish;
        }
    }
}
