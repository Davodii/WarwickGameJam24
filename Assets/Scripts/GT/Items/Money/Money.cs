using System;
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

        public void Remove(Player player)
        {
            player.ModifyMoney(-1 * _money);
        }

        public bool Equals(IItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (other.GetItemType() != EItemType.Money) return false;

            Money otherMoney = (Money)other;
            return _money == otherMoney.GetValue();
        }

        public override int GetHashCode()
        {
            return _money;
        }

        public override string ToString()
        {
            return "£" + (_money / 100);
        }
    }
}