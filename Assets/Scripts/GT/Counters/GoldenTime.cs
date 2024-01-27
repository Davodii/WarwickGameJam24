namespace GT.Counters
{
    public class GoldenTime : Scoreboard
    {
        private const int Initial = 30;
        private const int MinValue = int.MinValue;
        private const int MaxValue = int.MaxValue;

        public GoldenTime() : base(Initial, MinValue, MaxValue)
        {
        }
    }
}