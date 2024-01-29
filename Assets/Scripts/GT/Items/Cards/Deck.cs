using System.Collections.Generic;
using System.Linq;

namespace GT.Items.Cards
{
    public class Deck
    {
        /* hashtable card storage approach -- just values */
        // the magic is just something that gets how many entries are in the ECardValue
        // enum to figure out how many entries are required for the hashtable
        // private Card[] _cards = new Card[Enum.GetNames(typeof(ECardValue)).Length];
        
        /* list card storage approach -- linear card object storage */
        // NOTE: you can change this to a fixed array, but... like... why??
        private readonly List<Card> _cards = new List<Card>();

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card); // requires some sort of comparison between cards
        }

        public bool Contains(Card card)
        {
            return _cards.Contains(card);
        }

        public int GetDeckValue()
        {
            // this is basically a sum, by using a functional programming-esque
            // reduction on the list
            return _cards.Aggregate(0, (sum, nextCard) => sum + (int)nextCard.GetValue());
        }
    }
}