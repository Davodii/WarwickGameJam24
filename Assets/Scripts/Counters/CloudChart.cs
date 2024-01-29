using System;

namespace GT.Counters
{
    public class CloudChart : Counter
    {
        public const int Initial = 60;
        public const int MinValue = 0;
        public const int MaxValue = 100;

        public CloudChart() : base(Initial, MinValue, MaxValue)
        {
        }

        /// <summary>
        /// Categorises the under-the-hood score of the CloudChart into a category
        /// outlined by the ECloudChartStatus enum.
        /// </summary>
        /// <returns>One of the ECloudChartStatus values.</returns>
        public ECloudChartStatus GetStatus()
        {
            if (Get() < (int)ECloudChartStatus.Cloudy)
            {
                return ECloudChartStatus.Thunder;
            }

            if (Get() < (int)ECloudChartStatus.Sunny)
            {
                return ECloudChartStatus.Cloudy;
            }

            if (Get() < (int)ECloudChartStatus.VerySunny)
            {
                return ECloudChartStatus.Sunny;
            }

            return ECloudChartStatus.VerySunny;
        }
    }
}