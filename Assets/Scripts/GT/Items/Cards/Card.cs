using System;
using GT.Characters;

namespace GT.Items.Cards
{
    public class Card : IItem, IEquatable<Card>
    {
        private readonly ECardValue _value;

        public Card(ECardValue value)
        {
            _value = value;
        }

        public ECardValue GetValue() { return _value; }

        public bool Equals(Card? other)
        {
            // if other is null, then they can't match
            if (ReferenceEquals(null, other)) return false;
            
            // if it's the same pointer, they must be equal
            if (ReferenceEquals(this, other)) return true;

            // otherwise, equality depends on whether card values match
            return _value == other.GetValue();
        }

        public EItemType GetItemType()
        {
            return EItemType.Card;
        }

        public void Give(Player player)
        {
            player.GiveCard(this);
        }
    }
}