using GT.Characters;

namespace GT.Items.GoldenTimeMinutes
{
    public sealed class GoldenTimeMinutes : IItem
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
    }
}