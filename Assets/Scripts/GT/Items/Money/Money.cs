using GT.Characters;

namespace GT.Items.Money
{
    public sealed class Money : IItem
    {
        private readonly int _money;

        public Money()
        {
            _money = 0;
        }

        public Money(int money)
        {
            _money = money;
        }
        
        /// <summary>
        /// This is weird. To give the player money, you need to create
        /// a wallet object with some amount in it, and then run the
        /// .Give() method on it with the player object passed in:
        /// <code>
        /// // code to add £5.00 to player
        /// new Money(500).Give(player);
        /// </code>s
        /// </summary>
        /// <param name="player">Player object to give money to</param>
        public void Give(Player player)
        {
            player.ModifyMoney(_money);
        }
    }
}