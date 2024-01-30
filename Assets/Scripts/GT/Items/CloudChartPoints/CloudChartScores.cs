using System;
using GT.Characters;

namespace GT.Items.CloudChartPoints
{
    public sealed class CloudChartScore : IItem, IEquatable<CloudChartScore>
    {
        private readonly int _score;

        public CloudChartScore()
        {
            _score = 0;
        }

        public CloudChartScore(int score)
        {
            _score = score;
        }

        public EItemType GetItemType()
        {
            return EItemType.CloudChart;
        }

        /// <summary>
        /// This is weird. To modify the player's cloud chart score,
        /// create a CloudChartPoints object with some score in it,
        /// and then run the .Give() method on it with the player
        /// object passed in:
        /// <code>
        /// // code to add 10 cloud chart score to player
        /// new CloudChartPoints(10).Give(player);
        /// </code>
        /// </summary>
        /// <param name="player">Player object to give cloud chart score.</param>
        public void Give(Player player)
        {
            player.ModifyCloudChart(_score);
        }

        public bool Equals(CloudChartScore? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _score == other._score;
        }

        public override int GetHashCode()
        {
            return _score;
        }
    }
}