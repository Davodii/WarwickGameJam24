using System.Collections.Generic;
using GT.Items;
using GT.Items.Cards;
using GT.Items.CloudChartPoints;

namespace GT.Characters
{
    public sealed class Teacher
    {
        private readonly List<Card> _cards = new List<Card>();

        /// <summary>
        /// Give a card to the teacher, get golden time for it.
        /// </summary>
        /// <param name="card">The card object to deposit.</param>
        /// <returns>The value of the card as minutes of golden time</returns>
        public IItem GiveCard(Card card)
        {
            _cards.Add(card);
            return new CloudChartPoints((int)card.GetValue());
        }
    }
}