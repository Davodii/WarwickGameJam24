namespace GT.Counters
{
    public class GoldenTime : Counter
    {
        public const int Initial = 30;
        public const int MinValue = int.MinValue;
        public const int MaxValue = int.MaxValue;

        public GoldenTime() : base(Initial, MinValue, MaxValue)
        {
        }
    }
}