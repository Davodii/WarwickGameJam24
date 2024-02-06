using System;
using GT.Characters;

namespace GT.Items.Cards
{
    public class Card : IItem
    {
        private const int HashDispersionMultiplier = 500;
        private readonly ECardValue _value;

        public Card(ECardValue value)
        {
            _value = value;
        }

        public ECardValue GetValue() { return _value; }

        public bool Equals(IItem? other)
        {
            // if other is null, then they can't match
            if (ReferenceEquals(null, other)) return false;
            
            // if it's the same pointer, they must be equal
            if (ReferenceEquals(this, other)) return true;
            
            if (other.GetItemType() != EItemType.Card) return false;

            Card otherCard = (Card)other;

            // otherwise, equality depends on whether card values match
            return _value == otherCard.GetValue();
        }

        public EItemType GetItemType()
        {
            return EItemType.Card;
        }

        public void Give(Player player)
        {
            player.GiveCard(this);
        }

        public void Remove(Player player)
        {
            player.RemoveCard(this);
        }

        public override int GetHashCode()
        {
            return ((int)GetItemType() * HashDispersionMultiplier) + (int)_value;
        }

        public override string ToString()
        {
            return _value switch
            {
                ECardValue._1 => "Green Card",
                ECardValue._2 => "Blue Card",
                ECardValue._3 => "Purple Card",
                ECardValue._4 => "Red Card",
                ECardValue._5 => "Yellow Card",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}