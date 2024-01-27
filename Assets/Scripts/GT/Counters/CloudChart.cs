using System;

namespace GT.Counters
{
    public class CloudChart : Scoreboard
    {
        private const int Initial = 60;
        private const int MinValue = 0;
        private const int MaxValue = 100;

        public CloudChart() : base(Initial, MinValue, MaxValue)
        {
        }

        public ECloudChartStatus GetStatus()
        {
            throw new NotImplementedException();
        }
    }
}