using System;
using GT.Characters;

namespace GT.Items.Money
{
    public sealed class Money : IItem, IEquatable<Money>
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

        public EItemType GetItemType()
        {
            return EItemType.Money;
        }

        public int GetValue()
        {
            return _money;
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

        public bool Equals(Money? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _money == other._money;
        }

        public override int GetHashCode()
        {
            return _money;
        }
    }
}