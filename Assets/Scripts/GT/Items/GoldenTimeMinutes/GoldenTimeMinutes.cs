using System;
using GT.Characters;

namespace GT.Items.GoldenTimeMinutes
{
    public sealed class GoldenTimeMinutes : IItem, IEquatable<GoldenTimeMinutes>
    {
        private readonly int _minutes;

        public GoldenTimeMinutes()
        {
            _minutes = 0;
        }

        public GoldenTimeMinutes(int minutes)
        {
            _minutes = minutes;
        }

        public EItemType GetItemType()
        {
            return EItemType.GoldenTime;
        }

        /// <summary>
        /// This is weird. To modify the player's golden time, you
        /// need to create a GoldenTimeMinutes object with some score
        /// in it, and then run the .Give() method on it with the
        /// player object passed in:
        /// <code>
        /// // code to add 3 minutes to player's golden time
        /// new GoldenTimeMinutes(3).Give(player);
        /// </code>
        /// </summary>
        /// <param name="player">Player object to change golden time</param>
        public void Give(Player player)
        {
            player.ModifyGoldenTime(_minutes);
        }

        public void Remove(Player player)
        {
            player.ModifyGoldenTime(-1 * _minutes);
        }

        public bool Equals(GoldenTimeMinutes? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _minutes == other._minutes;
        }

        public override int GetHashCode()
        {
            return _minutes;
        }
    }
}