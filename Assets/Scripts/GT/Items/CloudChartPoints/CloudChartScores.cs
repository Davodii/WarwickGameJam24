using System;
using GT.Characters;

namespace GT.Items.CloudChartPoints
{
    public sealed class CloudChartPoints : IItem
    {
        private readonly int _score;

        public CloudChartPoints()
        {
            _score = 0;
        }

        public CloudChartPoints(int score)
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

        public void Remove(Player player)
        {
            player.ModifyCloudChart(-1 * _score);
        }

        public bool Equals(IItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (other.GetItemType() == EItemType.CloudChart) return false;

            CloudChartPoints otherPoints = (CloudChartPoints)other;
            return _score == otherPoints._score;
        }

        public override int GetHashCode()
        {
            return _score;
        }
    }
}