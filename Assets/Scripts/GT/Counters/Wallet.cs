namespace GT.Counters
{
    public class Wallet : Counter
    {
        public const int Initial = 0;
        public const int MinValue = int.MinValue;
        public const int MaxValue = int.MaxValue;
        public Wallet() : base(Initial, MinValue, MaxValue)
        {
        }
    }
}